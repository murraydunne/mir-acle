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
        public List<Note> LoadMidiFile(string name)
        {
            Sequence file = new Sequence(name);
            Track firstTrack = file[1];

            List<Note> song = new List<Note>();

            foreach(MidiEvent evt in firstTrack.Iterator())
            {
                if(evt.MidiMessage.MessageType == MessageType.Channel)
                {
                    ChannelMessage msg = (ChannelMessage)evt.MidiMessage;
                    
                    if(msg.Command == ChannelCommand.NoteOn)
                    {
                        song.Add(new Note(msg.Data1 - 45, NoteLength.Sixteenth));
                    }
                }
            }

            return song;
        }
    }
}
