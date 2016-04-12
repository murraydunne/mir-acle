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
        private int addToNote = 0;
        private HiddenMarkovModel model = null;

        public MarkovGenerator(string trainingFile)
        {
            List<Note> noteList = new Loader().LoadMidiFile(trainingFile);
            if(noteList == null)
            {
                return;
            }

            Note[] basis = noteList.ToArray();

            int minId = 1000;
            int maxId = -1000;

            for(int i = 0; i < basis.Length; i++)
            {
                if(basis[i].Id < minId)
                {
                    minId = basis[i].Id;
                }

                if(basis[i].Id > maxId)
                {
                    maxId = basis[i].Id;
                }
            }

            int range = maxId - minId;
            addToNote = -minId;

            int[][] sequences = new int[basis.Length / 64][];
            for(int i = 0; i < basis.Length / 64; i++)
            {
                sequences[i] = new int[64];

                for(int j = 0; j < 64; j++)
                {
                    Note basisNote = basis[i + j];
                    int noteRepresentation = ((basisNote.Id + addToNote) * 5) + (int)Math.Log((int)basisNote.Length, 2.0);

                    sequences[i][j] = noteRepresentation;
                }
            }

            model = new HiddenMarkovModel(64, range * 5);

            BaumWelchLearning bwTeacher = new BaumWelchLearning(model) { Iterations = 10 };
            bwTeacher.Run(sequences);
        }

        public override List<Note> Generate()
        {
            if(model == null)
            {
                return new List<Note>();
            }

            int[] sample = model.Generate(64);

            List<Note> result = new List<Note>();

            foreach(int note in sample)
            {
                int noteLength = (int)Math.Pow(2.0, note % 5);
                int noteId = (note / 5) - addToNote;

                result.Add(new Note(noteId, (NoteLength)noteLength));
            }

            return result;
        }
    }
}
