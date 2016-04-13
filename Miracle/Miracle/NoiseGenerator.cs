using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Noise;



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
    public class NoiseGenerator : AbstractGenerator
    {

        public Note Key { get; set; }

        public int[] chords;

        public NoiseGenerator(int[] c, Note k)
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

        const int MaxNumNotes = 100;
        const float noiseFrequency = 4.0f;
        float[] pitchNoise = new float[MaxNumNotes];
        float[] lengthNoise = new float[MaxNumNotes];

        private void GenNoise()
        {
            OpenSimplexNoise noise = new OpenSimplexNoise(DateTime.Now.Millisecond);

            //pitch
            for(int depth = 0; depth < 6; depth++)
            {
                noise = new OpenSimplexNoise(DateTime.Now.Millisecond);
                int scaler = (int)Math.Pow(2, depth);
                for (int i = 0; i < MaxNumNotes; i++)
                {
                    pitchNoise[i] += (float)noise.Evaluate((((float)(i*scaler) / 10) * noiseFrequency))/scaler;
                }
            }
            //find max
            float m = 0;
            for(int i = 0;i<MaxNumNotes;i++)
            {
                if (Math.Abs(pitchNoise[i]) > m)
                {
                    m = Math.Abs(pitchNoise[i]);
                }
            }
            //normalize and make in range [0,1]
            for (int i = 0; i < MaxNumNotes; i++)
            {
                pitchNoise[i] = ((pitchNoise[i] / m)+1)/2;
                
            }



            //rhythm
            for (int depth = 0; depth < 6; depth++)
            {
                noise = new OpenSimplexNoise(DateTime.Now.Millisecond);
                int scaler = (int)Math.Pow(2, depth);
                for (int i = 0; i < MaxNumNotes; i++)
                {
                    lengthNoise[i] += (float)noise.Evaluate((((float)i * scaler / 10.0f) * noiseFrequency)) / (scaler*2);
                }
            }
            //find max
            m = 0;
            for (int i = 0; i < MaxNumNotes; i++)
            {
                if (Math.Abs(lengthNoise[i]) > m)
                {
                    m = Math.Abs(lengthNoise[i]);
                }
            }
            //normalize and make in range [0,1]
            for (int i = 0; i < MaxNumNotes; i++)
            {
                lengthNoise[i] = ((lengthNoise[i] / m) + 1)/2;
                Debug.WriteLine(lengthNoise[i]);
            }

        }

        public override List<Note> Generate()
        {
            GenNoise();
            OpenSimplexNoise noise = new OpenSimplexNoise(DateTime.Now.Millisecond);
            Random r = new Random();
            List<Note> output = new List<Note>();
            int nextPitch;
            int nextOctave;
            int nextLength;
            float iteration = 0;
            int overLap = 0;
          
            for (int i = 0; i < chords.Length; i++)
            {
                

                int barPos = overLap;
                while (barPos < 16)
                {
                    iteration = iteration + 1.0f;
                   // Debug.WriteLine((int)(Math.Abs(noise.Evaluate(iteration / 10.0f)) * 10));

                    //int nextNoise = (int)((noise.Evaluate(iteration / 10.0f)+1)*10);
                    int nextNoise = (int)(pitchNoise[(int)iteration]*10);
                    //int nextRand = r.Next(7);                             //this gives a random note in the scale
                    //int nextRand = r.Next(2) == 1 ? r.Next(3) * 2 : 7;      //this gives 0,2,4,7
                    //nextPitch = (nextRand) % 7;
                    nextPitch = (nextNoise) % 7;
                    //nextOctave = (nextRand / 7) * 12; //if nextrand exceeds 7, the modulus applied so we need to add an octave
                    nextOctave = (nextNoise / 7) * 12; //if nextrand exceeds 7, the modulus applied so we need to add an octave
                    //nextLength = (int)Math.Pow(2.0, (double)r.Next(3));
                    //nextLength = (int)Math.Pow(2.0, (int)(Math.Abs(noise.Evaluate(iteration/10.0f))*3));
                    nextLength = (int)Math.Pow(2.0, (int)(lengthNoise[(int)iteration]*3));
                   
                    if (barPos == 0 && Chance(70)) //if beginning of bar, use root sometimes
                    {
                        nextPitch = 0;
                    }
                    barPos += nextLength;
                    if (barPos > 16 || r.Next(6) > 3)
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
                                        Scales.AllScales[0, chords[i]] +   //goes to the root of the current chord
                                        Scales.AllScales[CurrentScale, nextPitch]).Id, //goes to the randomized note at that chord
                                        (NoteLength)nextLength));


                }
                overLap = barPos - 16;
            }

            return output;
        }

    }
}
