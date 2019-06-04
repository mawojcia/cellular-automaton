namespace cellular_automaton
{
    partial class GrainGrowthForm
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
            this.sizeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.randAmoutTextBox = new System.Windows.Forms.TextBox();
            this.randAmoutLabel = new System.Windows.Forms.Label();
            this.neighbourCB = new System.Windows.Forms.ComboBox();
            this.boundaryCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grainTypeCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(12, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(601, 601);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // sizeTextBox
            // 
            this.sizeTextBox.Location = new System.Drawing.Point(658, 363);
            this.sizeTextBox.Name = "sizeTextBox";
            this.sizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.sizeTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(683, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mesh size";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(629, 566);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(710, 566);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "STOP";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(710, 528);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "CLEAR";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // randAmoutTextBox
            // 
            this.randAmoutTextBox.Location = new System.Drawing.Point(658, 411);
            this.randAmoutTextBox.Name = "randAmoutTextBox";
            this.randAmoutTextBox.Size = new System.Drawing.Size(100, 20);
            this.randAmoutTextBox.TabIndex = 8;
            // 
            // randAmoutLabel
            // 
            this.randAmoutLabel.AutoSize = true;
            this.randAmoutLabel.Location = new System.Drawing.Point(670, 395);
            this.randAmoutLabel.Name = "randAmoutLabel";
            this.randAmoutLabel.Size = new System.Drawing.Size(76, 13);
            this.randAmoutLabel.TabIndex = 9;
            this.randAmoutLabel.Text = "Nodes amount";
            // 
            // neighbourCB
            // 
            this.neighbourCB.FormattingEnabled = true;
            this.neighbourCB.Location = new System.Drawing.Point(658, 181);
            this.neighbourCB.Name = "neighbourCB";
            this.neighbourCB.Size = new System.Drawing.Size(110, 21);
            this.neighbourCB.TabIndex = 10;
            // 
            // boundaryCB
            // 
            this.boundaryCB.FormattingEnabled = true;
            this.boundaryCB.Location = new System.Drawing.Point(658, 221);
            this.boundaryCB.Name = "boundaryCB";
            this.boundaryCB.Size = new System.Drawing.Size(110, 21);
            this.boundaryCB.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(685, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Neighbours";
            // 
            // grainTypeCB
            // 
            this.grainTypeCB.FormattingEnabled = true;
            this.grainTypeCB.Location = new System.Drawing.Point(658, 261);
            this.grainTypeCB.Name = "grainTypeCB";
            this.grainTypeCB.Size = new System.Drawing.Size(110, 21);
            this.grainTypeCB.TabIndex = 13;
            this.grainTypeCB.SelectedIndexChanged += new System.EventHandler(this.grainTypeCB_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(685, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Boundary";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(695, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Mode";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(671, 486);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 16;
            this.generateButton.Text = "GENERATE";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // GrainGrowthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.ClientSize = new System.Drawing.Size(797, 636);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grainTypeCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.boundaryCB);
            this.Controls.Add(this.neighbourCB);
            this.Controls.Add(this.randAmoutLabel);
            this.Controls.Add(this.randAmoutTextBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sizeTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GrainGrowthForm";
            this.Text = "GrainGrowthForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox sizeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox randAmoutTextBox;
        private System.Windows.Forms.Label randAmoutLabel;
        private System.Windows.Forms.ComboBox neighbourCB;
        private System.Windows.Forms.ComboBox boundaryCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox grainTypeCB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button generateButton;
    }
}