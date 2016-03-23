namespace Miracle
{
    partial class PianoStaff
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.scrollBar = new System.Windows.Forms.HScrollBar();
            this.SuspendLayout();
            // 
            // scrollBar
            // 
            this.scrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.scrollBar.Location = new System.Drawing.Point(0, 133);
            this.scrollBar.Name = "scrollBar";
            this.scrollBar.Size = new System.Drawing.Size(150, 17);
            this.scrollBar.TabIndex = 0;
            // 
            // PianoStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.scrollBar);
            this.DoubleBuffered = true;
            this.Name = "PianoStaff";
            this.Load += new System.EventHandler(this.HandleLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HandlePaint);
            this.Resize += new System.EventHandler(this.HandleResize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HScrollBar scrollBar;
    }
}
