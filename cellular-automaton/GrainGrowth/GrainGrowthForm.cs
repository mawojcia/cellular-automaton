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
        String neighbour, boundary, grainType;

        GrainGrowth grain;

        public static Bitmap bmp = new Bitmap(601, 601);
        Graphics g = Graphics.FromImage(bmp);
        Pen pen = new Pen(Color.Black);
        private BackgroundWorker _worker = null;

        public GrainGrowthForm()
        {
            InitializeComponent();
            neighbourCB.DropDownStyle = ComboBoxStyle.DropDownList;
            boundaryCB.DropDownStyle = ComboBoxStyle.DropDownList;
            grainTypeCB.DropDownStyle = ComboBoxStyle.DropDownList;

            neighbourCB.Items.Add("Von Neumann");
            neighbourCB.Items.Add("Moore");

            boundaryCB.Items.Add("Absorbing");
            boundaryCB.Items.Add("Periodic");

            grainTypeCB.Items.Add("Homogenous");
            grainTypeCB.Items.Add("Radius");
            grainTypeCB.Items.Add("Random");
            grainTypeCB.Items.Add("Click");

            boundaryCB.SelectedItem = "Absorbing";
            neighbourCB.SelectedItem = "Von Neumann";
            grainTypeCB.SelectedItem = "Homogenous";

            randAmoutTextBox.Visible = false;
            sizeTextBox.Visible = false;
            randAmoutLabel.Visible = false;
            label1.Visible = false;
        }

        

        private void startButton_Click(object sender, EventArgs e)
        {
            Color nodeColor;
            SolidBrush brush;

            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;

            _worker.DoWork += new DoWorkEventHandler((state, args) =>
            {
                do
                {
                    if (_worker.CancellationPending)
                        break;

                    //game.nextGeneration();
                    grain.nextIteration("Von Neumann", "Absorbing", "Random");

                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            nodeColor = Color.FromArgb(grain.grid[j, i].rgb[0], grain.grid[j, i].rgb[1], grain.grid[j, i].rgb[2]);
                            brush = new SolidBrush(nodeColor);
                            g.FillRectangle(brush, (i * scale) , (j * scale) , scale , scale );
                        }
                    }
                    //for (int slowdown = 0; slowdown < 30000000; slowdown++) ;
                    pictureBox1.Image = bmp;

                } while (true);
            });

            _worker.RunWorkerAsync();
            startButton.Enabled = false;
            stopButton.Enabled = true;
        }
        
        private void generateButton_Click(object sender, EventArgs e)
        {

            setSizeScale();
            setMeshSize(size, size);

            if (grainTypeCB.Text == "Random")
            {
                int red, green, blue, amount;
                Random rand = new Random();
                Color nodeColor;
                SolidBrush brush;

                amount = Int32.Parse(randAmoutTextBox.Text);

                for (int i = 0; i < amount; i++)
                {
                    bool flag = true;
                    int x = rand.Next(size);
                    int y = rand.Next(size);

                    grain.grid[x, y].state = i + 1;

                    while (true)
                    {
                        red = rand.Next(256);
                        green = rand.Next(256);
                        blue = rand.Next(256);

                        for (int k = 0; k < size; k++)
                        {
                            for (int j = 0; j < size; j++)
                            {
                                if (grain.grid[j, k].rgb[0] == red && grain.grid[j, k].rgb[1] == green && grain.grid[j, k].rgb[2] == blue) { flag = false; }
                            }
                        }

                        if (flag)
                        {
                            grain.grid[x, y].rgb[0] = red;
                            grain.grid[x, y].rgb[1] = green;
                            grain.grid[x, y].rgb[2] = blue;
                            break;
                        }
                    }
                }

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (grain.grid[j, i].state != 0)
                        {
                            nodeColor = Color.FromArgb(grain.grid[j, i].rgb[0], grain.grid[j, i].rgb[1], grain.grid[j, i].rgb[2]);
                            brush = new SolidBrush(nodeColor);
                            g.FillRectangle(brush, (i * scale), (j * scale), scale, scale);
                        }
                    }
                }
                pictureBox1.Image = bmp;
            }
        }

        public void clearMesh()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grain.grid[i, j].state = 0;
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

                   if (grain.grid[j, i].state == 0) g.FillRectangle(Brushes.White, i * scale, j * scale, scale, scale);
                }
            }

            pictureBox1.Image = bmp;
        }

        private void grainTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (grainTypeCB.Text == "Random")
            {
                randAmoutTextBox.Visible = true;
                sizeTextBox.Visible = true;
                randAmoutLabel.Visible = true;
                label1.Visible = true;
            }
        }

        
    }
}
