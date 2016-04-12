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

            generatorBox.SelectedIndex = 0;
            scaleBox.SelectedIndex = 0;
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

            AbstractGenerator[] generators = { new Generator(l, k), new NoiseGenerator(l, k), markovGenerator, new RiffGenerator(l, k) };
            AbstractGenerator g;
            
            if (generators[generatorBox.SelectedIndex] == markovGenerator)
            {
                if (markovGenerator != null)
                {
                    g = markovGenerator;

                } else
                {
                    g = null;
                }
            } else
            {
                g = generators[generatorBox.SelectedIndex];
                g.CurrentScale = scaleBox.SelectedIndex;
                
            }

            //NoiseGenerator g = new NoiseGenerator(l, k);
            if(g!=null)
            {
                currentSong = g.Generate();

            }

            //currentSong = new Loader().LoadMidiFile("D:/Downloads/cs1-1pre.mid");

            //currentSong = new List<Note>();
            //currentSong.Add(new Note(0));
            //currentSong.Add(new Note(4));
            //currentSong.Add(new Note(7));
            //currentSong.Add(new Note(12));

            pianoStaff.SetSong(currentSong);
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
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Midi files (*.mid;*.midi)|*.mid;*.midi|All files (*.*)|*.*";
            ofd.Multiselect = false;

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                markovGenerator = new MarkovGenerator(ofd.FileName);
            }
        }

        private void HandleUpClick(object sender, EventArgs e)
        {
            pianoStaff.SetSelectedNote(pianoStaff.Selection.Id + 1, pianoStaff.Selection.Length);
        }

        private void HandleRightClick(object sender, EventArgs e)
        {
            pianoStaff.SelectedIndex++;
        }

        private void HandleLeftClick(object sender, EventArgs e)
        {
            pianoStaff.SelectedIndex--;
        }

        private void HandleDownClick(object sender, EventArgs e)
        {
            pianoStaff.SetSelectedNote(pianoStaff.Selection.Id - 1, pianoStaff.Selection.Length);
        }

        private void HandleLongerClick(object sender, EventArgs e)
        {
            int startLength = (int)pianoStaff.Selection.Length;
            NoteLength newLength = pianoStaff.Selection.Length;
            if(startLength < 16)
            {
                newLength = (NoteLength)(startLength * 2);
            }

            pianoStaff.SetSelectedNote(pianoStaff.Selection.Id, newLength);
        }

        private void HandleShorterClick(object sender, EventArgs e)
        {
            int startLength = (int)pianoStaff.Selection.Length;
            NoteLength newLength = pianoStaff.Selection.Length;
            if (startLength > 1)
            {
                newLength = (NoteLength)(startLength / 2);
            }

            pianoStaff.SetSelectedNote(pianoStaff.Selection.Id, newLength);
        }

        private void HandleKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                HandleUpClick(sender, e);
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                HandleDownClick(sender, e);
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                HandleLeftClick(sender, e);
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                HandleRightClick(sender, e);
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.OemMinus)
            {
                HandleShorterClick(sender, e);
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Oemplus)
            {
                HandleLongerClick(sender, e);
                e.SuppressKeyPress = true;
            }
        }
    }
}
