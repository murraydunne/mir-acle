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

        public MainFrame()
        {
            InitializeComponent();
        }

        private void HandleLoad(object sender, EventArgs e)
        {
            HandleGenerateClick(null, null);
        }

        private void HandleGenerateClick(object sender, EventArgs e)
        {
            int[] l = { 0, 4, 5, 3 };   //chords in intervals from key
            Note k = new Note(0);

            Generator g = new Generator(l, k);
            currentSong = g.Generate();

            pianoStaff.SetSong(currentSong);

            Invalidate();
        }

        private void HandlePlayClick(object sender, EventArgs e)
        {
            if (currentSong != null)
            {
                Player p = new Player();
                p.Play(currentSong);
            }
        }
    }
}
