using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/*
Usage:

            int[] l = { 0, 0, 4, 0 };   //chords in intervals from key
            Note k = new Note(0);

            Generator g = new Generator(l, k);
            List<Note> song = g.Generate();

            foreach (Note n in song)
            {
                Debug.WriteLine(n.getName());
                Debug.WriteLine(n.Id);
            }
*/

namespace Miracle
{
    public class Generator : AbstractGenerator
    {
      

        public Note Key { get; set; }

        public int[] chords;

        public Generator(int[] c, Note k)
        {
            chords = c;
            Key = k;
        }

        private bool Chance(int c)
        {
            Random r = new Random();
            if (r.Next(100) < c)
            {
                return true;
            }
            return false;
        }

        public override List<Note> Generate()
        {
            Random r = new Random();
            List<Note> output = new List<Note>();
            int nextPitch;
            int nextOctave;
            int nextLength;
            int overLap = 0;
            for(int i = 0; i<chords.Length; i++)
            {
                
                int barPos = overLap;
                while(barPos<16)
                {
                    int nextRand = r.Next(7);                             //this gives a random note in the scale
                    //int nextRand = r.Next(2) == 1 ? r.Next(3) * 2 : 7;      //this gives 0,2,4,7
                    nextPitch = (nextRand) % 7;
                    nextOctave = (nextRand / 7)*12; //if nextrand exceeds 7, the modulus applied so we need to add an octave
                    nextLength = (int)Math.Pow(2.0, (double)r.Next(3));
                    if (barPos == 0 && Chance(70)) //if beginning of bar, use root sometimes
                    {
                        nextPitch = 0;
                    }
                    barPos += nextLength;
                    if(barPos > 16 || Chance(50)) //if overlapping the bar, always shorten the note, sometimes cut to the quarternote anyways
                    {
                        while (barPos % 4 != 0 && barPos % 4 != nextLength && nextLength != 1)
                        {
                            barPos -= nextLength;
                            nextLength = nextLength >> 1;
                            barPos += nextLength;
                        }
                    }

                    
                    output.Add(new Note((Key + 
                                        nextOctave +            //goes up an octive if necessary
                                        Scales.AllScales[0,chords[i]] +   //goes to the root of the current chord
                                        Scales.AllScales[0,nextPitch]).Id, //goes to the randomized note at that chord
                                        (NoteLength)nextLength));
                    

                }
                overLap = barPos - 16;
            }

            return output; 
        }

    }
}
