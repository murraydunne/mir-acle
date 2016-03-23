using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miracle
{
    public enum NoteLength
    {
        Sixteenth = 16,
        Eighth = 8,
        Quarter = 4,
        Half = 2,
        Whole = 1
    }

    class Note
    {
        public Note(NoteLength l = NoteLength.Quarter)
        {
            IsRest = true;
            Length = l;
        }
        public Note(int note, NoteLength l = NoteLength.Quarter)
        {
            IsRest = false;
            Id = note;
            Length = l;

        }

        public NoteLength Length { get; set; }
        public bool IsRest { get; private set; }
        public int Id { get; private set; } //id = 0 corresponds to A3
        public float Frequency
        {
            get
            {
                return (((2) ^ (1 / 12)) ^ Id) * 220; 
            }
        }

        public String getName()
        {
            String output = "";
            int test = Id % 12;
            switch (test)
            {
                case 0:
                    output += "A";
                    break;
                case 1:
                    output += "A#";
                    break;
                case 2:
                    output += "B";
                    break;
                case 3:
                    output += "C";
                    break;
                case 4:
                    output += "C#";
                    break;
                case 5:
                    output += "D";
                    break;
                case 6:
                    output += "D#";
                    break;
                case 7:
                    output += "E";
                    break;
                case 8:
                    output += "F";
                    break;
                case 9:
                    output += "F#";
                    break;
                case 10:
                    output += "G";
                    break;
                case 11:
                    output += "G#";
                    break;
            }

            output += (Id + 9) / 12 + 3;
         
            return output;
        }

        public static Note operator +(Note c1, int c2)
        {
            Note n = new Note();
            n.IsRest = c1.IsRest;
            n.Length = c1.Length;
            n.Id = c1.Id + c2;
            return c1;
        }

        public static Note operator -(Note c1, int c2)
        {
            Note n = new Note();
            n.IsRest = c1.IsRest;
            n.Length = c1.Length;
            n.Id = c1.Id - c2;
            return c1;
        }



    }
}
