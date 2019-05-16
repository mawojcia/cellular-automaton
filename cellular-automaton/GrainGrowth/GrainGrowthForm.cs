using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cellular_automaton
{
    public partial class GrainGrowthForm : Form
    {
        int size;
        int scale;

        GrainGrowth grain;

        public static Bitmap bmp = new Bitmap(601, 601);
        Graphics g = Graphics.FromImage(bmp);
        Pen pen = new Pen(Color.Black);
        private BackgroundWorker _worker = null;

        public GrainGrowthForm()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;

            _worker.DoWork += new DoWorkEventHandler((state, args) =>
            {
                do
                {
                    if (_worker.CancellationPending)
                        break;

                    //game.nextGeneration();
                    grain.nextIteration();

                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (grain.grid[j, i] == 1) g.FillRectangle(Brushes.Green, (i * scale) + 1, (j * scale) + 1, scale - 1, scale - 1);
                            else if (grain.grid[j, i] == 2) g.FillRectangle(Brushes.Blue, (i * scale) + 1, (j * scale) + 1, scale - 1, scale - 1);
                            //else if (grain.grid[j, i] == 0) g.FillRectangle(Brushes.White, (i * scale) + 1, (j * scale) + 1, scale - 1, scale - 1);
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

        private void RandomButton_Click(object sender, EventArgs e)
        {
            
            Random rand = new Random();

            setSizeScale();
            setMeshSize(size, size);

            generateRandomMesh();

            

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    
                    if (grain.grid[j, i] == 1) g.FillRectangle(Brushes.Green, (i * scale) + 1, (j * scale) + 1, scale - 1, scale - 1);
                    else if (grain.grid[j, i] == 2) g.FillRectangle(Brushes.Blue, (i * scale) + 1, (j * scale) + 1, scale - 1, scale - 1);
                    else if(grain.grid[j, i] == 0) g.FillRectangle(Brushes.White, (i * scale) + 1, (j * scale) + 1, scale - 1, scale - 1);
                }
            }

            pictureBox1.Image = bmp;
        }

        public void generateRandomMesh()
        {   
            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grain.grid[i, j] = 0;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                int x = rand.Next(size);
                int y = rand.Next(size);

                grain.grid[x, y] = i + 1;
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

        public void clearMesh()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grain.grid[i, j] = 0;
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

        private void setSizeScale()
        {
            size = Int32.Parse(sizeTextBox.Text);
            scale = (pictureBox1.Width + 1) / size;
        }

        private void setMeshSize(int width, int height)
        {
            grain = new GrainGrowth(width, height);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
            startButton.Enabled = true;
            _worker.CancelAsync();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            setSizeScale();
            setMeshSize(size, size);

            clearMesh();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {

                    if (grain.grid[j, i] == 1) g.FillRectangle(Brushes.Green, (i * scale) + 1, (j * scale) + 1, scale - 1, scale - 1);
                    else if (grain.grid[j, i] == 2) g.FillRectangle(Brushes.Blue, (i * scale) + 1, (j * scale) + 1, scale - 1, scale - 1);
                    else if (grain.grid[j, i] == 0) g.FillRectangle(Brushes.White, (i * scale) + 1, (j * scale) + 1, scale - 1, scale - 1);
                }
            }

            pictureBox1.Image = bmp;
        }
    }
}
