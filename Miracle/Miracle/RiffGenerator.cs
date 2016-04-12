using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miracle
{
    class RiffGenerator : AbstractGenerator
    {

        public Note Key { get; set; }
        public int[] chords;

        public RiffGenerator(int[] c, Note k)
        {
            chords = c;
            Key = k;
        }
        public const int NumRiffs = 40;

        public enum NoteDefs : byte { C4 =3,Db4,D4,Eb4,E4,F4,Gb4,G4,Ab4, A4, Bb4,B4, C5, Db5, D5, Eb5, E5, F5, Gb5, G5,Ab5,A5, Bb5,B5,C6 };

        public NoteDefs[,] Riffs = {
            { NoteDefs.Eb4, NoteDefs.D4, NoteDefs.A4, NoteDefs.F4, NoteDefs.E4, NoteDefs.C5, NoteDefs.A4, NoteDefs.A4 }, /* 0 */
            {  NoteDefs.F4, NoteDefs.A4, NoteDefs.Eb5, NoteDefs.D5, NoteDefs.E4, NoteDefs.A4, NoteDefs.C5, NoteDefs.A4 }, /* 1 */
            {  NoteDefs.Ab4, NoteDefs.A4, NoteDefs.A4, NoteDefs.G5, NoteDefs.G5, NoteDefs.Eb5, NoteDefs.C5, NoteDefs.E5 }, /* 2 */
            {  NoteDefs.Ab4, NoteDefs.A4, NoteDefs.B4, NoteDefs.C5, NoteDefs.Eb5, NoteDefs.E5, NoteDefs.Ab5, NoteDefs.A5 }, /* 3 */
            {  NoteDefs.A4, NoteDefs.Bb4, NoteDefs.B4, NoteDefs.C5, NoteDefs.Db5, NoteDefs.D5, NoteDefs.Eb5, NoteDefs.E5 }, /* 4 */
            {  NoteDefs.A4, NoteDefs.Bb4, NoteDefs.B4, NoteDefs.C5, NoteDefs.E5, NoteDefs.Eb5, NoteDefs.D5, NoteDefs.C5 }, /* 5 */
            {  NoteDefs.A4, NoteDefs.B4, NoteDefs.C5, NoteDefs.A4, NoteDefs.B4, NoteDefs.C5, NoteDefs.D5, NoteDefs.B4 }, /* 6 */
            {  NoteDefs.A4, NoteDefs.B4, NoteDefs.C5, NoteDefs.D5, NoteDefs.Eb5, NoteDefs.E5, NoteDefs.Eb5, NoteDefs.C5 }, /* 7 */
            { NoteDefs.A4, NoteDefs.C5, NoteDefs.D5, NoteDefs.Eb5, NoteDefs.Gb5, NoteDefs.Ab5, NoteDefs.A5, NoteDefs.C6 }, /* 8 Pat Metheny */
            {  NoteDefs.A4, NoteDefs.C5, NoteDefs.Eb5, NoteDefs.B4, NoteDefs.D5, NoteDefs.F5, NoteDefs.Eb5, NoteDefs.C5 }, /* 9 */
            {  NoteDefs.A4, NoteDefs.C5, NoteDefs.E5, NoteDefs.G5, NoteDefs.B5, NoteDefs.A5, NoteDefs.G5, NoteDefs.E5 }, /* 10 */
            {  NoteDefs.A4, NoteDefs.C5, NoteDefs.E5, NoteDefs.A5, NoteDefs.G5, NoteDefs.Eb5, NoteDefs.C5, NoteDefs.A4 }, /* 11 */
            {  NoteDefs.B4, NoteDefs.A4, NoteDefs.B4, NoteDefs.C5, NoteDefs.B4, NoteDefs.A4, NoteDefs.B4, NoteDefs.C5 }, /* 12 */
            {  NoteDefs.B4, NoteDefs.A4, NoteDefs.B4, NoteDefs.C5, NoteDefs.B4, NoteDefs.C5, NoteDefs.B4, NoteDefs.A4 }, /* 13 */
            {  NoteDefs.B4, NoteDefs.A4, NoteDefs.B4, NoteDefs.C5, NoteDefs.D5, NoteDefs.C5, NoteDefs.D5, NoteDefs.Eb5 }, /* 14 */
            {  NoteDefs.C5, NoteDefs.Ab4, NoteDefs.A4, NoteDefs.G5, NoteDefs.F5, NoteDefs.Gb5, NoteDefs.Eb5, NoteDefs.E5 }, /* 15 Marty Cutler */
            {  NoteDefs.C5, NoteDefs.D5, NoteDefs.C5, NoteDefs.B4, NoteDefs.C5, NoteDefs.B4, NoteDefs.A4, NoteDefs.A4 }, /* 16 */
            {  NoteDefs.C5, NoteDefs.D5, NoteDefs.Eb5, NoteDefs.C5, NoteDefs.D5, NoteDefs.Eb5, NoteDefs.F5, NoteDefs.D5 }, /* 17 */
            {  NoteDefs.D5, NoteDefs.C5, NoteDefs.A4, NoteDefs.C5, NoteDefs.E5, NoteDefs.Eb5, NoteDefs.D5, NoteDefs.C5 }, /* 18 */
            {  NoteDefs.D5, NoteDefs.C5, NoteDefs.D5, NoteDefs.Eb5, NoteDefs.D5, NoteDefs.C5, NoteDefs.D5, NoteDefs.Eb5 }, /* 19 */
            {  NoteDefs.D5, NoteDefs.Eb5, NoteDefs.E5, NoteDefs.F5, NoteDefs.Gb5, NoteDefs.G5, NoteDefs.Ab5, NoteDefs.A5 }, /* 20 */
            {  NoteDefs.D5, NoteDefs.Eb5, NoteDefs.G5, NoteDefs.Eb5, NoteDefs.D5, NoteDefs.C5, NoteDefs.B4, NoteDefs.C5 }, /* 21 Charlie Keagle */
            {  NoteDefs.D5, NoteDefs.Eb5, NoteDefs.A5, NoteDefs.D5, NoteDefs.D5, NoteDefs.C5, NoteDefs.A4, NoteDefs.E4 }, /* 22 */
            {  NoteDefs.D5, NoteDefs.E5, NoteDefs.G5, NoteDefs.E5, NoteDefs.C5, NoteDefs.C5, NoteDefs.D5, NoteDefs.A5 }, /* 23 Lyle Mays/Steve Cantor */
            {  NoteDefs.Eb5, NoteDefs.D5, NoteDefs.Eb5, NoteDefs.D5, NoteDefs.D5, NoteDefs.C5, NoteDefs.A4, NoteDefs.A4 }, /* 24 */
            {  NoteDefs.Eb5, NoteDefs.D5, NoteDefs.Eb5, NoteDefs.F5, NoteDefs.Eb5, NoteDefs.D5, NoteDefs.C5, NoteDefs.B4 }, /* 25 */
            {  NoteDefs.Eb5,  NoteDefs.E5, NoteDefs.D5, NoteDefs.C5, NoteDefs.B4, NoteDefs.A4, NoteDefs.Ab4, NoteDefs.A4 }, /* 26 Richie Shulberg */
            {  NoteDefs.Eb5,  NoteDefs.E5, NoteDefs.A5, NoteDefs.C5, NoteDefs.B4, NoteDefs.E5, NoteDefs.A4, NoteDefs.A4 }, /* 27 */
            {  NoteDefs.Eb5,  NoteDefs.Gb5, NoteDefs.E5, NoteDefs.A4, NoteDefs.B4, NoteDefs.D5, NoteDefs.C5, NoteDefs.E4 }, /* 28 Django Rheinhart */
            {  NoteDefs.E5,  NoteDefs.A4, NoteDefs.C5, NoteDefs.Ab4, NoteDefs.B4, NoteDefs.G4, NoteDefs.Gb4, NoteDefs.E4 }, /* 29 David Levine */
            {  NoteDefs.E5,  NoteDefs.Eb5, NoteDefs.D5, NoteDefs.C5, NoteDefs.B4, NoteDefs.C5, NoteDefs.D5, NoteDefs.F5 }, /* 30 */
            {  NoteDefs.G5,  NoteDefs.E5, NoteDefs.D5, NoteDefs.B4, NoteDefs.Eb5, NoteDefs.Eb5, NoteDefs.C5, NoteDefs.A4 }, /* 31 */
            {  NoteDefs.G5,  NoteDefs.E5, NoteDefs.D5, NoteDefs.Gb5, NoteDefs.C5, NoteDefs.C5, NoteDefs.A4, NoteDefs.A4 }, /* 32 Mike Cross */
            {  NoteDefs.Ab5,  NoteDefs.A5, NoteDefs.Ab5, NoteDefs.A5, NoteDefs.Ab5, NoteDefs.A5, NoteDefs.Ab5, NoteDefs.A5 }, /* 33 Django Rheinhart */
            {  NoteDefs.A5,  NoteDefs.E5, NoteDefs.C5, NoteDefs.G4, NoteDefs.C5, NoteDefs.E5, NoteDefs.A5, NoteDefs.A5 }, /* 34 Django Rheinhart */
            {  NoteDefs.A5,  NoteDefs.E5, NoteDefs.C5, NoteDefs.A4, NoteDefs.G5, NoteDefs.Eb5, NoteDefs.C5, NoteDefs.A4 }, /* 35 */
            {  NoteDefs.A5, NoteDefs.B5, NoteDefs.G5, NoteDefs.E5, NoteDefs.F5, NoteDefs.Gb5, NoteDefs.G5, NoteDefs.Ab5 }, /* 36 */
            {  NoteDefs.B5, NoteDefs.C6, NoteDefs.A5, NoteDefs.E5, NoteDefs.G5, NoteDefs.B5, NoteDefs.A5, NoteDefs.A5 }, /* 37 */
            {  NoteDefs.B5, NoteDefs.B5, NoteDefs.C6, NoteDefs.E5, NoteDefs.Ab5, NoteDefs.B5, NoteDefs.A5, NoteDefs.C5 }, /* 38 Django Rheinhart */
            {  NoteDefs.C6, NoteDefs.B5, NoteDefs.A5, NoteDefs.G5, NoteDefs.Gb5, NoteDefs.E5, NoteDefs.Eb5, NoteDefs.C5 } /* 39 */
        };  
        
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
            for (int i = 0; i < chords.Length; i++)
            {

                int barPos = overLap;
                while (barPos < 16)
                {
                    int nextRand = r.Next(7);                             //this gives a random note in the scale
                    //int nextRand = r.Next(2) == 1 ? r.Next(3) * 2 : 7;      //this gives 0,2,4,7
                    nextPitch = (nextRand) % 7;
                    nextOctave = (nextRand / 7) * 12; //if nextrand exceeds 7, the modulus applied so we need to add an octave
                  
                    int nextRiff = r.Next(40);
                    for (int ri = 0; ri < 8; ri++)
                    {
                        nextLength = (int)Math.Pow(2.0, (double)r.Next(3));
                        if (barPos == 0 && Chance(70)) //if beginning of bar, use root sometimes
                        {
                            nextPitch = 0;
                        }
                        barPos += nextLength;
                        if (barPos > 16 || Chance(50)) //if overlapping the bar, always shorten the note, sometimes cut to the quarternote anyways
                        {
                            while (barPos % 4 != 0 && barPos % 4 != nextLength && nextLength != 1)
                            {
                                barPos -= nextLength;
                                nextLength = nextLength >> 1;
                                barPos += nextLength;
                            }
                        }

                        if(ri != 7)
                        {
                            if (Riffs[nextRiff, ri + 1] > Riffs[nextRiff, ri] && nextLength != 1 && Chance(70))
                            {
                                nextLength = 1;
                            }

                        }


                        output.Add(new Note((Key +
                                            Scales.AllScales[0, chords[i]] +   //goes to the root of the current chord
                                            (int)Riffs[nextRiff,ri]).Id, //goes to the randomized note at that chord
                                            (NoteLength)nextLength));

                    }
                }
                overLap = barPos - 16;
            }

            return output;
        }
    }
}
