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

        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_paint(object sender, PaintEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int width = Int32.Parse(widthTextBox.Text);
            int height = Int32.Parse(heightTextBox.Text);
            int rule = Int32.Parse(ruleTextBox.Text);

            bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            float w = 1f;

            Automat1D automat = new Automat1D(width, height, rule);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {

                    if (automat.grid[j, i] == 1) g.FillRectangle(Brushes.Black, i * w, j * w, w, w);
                    else g.FillRectangle(Brushes.White, i * w, j * w, w, w);
                }
            }
            pictureBox2.Image = bmp;
        }
    }
}
