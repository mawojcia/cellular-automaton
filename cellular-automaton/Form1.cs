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
        //Rectangle rect = new Rectangle(10, 10, 200, 100);
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
            //int widith = Int32.Parse(textBoxWidith.Text);
            //int height = Int32.Parse(textBoxHeight.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void pictureBox2_paint(object sender, PaintEventArgs e)
        {
            bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics g = Graphics.FromImage(bmp);
            float w = 4f;
            //e.Graphics.FillRectangle(Brushes.Red, rect);
            

            Automat1D automat = new Automat1D(200, 200);

            for (int i = 0; i < 200; i++)
            {
                for (int j = 0; j < 200; j++)
                {
                    //if (i % 2 == 0) g.FillRectangle(Brushes.Red, i * w, j * w, w, w);
                   // else g.FillRectangle(Brushes.Green, i * w, j * w, w, w);

                    if(automat.grid[i,j] == 1) g.FillRectangle(Brushes.Black, i * w, j * w, w, w);
                    else g.FillRectangle(Brushes.White, i * w, j * w, w, w);
                }
            }
            pictureBox2.Image = bmp;
        }
    }
}
