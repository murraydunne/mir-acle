using Sanford.Multimedia.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Miracle
{
    public class Player
    {
        public int SixteenthNoteLengthInMs { get; set; }

        private object playingLock = new object();
        private bool isCurrentlyPlaying = false;
        private bool stopPlayback = false;
        private Thread playingThread = null;

        public Player()
        {
            SixteenthNoteLengthInMs = 208; // ~200 BPM
        }

        public void Play(List<Note> song, int key, List<int> chords)
        {
            lock(playingLock)
            {
                if(isCurrentlyPlaying)
                {
                    return;
                }

                isCurrentlyPlaying = true;
                stopPlayback = false;

                List<Note> copyOfSong = new List<Note>(song);
                List<int> copyOfChords = new List<int>(chords);
                SongAndChords param = new SongAndChords() { Song = copyOfSong, Key = key, Chords = copyOfChords };

                playingThread = new Thread(new ParameterizedThreadStart(DoPlay));
                playingThread.Start(param);
            }
        }

        public void Stop()
        {
            lock(playingLock)
            {
                if(!isCurrentlyPlaying)
                {
                    return;
                }

                stopPlayback = true;
            }

            playingThread.Join();

            lock(playingLock)
            {
                isCurrentlyPlaying = false;
                stopPlayback = false;
                playingThread = null;
            }
        }

        public bool IsPlaying
        {
            get
            {
                lock(playingLock)
                {
                    return isCurrentlyPlaying;
                }
            }
        }

        private struct SongAndChords
        {
            public List<Note> Song { get; set; }
            public int Key { get; set; }
            public List<int> Chords { get; set; }
        }

        private void Note(bool on, int note, ChannelMessageBuilder builder, OutputDevice output)
        {
            if(on)
            {
                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = 0;
                builder.Data1 = note + 45;
                builder.Data2 = 127;
                builder.Build();

                output.Send(builder.Result);
            }
            else
            {
                builder.Command = ChannelCommand.NoteOff;
                builder.MidiChannel = 0;
                builder.Data1 = note + 45;
                builder.Data2 = 0;
                builder.Build();

                output.Send(builder.Result);
            }
        }

        private void DoPlay(object objSong)
        {
            SongAndChords param = (SongAndChords)objSong;
            List<Note> song = (List<Note>)param.Song;
            int[] chords = param.Chords.ToArray();
            int key = param.Key;
            int currentSongPos = 0;
            int lastChordOn = 0;

            using (OutputDevice outDevice = new OutputDevice(0))
            {
                ChannelMessageBuilder builder = new ChannelMessageBuilder();

                // turn first chord on
                Note(true, key + chords[0], builder, outDevice);
                lastChordOn = key + Scales.Major[chords[0]];

                foreach (Note n in song)
                {
                    lock(playingLock)
                    {
                        if(stopPlayback)
                        {
                            break;
                        }
                    }

                    // turn on current note
                    Note(true, n.Id, builder, outDevice);

                    int sixteenthsToNextBarline = (int)(Math.Ceiling(currentSongPos / 16.0f) * 16.0f) - currentSongPos;
                    int noteSleep = (int)n.Length;

                    if(noteSleep >= sixteenthsToNextBarline)
                    {
                        Thread.Sleep(SixteenthNoteLengthInMs * sixteenthsToNextBarline);
                        noteSleep -= sixteenthsToNextBarline;

                        // we have a barline in the middle of this node, switch chords here

                        // last chord off
                        Note(false, lastChordOn, builder, outDevice);
                        currentSongPos += sixteenthsToNextBarline;

                        // if no the end of the song
                        if (currentSongPos < chords.Length * 16)
                        {
                            // this chord on
                            int newChord = chords[currentSongPos / 16];
                            Note(true, key + Scales.Major[newChord], builder, outDevice);
                            lastChordOn = key + Scales.Major[newChord];
                        }
                    }

                    if(noteSleep > 0)
                    {
                        Thread.Sleep(SixteenthNoteLengthInMs * noteSleep);
                        currentSongPos += noteSleep;
                    }

                    // turn off current note
                    Note(false, n.Id, builder, outDevice);
                }
                
                // turn last chord off
                Note(false, lastChordOn, builder, outDevice);
            }
        }
    }
}
