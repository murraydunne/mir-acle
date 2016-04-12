using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miracle
{
    public partial class MainFrame : Form
    {
        List<Note> currentSong = null;
        Player currentPlayer = null;
        MarkovGenerator markovGenerator = null;

        public MainFrame()
        {
            InitializeComponent();

            keyBox.SelectedIndex = 0;
            chordBox1.SelectedIndex = 0;
            chordBox2.SelectedIndex = 0;
            chordBox3.SelectedIndex = 0;
            chordBox4.SelectedIndex = 0;

            currentPlayer = new Player();
        }

        private void HandleLoad(object sender, EventArgs e)
        {
            HandleGenerateClick(null, null);
        }

        private void HandleGenerateClick(object sender, EventArgs e)
        {
            int[] l = { chordBox1.SelectedIndex, chordBox2.SelectedIndex, chordBox3.SelectedIndex, chordBox4.SelectedIndex };
            Note k = new Note(keyBox.SelectedIndex);
            
            IGenerator g = new RiffGenerator(l, k);
            if (markovGenerator != null)
            {
                g = markovGenerator;
            }

            //NoiseGenerator g = new NoiseGenerator(l, k);
            currentSong = g.Generate();

            //currentSong = new Loader().LoadMidiFile("D:/Downloads/cs1-1pre.mid");

            //currentSong = new List<Note>();
            //currentSong.Add(new Note(0));
            //currentSong.Add(new Note(4));
            //currentSong.Add(new Note(7));
            //currentSong.Add(new Note(12));

            pianoStaff.SetSong(currentSong);

            Invalidate();
        }

        private void HandlePlayClick(object sender, EventArgs e)
        {
            if (currentSong != null)
            {
                if (currentPlayer.IsPlaying)
                {
                    currentPlayer.Stop();
                }

                int key = keyBox.SelectedIndex - 12;
                List<int> chords = new List<int>();
                chords.Add(chordBox1.SelectedIndex);
                chords.Add(chordBox2.SelectedIndex);
                chords.Add(chordBox3.SelectedIndex);
                chords.Add(chordBox4.SelectedIndex);

                currentPlayer.Play(currentSong, key, chords);
            }
        }

        private void HandleStopClick(object sender, EventArgs e)
        {
            if (currentPlayer.IsPlaying)
            {
                currentPlayer.Stop();
            }
        }

        private void HandleClosed(object sender, FormClosedEventArgs e)
        {
            if (currentPlayer.IsPlaying)
            {
                currentPlayer.Stop();
            }
        }

        private void HandleMarkovTrainClick(object sender, EventArgs e)
        {
            if(markovGenerator == null)
            {
                markovGenerator = new MarkovGenerator("D:/Downloads/cs1-1pre.mid");
            }
        }
    }
}
