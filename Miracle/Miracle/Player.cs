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

        public void Play(List<Note> song)
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

                playingThread = new Thread(new ParameterizedThreadStart(DoPlay));
                playingThread.Start(copyOfSong);
            }
        }

        public void Stop()
        {
            lock(playingLock)
            {
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

        private void DoPlay(object objSong)
        {
            List<Note> song = (List<Note>)objSong;

            using (OutputDevice outDevice = new OutputDevice(0))
            {
                ChannelMessageBuilder builder = new ChannelMessageBuilder();

                foreach (Note n in song)
                {
                    lock(playingLock)
                    {
                        if(stopPlayback)
                        {
                            break;
                        }
                    }

                    builder.Command = ChannelCommand.NoteOn;
                    builder.MidiChannel = 0;
                    builder.Data1 = n.Id + 45;
                    builder.Data2 = 127;
                    builder.Build();

                    outDevice.Send(builder.Result);

                    switch (n.Length)
                    {
                        case NoteLength.Sixteenth:
                            Thread.Sleep(SixteenthNoteLengthInMs);
                            break;
                        case NoteLength.Eighth:
                            Thread.Sleep(SixteenthNoteLengthInMs * 2);
                            break;
                        case NoteLength.Quarter:
                            Thread.Sleep(SixteenthNoteLengthInMs * 4);
                            break;
                        case NoteLength.Half:
                            Thread.Sleep(SixteenthNoteLengthInMs * 8);
                            break;
                        case NoteLength.Whole:
                            Thread.Sleep(SixteenthNoteLengthInMs * 16);
                            break;
                    }

                    builder.Command = ChannelCommand.NoteOff;
                    builder.Data2 = 0;
                    builder.Build();

                    outDevice.Send(builder.Result);
                }
            }
        }
    }
}
