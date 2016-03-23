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

        public PianoStaff()
        {
            InitializeComponent();
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

            DrawNote(g, 50, yOffset, 18, false, true, 0);
        }

        private void DrawNote(Graphics g, int x, int topOfStaff, int halfStepsDownFromAboveTopLine, bool hollow, bool stem, int numFlags)
        {
            int y = topOfStaff - noteHeight + (halfStepsDownFromAboveTopLine * (noteHeight / 2));
            bool stepUp = false;

            if(halfStepsDownFromAboveTopLine <= 5 || (halfStepsDownFromAboveTopLine >= 11 && halfStepsDownFromAboveTopLine <= 16))
            {
                // stem down (on the left)
                g.DrawLine(Pens.Black, x, y + (noteHeight / 2), x, y + (noteHeight / 2) + noteHeight * 3);
            }
            else
            {
                // stem up (on the right)
                stepUp = true;
                g.DrawLine(Pens.Black, x + noteHeight, y + (noteHeight / 2), x + noteHeight, y + (noteHeight / 2) - noteHeight * 3);
            }

            for(int i = 0; i < numFlags; i++)
            {

            }

            if(hollow)
            {
                g.DrawEllipse(Pens.Black, x, y, noteHeight, noteHeight);
            }
            else
            {
                g.FillEllipse(Brushes.Black, x, y, noteHeight, noteHeight);
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
