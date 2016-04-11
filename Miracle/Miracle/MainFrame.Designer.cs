namespace Miracle
{
    partial class MainFrame
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trainMarkovButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.keyBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.chordBox4 = new System.Windows.Forms.ComboBox();
            this.chordBox3 = new System.Windows.Forms.ComboBox();
            this.chordBox2 = new System.Windows.Forms.ComboBox();
            this.chordBox1 = new System.Windows.Forms.ComboBox();
            this.pianoStaff = new Miracle.PianoStaff();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pianoStaff);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.trainMarkovButton);
            this.splitContainer1.Panel2.Controls.Add(this.stopButton);
            this.splitContainer1.Panel2.Controls.Add(this.playButton);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.keyBox);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.generateButton);
            this.splitContainer1.Panel2.Controls.Add(this.chordBox4);
            this.splitContainer1.Panel2.Controls.Add(this.chordBox3);
            this.splitContainer1.Panel2.Controls.Add(this.chordBox2);
            this.splitContainer1.Panel2.Controls.Add(this.chordBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1223, 489);
            this.splitContainer1.SplitterDistance = 246;
            this.splitContainer1.TabIndex = 0;
            // 
            // trainMarkovButton
            // 
            this.trainMarkovButton.Location = new System.Drawing.Point(12, 170);
            this.trainMarkovButton.Name = "trainMarkovButton";
            this.trainMarkovButton.Size = new System.Drawing.Size(124, 23);
            this.trainMarkovButton.TabIndex = 12;
            this.trainMarkovButton.Text = "Train Markov Chain";
            this.trainMarkovButton.UseVisualStyleBackColor = true;
            this.trainMarkovButton.Click += new System.EventHandler(this.HandleMarkovTrainClick);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(96, 114);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 11;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.HandleStopClick);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(15, 114);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 10;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.HandlePlayClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Key:";
            // 
            // keyBox
            // 
            this.keyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyBox.FormattingEnabled = true;
            this.keyBox.Items.AddRange(new object[] {
            "A",
            "A#",
            "B",
            "C",
            "C#",
            "D",
            "D#",
            "E",
            "F",
            "F#",
            "G",
            "G#"});
            this.keyBox.Location = new System.Drawing.Point(46, 14);
            this.keyBox.Name = "keyBox";
            this.keyBox.Size = new System.Drawing.Size(121, 21);
            this.keyBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(393, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Chord 4:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Chord 3:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chord 2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chord 1:";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(15, 85);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.HandleGenerateClick);
            // 
            // chordBox4
            // 
            this.chordBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chordBox4.FormattingEnabled = true;
            this.chordBox4.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV",
            "V",
            "VI",
            "VII"});
            this.chordBox4.Location = new System.Drawing.Point(396, 58);
            this.chordBox4.Name = "chordBox4";
            this.chordBox4.Size = new System.Drawing.Size(121, 21);
            this.chordBox4.TabIndex = 3;
            // 
            // chordBox3
            // 
            this.chordBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chordBox3.FormattingEnabled = true;
            this.chordBox3.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV",
            "V",
            "VI",
            "VII"});
            this.chordBox3.Location = new System.Drawing.Point(269, 58);
            this.chordBox3.Name = "chordBox3";
            this.chordBox3.Size = new System.Drawing.Size(121, 21);
            this.chordBox3.TabIndex = 2;
            // 
            // chordBox2
            // 
            this.chordBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chordBox2.FormattingEnabled = true;
            this.chordBox2.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV",
            "V",
            "VI",
            "VII"});
            this.chordBox2.Location = new System.Drawing.Point(142, 58);
            this.chordBox2.Name = "chordBox2";
            this.chordBox2.Size = new System.Drawing.Size(121, 21);
            this.chordBox2.TabIndex = 1;
            // 
            // chordBox1
            // 
            this.chordBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chordBox1.FormattingEnabled = true;
            this.chordBox1.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV",
            "V",
            "VI",
            "VII"});
            this.chordBox1.Location = new System.Drawing.Point(15, 58);
            this.chordBox1.Name = "chordBox1";
            this.chordBox1.Size = new System.Drawing.Size(121, 21);
            this.chordBox1.TabIndex = 0;
            // 
            // pianoStaff
            // 
            this.pianoStaff.BackColor = System.Drawing.Color.White;
            this.pianoStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pianoStaff.Location = new System.Drawing.Point(0, 0);
            this.pianoStaff.Name = "pianoStaff";
            this.pianoStaff.NoteHeight = 10;
            this.pianoStaff.Size = new System.Drawing.Size(1223, 246);
            this.pianoStaff.TabIndex = 0;
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 489);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainFrame";
            this.Text = "Miracle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HandleClosed);
            this.Load += new System.EventHandler(this.HandleLoad);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private PianoStaff pianoStaff;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox keyBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox chordBox4;
        private System.Windows.Forms.ComboBox chordBox3;
        private System.Windows.Forms.ComboBox chordBox2;
        private System.Windows.Forms.ComboBox chordBox1;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button trainMarkovButton;
    }
}

