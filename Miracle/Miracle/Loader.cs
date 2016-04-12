using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanford.Multimedia.Midi;

namespace Miracle
{
    public class Loader
    {
        private class NoteOnOff
        {
            public int Data1Number { get; set; }
            public int TicksOn { get; set; }
        }

        public List<Note> LoadMidiFile(string name)
        {
            Sequence file = null;
            try
            {
                file = new Sequence(name);
            }
            catch(Exception ex)
            {
                return null;
            }

            Track firstTrack = file[1];
            List<NoteOnOff> onOffs = new List<NoteOnOff>();

            bool[] isOn = new bool[256];
            int[] onAt = new int[256];

            IEnumerable<MidiEvent> events = firstTrack.Iterator();

            foreach (MidiEvent evt in firstTrack.Iterator())
            {
                if(evt.MidiMessage.MessageType == MessageType.Channel)
                {
                    ChannelMessage msg = (ChannelMessage)evt.MidiMessage;
                    
                    if(msg.Command == ChannelCommand.NoteOn && msg.Data2 > 0)
                    {
                        isOn[msg.Data1] = true;
                        onAt[msg.Data1] = evt.AbsoluteTicks;
                    }
                    else if(msg.Command == ChannelCommand.NoteOff || (msg.Command == ChannelCommand.NoteOn && msg.Data2 == 0))
                    {
                        if(isOn[msg.Data1])
                        {
                            int onFor = evt.AbsoluteTicks - onAt[msg.Data1];
                            onOffs.Add(new NoteOnOff() { Data1Number = msg.Data1, TicksOn = onFor });
                            isOn[msg.Data1] = false;
                        }
                    }
                }
            }

            int sixteenthNoteTicks = 10000;
            foreach(NoteOnOff onOff in onOffs)
            {
                if(onOff.TicksOn < sixteenthNoteTicks)
                {
                    sixteenthNoteTicks = onOff.TicksOn;
                }
            }

            List<Note> song = new List<Note>();

            foreach (NoteOnOff onOff in onOffs)
            {
                int noteId = onOff.Data1Number - 45;
                NoteLength length = NoteLength.Sixteenth;

                if(onOff.TicksOn >= sixteenthNoteTicks * 2)
                {
                    length = NoteLength.Eighth;
                }

                if (onOff.TicksOn >= sixteenthNoteTicks * 4)
                {
                    length = NoteLength.Quarter;
                }

                if (onOff.TicksOn >= sixteenthNoteTicks * 8)
                {
                    length = NoteLength.Half;
                }

                if (onOff.TicksOn >= sixteenthNoteTicks * 16)
                {
                    length = NoteLength.Whole;
                }

                song.Add(new Note(noteId, length));
            }

            return song;
        }
    }
}
