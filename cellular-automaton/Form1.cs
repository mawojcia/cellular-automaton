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

        //Bitmap bmp;

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

            Pen pen = new Pen(Color.Black);
            Bitmap bmp = new Bitmap(601, 601);
            Graphics g = Graphics.FromImage(bmp);

            int scale = Math.Min(601 / width, 601 / height);



            if (meshCheckBox.CheckState == CheckState.Checked){


                for (int i = 0; i <= 601; i++)
                {
                    for (int j = 0; j <= 601; j++)
                    {
                        if (j % (scale) == 0) g.DrawLine(pen, j, 0, j, 601);
                        if (i % (scale) == 0) g.DrawLine(pen, 0, i, 601, i);
                    }
                }
            }

            Automat1D automat = new Automat1D( width, height, rule);

            for (int i = 0; i < width; i++)
            {
                for(int j = 0; j< height; j++)
                {
                    if (automat.grid[j, i] == 1) g.FillRectangle(Brushes.Black, i * scale, j * scale, scale, scale);
                            //else g.FillRectangle(Brushes.White, i * scale, j * scale, scale, scale);
                }
            }


            pictureBox2.Image = bmp;

        }
    }
}
