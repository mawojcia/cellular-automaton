namespace cellular_automaton
{
    partial class Form1
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ruleTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chooseThatShitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dAutomataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameOfLifeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grainGrowthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Ivory;
            this.pictureBox2.Location = new System.Drawing.Point(12, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(600, 600);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(644, 145);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(100, 20);
            this.widthTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(678, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width";
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(644, 196);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(100, 20);
            this.heightTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(675, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Height";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(658, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(678, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Rule";
            // 
            // ruleTextBox
            // 
            this.ruleTextBox.Location = new System.Drawing.Point(644, 253);
            this.ruleTextBox.Name = "ruleTextBox";
            this.ruleTextBox.Size = new System.Drawing.Size(100, 20);
            this.ruleTextBox.TabIndex = 7;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseThatShitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(767, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chooseThatShitToolStripMenuItem
            // 
            this.chooseThatShitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dAutomataToolStripMenuItem,
            this.gameOfLifeToolStripMenuItem,
            this.grainGrowthToolStripMenuItem});
            this.chooseThatShitToolStripMenuItem.Name = "chooseThatShitToolStripMenuItem";
            this.chooseThatShitToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.chooseThatShitToolStripMenuItem.Text = "Choose program";
            // 
            // dAutomataToolStripMenuItem
            // 
            this.dAutomataToolStripMenuItem.Name = "dAutomataToolStripMenuItem";
            this.dAutomataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dAutomataToolStripMenuItem.Text = "1D Automata";
            // 
            // gameOfLifeToolStripMenuItem
            // 
            this.gameOfLifeToolStripMenuItem.Name = "gameOfLifeToolStripMenuItem";
            this.gameOfLifeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gameOfLifeToolStripMenuItem.Text = "Game of life";
            this.gameOfLifeToolStripMenuItem.Click += new System.EventHandler(this.GameOfLifeToolStripMenuItem_Click);
            // 
            // grainGrowthToolStripMenuItem
            // 
            this.grainGrowthToolStripMenuItem.Name = "grainGrowthToolStripMenuItem";
            this.grainGrowthToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grainGrowthToolStripMenuItem.Text = "Grain growth";
            this.grainGrowthToolStripMenuItem.Click += new System.EventHandler(this.GrainGrowthToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(767, 653);
            this.Controls.Add(this.ruleTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "1D Automata";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ruleTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chooseThatShitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dAutomataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameOfLifeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grainGrowthToolStripMenuItem;
    }
}

