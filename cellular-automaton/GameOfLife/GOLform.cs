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
        int size;
        int scale;

        public static Bitmap bmp = new Bitmap(601, 601);
        Graphics g = Graphics.FromImage(bmp);
        Pen pen = new Pen(Color.Black);
        bool run = false;
        private BackgroundWorker _worker = null;


        GameOfLife game;

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
            //int size = Int32.Parse(sizeTextBox.Text);
            
            run = true;
            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;

            _worker.DoWork += new DoWorkEventHandler((state, args) =>
            {
                do
                {
                    if (_worker.CancellationPending)
                        break;

                    game.nextGeneration();                  

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

                } while (true);
            });

            _worker.RunWorkerAsync();
            startButton.Enabled = false;
            stopButton.Enabled = true;

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

            clickFillNode(x, y, size);
            
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void setMeshSize(int width, int height)
        {
            game = new GameOfLife(width, height);

            //return game;
        }

        public void generateRandomMesh(int scale)
        {
            Random rand = new Random();           

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    game.grid[i, j] = rand.Next(2);
                }
            }

            for (int i = 0; i <= 601; i++)
            {
                for (int j = 0; j <= 601; j++)
                {
                    if (j % (scale) == 0) g.DrawLine(pen, j, 0, j, 601);
                    if (i % (scale) == 0) g.DrawLine(pen, 0, i, 601, i);
                }
            }
        }

        public void generateEmptyMesh(int scale, int size)
        {          
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    game.grid[i, j] = 0;
                }
            }

            for (int i = 0; i <= 601; i++)
            {
                for (int j = 0; j <= 601; j++)
                {
                    if (j % (scale) == 0) g.DrawLine(pen, j, 0, j, 601);
                    if (i % (scale) == 0) g.DrawLine(pen, 0, i, 601, i);
                }
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            startButton.Enabled = true;
            _worker.CancelAsync();
        }

        private void randomMeshButton_Click(object sender, EventArgs e)
        {      
            setSizeScale();

            //int scale = (pictureBox1.Width + 1) / size;
            setMeshSize(size, size);
            generateRandomMesh(scale);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (game.grid[j, i] == 1) g.FillRectangle(Brushes.Black, i * scale, j * scale, scale, scale);
                    else if (game.grid[j, i] == 0) g.FillRectangle(Brushes.White, (i * scale) + 1, (j * scale) + 1, scale - 1, scale - 1);
                }
            }

            pictureBox1.Image = bmp;
        }

        private void EmptyMeshButton_Click(object sender, EventArgs e)
        {
            setSizeScale();
            //int scale = (pictureBox1.Width + 1) / size;
            setMeshSize(size, size);
            generateEmptyMesh(scale, size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (game.grid[j, i] == 1) g.FillRectangle(Brushes.Black, i * scale, j * scale, scale, scale);
                    else if (game.grid[j, i] == 0) g.FillRectangle(Brushes.White, (i * scale) + 1, (j * scale) + 1, scale - 1, scale - 1);
                }
            }

            pictureBox1.Image = bmp;
        }

        private void clickFillNode(int x, int y, int size)
        {
            double valueX = x / (600 / size);
            double valueY = y / (600 / size);

            int i = Convert.ToInt32(Math.Floor(valueX));
            int j = Convert.ToInt32(Math.Floor(valueY));

            if(game.grid[j, i] == 0)
            {
                game.grid[j, i] = 1;
                g.FillRectangle(Brushes.Black, i * scale, j * scale, scale, scale);
            }
            else
            {
                game.grid[j, i] = 0;
                g.FillRectangle(Brushes.White, (i * scale) + 1, (j * scale) + 1, scale - 1, scale - 1);
            }

            

            pictureBox1.Image = bmp;
        }

        private void setSizeScale()
        {
            size = Int32.Parse(sizeTextBox.Text);
            scale = (pictureBox1.Width + 1) / size;
        }
    }
}
