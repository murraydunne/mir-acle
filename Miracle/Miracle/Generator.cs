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
    public class Generator
    {
        private static int[,] Scales =
        {
            {0,2,4,5,7,9,11 },  //major
            {0,2,3,5,7,8,10 }   //minor
        };

        public Note Key { get; set; }

        public int[] chords;

        public Generator(int[] c, Note k)
        {
            chords = c;
            Key = k;
        }

        public List<Note> Generate()
        {
            Random r = new Random();
            List<Note> output = new List<Note>();
            int nextPitch;
            int nextOctave;
            int nextLength;
            float overLap = 0;
            for(int i = 0; i<chords.Length; i++)
            {
                
                float barPos = overLap;
                while(barPos<4)
                {
                    //int nextRand = r.Next(7);                             //this gives a random note in the scale
                    int nextRand = r.Next(2) == 1 ? r.Next(3) * 2 : 7;      //this gives 0,2,4,7
                    nextPitch = (nextRand) % 7;
                    nextOctave = nextRand / 7;
                    nextLength = (int)Math.Pow(2.0, (double)r.Next(4)+1); // what do we say to whole notes? not today
                    output.Add(new Note((Key + 12*nextOctave + Scales[0,chords[i]] + Scales[0,nextPitch%7]).Id, (NoteLength)nextLength));
                    barPos += 4.0f / nextLength;
                }
                overLap = barPos - 4;
            }

            return output; 
        }

    }
}
