using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miracle
{
    public partial class PianoStaff : UserControl
    {
        private bool loaded = false;
        private int scrollDistance = 0;
        private List<Note> song = null;

        public PianoStaff()
        {
            InitializeComponent();
        }

        public void SetSong(List<Note> song)
        {
            this.song = song;
            Invalidate();
        }

        private void HandlePaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int staffHeight = noteHeight * 10;
            int yOffset = (Height - staffHeight - scrollBar.Height) / 2;
            int xOffset = Math.Max(-scrollDistance + 10, 0);

            for(int i = 0; i < 11; i++)
            {
                if(i != 5)
                {
                    g.DrawLine(Pens.Black, xOffset, yOffset + i * noteHeight, Width, yOffset + i * noteHeight);
                }
            }

            // proceed only if we have a song
            if(song == null)
            {
                return;
            }

            int currentPoitionIn16ths = 0;
            int sixteenthXInterval = 15;
            int barlineSpace = 0;

            foreach(Note n in song)
            {
                int noteX = (currentPoitionIn16ths + barlineSpace) * sixteenthXInterval + 27;
                int halfstepsDown = 20 - n.GetOctave() * 7 - n.GetStaffPosition();
                int deltaSixteenths = 0;

                switch(n.Length)
                {
                    case NoteLength.Sixteenth:
                        DrawNote(g, noteX, yOffset, halfstepsDown, false, true, 2, n.IsSharp());
                        deltaSixteenths = 1;
                        break;
                    case NoteLength.Eighth:
                        DrawNote(g, noteX, yOffset, halfstepsDown, false, true, 1, n.IsSharp());
                        deltaSixteenths = 2;
                        break;
                    case NoteLength.Quarter:
                        DrawNote(g, noteX, yOffset, halfstepsDown, false, true, 0, n.IsSharp());
                        deltaSixteenths = 4;
                        break;
                    case NoteLength.Half:
                        DrawNote(g, noteX, yOffset, halfstepsDown, true, true, 0, n.IsSharp());
                        deltaSixteenths = 8;
                        break;
                    case NoteLength.Whole:
                        DrawNote(g, noteX, yOffset, halfstepsDown, true, false, 0, n.IsSharp());
                        deltaSixteenths = 16;
                        break;
                }

                if(currentPoitionIn16ths / 16 < (currentPoitionIn16ths + deltaSixteenths) / 16)
                {
                    barlineSpace++;
                }

                currentPoitionIn16ths += deltaSixteenths;
            }
            
            // draw barlines
            for(int i = 0; i < currentPoitionIn16ths + barlineSpace; i += 17)
            {
                int barlineX = 18 + i * sixteenthXInterval;
                g.DrawLine(Pens.Black, barlineX, yOffset, barlineX, yOffset + staffHeight);
            }
        }

        private void DrawNote(Graphics g, int x, int topOfStaff, int halfStepsDownFromAboveTopLine, bool hollow, bool stem, int numFlags, bool isSharp)
        {
            int y = topOfStaff - noteHeight + (halfStepsDownFromAboveTopLine * (noteHeight / 2));
            bool stemUp = false;

            if(stem)
            {
                if (halfStepsDownFromAboveTopLine <= 5 || (halfStepsDownFromAboveTopLine >= 11 && halfStepsDownFromAboveTopLine <= 16))
                {
                    // stem down (on the left)
                    g.DrawLine(Pens.Black, x, y + (noteHeight / 2), x, y + (noteHeight / 2) + noteHeight * 3);
                }
                else
                {
                    // stem up (on the right)
                    stemUp = true;
                    g.DrawLine(Pens.Black, x + noteHeight, y + (noteHeight / 2), x + noteHeight, y + (noteHeight / 2) - noteHeight * 3);
                }

                // flags for 8th and 16th
                for (int i = 0; i < numFlags; i++)
                {
                    if (stemUp)
                    {
                        g.DrawLine(Pens.Black, x + noteHeight, y + (noteHeight / 2) - noteHeight * (-i + 3), x + noteHeight + noteHeight, y + (noteHeight / 2) - noteHeight * (-i + 2));
                    }
                    else
                    {
                        g.DrawLine(Pens.Black, x, y + (noteHeight / 2) + noteHeight * (-i + 3), x + noteHeight, y + (noteHeight / 2) + noteHeight * (-i + 2));
                    }
                }
            }

            if(hollow)
            {
                g.DrawEllipse(Pens.Black, x, y, noteHeight, noteHeight);
            }
            else
            {
                g.FillEllipse(Brushes.Black, x, y, noteHeight, noteHeight);
            }

            if(isSharp)
            {
                g.DrawLine(Pens.Black, x - 10, y + 4, x - 2, y + 2);
                g.DrawLine(Pens.Black, x - 10, y + 8, x - 2, y + 6);

                g.DrawLine(Pens.Black, x - 8, y + 11, x - 8, y - 1);
                g.DrawLine(Pens.Black, x - 4, y + 11, x - 4, y - 1);
            }
        }

        private void HandleLoad(object sender, EventArgs e)
        {
            loaded = true;
        }
        
        private void HandleResize(object sender, EventArgs e)
        {
            if(loaded)
            {
                Invalidate();
            }
        }

        private int noteHeight = 10;
        public int NoteHeight
        {
            get
            {
                return noteHeight;
            }
            set
            {
                if (value < 1)
                {
                    throw new InvalidOperationException("Cannot set note height to value less than 1.");
                }

                noteHeight = value;

                if(loaded)
                {
                    Invalidate();
                }
            }
        }
    }
}
