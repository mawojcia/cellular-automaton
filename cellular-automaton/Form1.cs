using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cellular_automaton
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            float width = Int32.Parse(widthTextBox.Text);
            float height = Int32.Parse(heightTextBox.Text);
            int rule = Int32.Parse(ruleTextBox.Text); 
            
            Bitmap bmp = new Bitmap(pictureBox2.Width + 1, pictureBox2.Height + 1);
            Graphics g = Graphics.FromImage(bmp);

            float scale = Math.Min(((pictureBox2.Width + 1 )/width), ((pictureBox2.Height + 1) / height));      

            Automat1D automat = new Automat1D( (int)width, (int)height, rule);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (automat.grid[j, i] == 1) g.FillRectangle(Brushes.Black, i * scale, j * scale, scale, scale);
                }          
            }

            pictureBox2.Image = bmp;

        }

        private void GameOfLifeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GOLform golform = new GOLform();
            golform.ShowDialog();
            this.Close();
        }
    }
}
