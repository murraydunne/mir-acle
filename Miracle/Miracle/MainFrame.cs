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

        public MainFrame()
        {
            InitializeComponent();
            currentPlayer = new Player();
        }

        private void HandleLoad(object sender, EventArgs e)
        {
            HandleGenerateClick(null, null);
        }

        private void HandleGenerateClick(object sender, EventArgs e)
        {
            int[] l = { 0, 4, 5, 3 };   //chords in intervals from key
            Note k = new Note(0);

            IGenerator g = new MarkovGenerator(); // new Generator(l, k);
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

                currentPlayer.Play(currentSong);
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
    }
}
