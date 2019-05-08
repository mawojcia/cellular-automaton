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
    public partial class GOLform : Form
    {
        int x = 0;
        int y = 0;
        Bitmap bmp = new Bitmap(601,601);


        public GOLform()
        {
            InitializeComponent();

            
        }

        private void DAutomatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            int size = Int32.Parse(sizeTextBox.Text);
            

            Pen pen = new Pen(Color.Black);
            //Bitmap bmp = new Bitmap((pictureBox1.Width + 1), (pictureBox1.Height + 1));
            Graphics g = Graphics.FromImage(bmp);

            int scale = (pictureBox1.Width + 1) / size;

           for (int i = 0; i <= 601; i++)
            {
                for (int j = 0; j <= 601; j++)
                {
                    if (j % (scale) == 0) g.DrawLine(pen, j, 0, j, 601);
                    if (i % (scale) == 0) g.DrawLine(pen, 0, i, 601, i);
                }
            }

            GameOfLife game = new GameOfLife(size, size);

                                 
            for (int k = 0; k < 1000; k++)
            {
                game.nextGeneration();
                pictureBox1.Refresh();


                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (game.grid[j, i] == 1) g.FillRectangle(Brushes.Black, i * scale, j * scale, scale, scale);
                        else if (game.grid[j, i] == 0) g.FillRectangle(Brushes.White, (i * scale) + 1, (j * scale) + 1, scale - 1, scale - 1);



                    }
                }


                for (int slowdown = 0; slowdown < 30000000; slowdown++) ;



                pictureBox1.Image = bmp;          

            }



        }

        private void GOLform_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;

            label3.Text = x.ToString();
            label4.Text = y.ToString();
            
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int size = Int32.Parse(sizeTextBox.Text);


            Pen pen = new Pen(Color.Black);
            
            Graphics g = Graphics.FromImage(bmp);

            int scale = (pictureBox1.Width + 1) / size;

            for (int i = 0; i <= 601; i++)
            {
                for (int j = 0; j <= 601; j++)
                {
                    if (j % (scale) == 0) g.DrawLine(pen, j, 0, j, 601);
                    if (i % (scale) == 0) g.DrawLine(pen, 0, i, 601, i);
                }
            }

            pictureBox1.Image = bmp;
        }
    }
}
