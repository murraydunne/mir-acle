using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miracle
{
    public enum NoteLength
    {
        Sixteenth = 1,
        Eighth = 2,
        DottedEighth = 3,
        Quarter = 4,
        DottedQuarter = 6,
        Half = 8,
        Whole = 16
    }

    public class Note
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

        public String GetName()
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

        public bool IsSharp()
        {
            int test = Id % 12;
            if (test % 12 == 1 || test % 12 == 4 || test % 12 == 6 || test % 12 == 9 || test % 12 == 11)
            {
                return true;
            }
            return false;
        }

        public int GetStaffPosition()
        {
            int output = 0;
            int test = Id % 12;
            switch (test)
            {
                case 0:
                    output = 0; //a
                    break;
                case 1:
                    output = 0; //a#
                    break;
                case 2:
                    output = 1; //b
                    break;
                case 3:
                    output = 2; //c
                    break;
                case 4:
                    output = 2; //c#
                    break;
                case 5:
                    output = 3; //d
                    break;
                case 6:
                    output = 3; //d#
                    break;
                case 7:
                    output = 4; //e
                    break;
                case 8:
                    output = 5; //f
                    break;
                case 9:
                    output = 5; //f#
                    break;
                case 10:
                    output = 6; //g
                    break;
                case 11:
                    output = 6; //g#
                    break;
            }
            return output;
        }

        public int GetOctave()
        {
            return (int)(Id / 12);
        }

        public static Note operator +(Note c1, int c2)
        {
            Note n = new Note();
            n.IsRest = c1.IsRest;
            n.Length = c1.Length;
            n.Id = c1.Id + c2;
            return n;
        }

        public static Note operator -(Note c1, int c2)
        {
            Note n = new Note();
            n.IsRest = c1.IsRest;
            n.Length = c1.Length;
            n.Id = c1.Id - c2;
            return n;
        }



    }
}
