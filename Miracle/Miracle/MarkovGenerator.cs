using Accord.Statistics.Models.Markov;
using Accord.Statistics.Models.Markov.Learning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miracle
{
    public class MarkovGenerator : AbstractGenerator
    {
        private HiddenMarkovModel model;

        public MarkovGenerator(string trainingFile)
        {
            Note[] basis = new Loader().LoadMidiFile(trainingFile).ToArray();

            int[][] sequences = new int[basis.Length / 64][];
            for(int i = 0; i < basis.Length / 64; i++)
            {
                sequences[i] = new int[64];

                for(int j = 0; j < 64; j++)
                {
                    sequences[i][j] = basis[i + j].Id + 20;
                }
            }

            model = new HiddenMarkovModel(64, 50);

            BaumWelchLearning bwTeacher = new BaumWelchLearning(model) { Iterations = 10 };
            bwTeacher.Run(sequences);
        }

        public override List<Note> Generate()
        {
            int[] sample = model.Generate(64);

            List<Note> result = new List<Note>();

            foreach(int note in sample)
            {
                result.Add(new Note(note - 20, NoteLength.Sixteenth));
            }

            return result;
        }
    }
}
