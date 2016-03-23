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

        public Player()
        {
            SixteenthNoteLengthInMs = 208; // ~200 BPM
        }


        public void Play(List<Note> song)
        {
            using (OutputDevice outDevice = new OutputDevice(0))
            {
                ChannelMessageBuilder builder = new ChannelMessageBuilder();

                foreach(Note n in song)
                {
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
