namespace cellular_automaton
{
    partial class GOLform
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.choseThathChitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dAutomatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameOfLifeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.emptyMeshButton = new System.Windows.Forms.Button();
            this.grainGrowthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(21, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(601, 601);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.choseThathChitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(797, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // choseThathChitToolStripMenuItem
            // 
            this.choseThathChitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dAutomatToolStripMenuItem,
            this.gameOfLifeToolStripMenuItem,
            this.grainGrowthToolStripMenuItem});
            this.choseThathChitToolStripMenuItem.Name = "choseThathChitToolStripMenuItem";
            this.choseThathChitToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.choseThathChitToolStripMenuItem.Text = "Choose program";
            // 
            // dAutomatToolStripMenuItem
            // 
            this.dAutomatToolStripMenuItem.Name = "dAutomatToolStripMenuItem";
            this.dAutomatToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.dAutomatToolStripMenuItem.Text = "1D Automata";
            this.dAutomatToolStripMenuItem.Click += new System.EventHandler(this.DAutomatToolStripMenuItem_Click);
            // 
            // gameOfLifeToolStripMenuItem
            // 
            this.gameOfLifeToolStripMenuItem.Name = "gameOfLifeToolStripMenuItem";
            this.gameOfLifeToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.gameOfLifeToolStripMenuItem.Text = "Game of life";
            // 
            // sizeTextBox
            // 
            this.sizeTextBox.Location = new System.Drawing.Point(663, 189);
            this.sizeTextBox.Name = "sizeTextBox";
            this.sizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.sizeTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(699, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Size";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(634, 458);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(628, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Random mesh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.randomMeshButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(715, 458);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 10;
            this.stopButton.Text = "STOP";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(663, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Stan początkowy";
            // 
            // emptyMeshButton
            // 
            this.emptyMeshButton.Location = new System.Drawing.Point(722, 258);
            this.emptyMeshButton.Name = "emptyMeshButton";
            this.emptyMeshButton.Size = new System.Drawing.Size(75, 23);
            this.emptyMeshButton.TabIndex = 11;
            this.emptyMeshButton.Text = "Empty mesh";
            this.emptyMeshButton.UseVisualStyleBackColor = true;
            this.emptyMeshButton.Click += new System.EventHandler(this.EmptyMeshButton_Click);
            // 
            // grainGrowthToolStripMenuItem
            // 
            this.grainGrowthToolStripMenuItem.Name = "grainGrowthToolStripMenuItem";
            this.grainGrowthToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grainGrowthToolStripMenuItem.Text = "Grain growth";
            this.grainGrowthToolStripMenuItem.Click += new System.EventHandler(this.GrainGrowthToolStripMenuItem_Click);
            // 
            // GOLform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(797, 661);
            this.Controls.Add(this.emptyMeshButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sizeTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GOLform";
            this.Text = "Game of life";
            this.Load += new System.EventHandler(this.GOLform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem choseThathChitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dAutomatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameOfLifeToolStripMenuItem;
        private System.Windows.Forms.TextBox sizeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button emptyMeshButton;
        private System.Windows.Forms.ToolStripMenuItem grainGrowthToolStripMenuItem;
    }
}