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
        public static Bitmap bmp2 = new Bitmap(601, 601);
        public static Bitmap bmp3 = new Bitmap(601, 601);
        Graphics g = Graphics.FromImage(bmp);
        Graphics g2 = Graphics.FromImage(bmp2);
        Graphics g3 = Graphics.FromImage(bmp3);
        Pen pen = new Pen(Color.Black);
        private BackgroundWorker _worker = null;
        int NumberOfStates = 0;

        public GrainGrowthForm()
        {
            InitializeComponent();
            neighbourCB.DropDownStyle = ComboBoxStyle.DropDownList;
            boundaryCB.DropDownStyle = ComboBoxStyle.DropDownList;
            grainTypeCB.DropDownStyle = ComboBoxStyle.DropDownList;

            neighbourCB.Items.Add("Von Neumann");
            neighbourCB.Items.Add("Moore");
            neighbourCB.Items.Add("Pentagonal");
            neighbourCB.Items.Add("Hexagonal");

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
            columnslbl.Visible = false;
            rowslbl.Visible = false;
            columnsTB.Visible = false;
            rowsTB.Visible = false;


            neighbour = neighbourCB.Text;
            boundary = boundaryCB.Text;
            grainType = grainTypeCB.Text;
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
                    grain.nextIteration(neighbour, boundary, grainType);

                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            nodeColor = Color.FromArgb(grain.grid[j, i].rgb[0], grain.grid[j, i].rgb[1], grain.grid[j, i].rgb[2]);
                            brush = new SolidBrush(nodeColor);
                            g.FillRectangle(brush, (i * scale) , (j * scale) , scale , scale );
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

        private void rekBtn_Click(object sender, EventArgs e)
        {
            Color nodeColor;
            SolidBrush brush;
            int amount = Int32.Parse(randAmoutTextBox.Text);
            NumberOfStates = amount;
            //grain.Recrystalization(0.001, 0.2, 86710969050178.5, 9.41268203527779, neighbour, boundary);

            int NumberOfStatesBeforeRecrystalization;
            for (int i = 0; i < 1; i++)
            {
                if (i == 0)
                {
                    NumberOfStatesBeforeRecrystalization = NumberOfStates + 1;
                }
                else
                {
                    NumberOfStatesBeforeRecrystalization = NumberOfStates;
                }
                grain.Recrystalization(0.001, 0.2, 86710969050178.5, 9.41268203527779, neighbour, boundary);
                NumberOfStates = grain.NumberOfStates;
                

            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    nodeColor = Color.FromArgb(grain.grid[j, i].rgb[0], grain.grid[j, i].rgb[1], grain.grid[j, i].rgb[2]);
                    brush = new SolidBrush(nodeColor);
                    g.FillRectangle(brush, (i * scale), (j * scale), scale, scale);
                }
            }

            pictureBox1.Image = bmp;

            //for (int i = 0; i < size; i++)
            //{
            //    for (int j = 0; j < size; j++)
            //    {
            //        if(grain.densityMap[j, i] == 0)
            //        {
            //            nodeColor = Color.FromArgb(0, 255, 0);
            //            brush = new SolidBrush(nodeColor);
            //            g3.FillRectangle(brush, (i * scale), (j * scale), scale, scale);
            //        }
                    
            //    }
            //}

            //pictureBox3.Image = bmp3;


        }

        private void monteBtn_Click(object sender, EventArgs e)
        {
            Color nodeColor;
            SolidBrush brush;

            grain.monteCarlo(neighbour, boundary);

             for (int i = 0; i < size; i++)
             {
                for (int j = 0; j < size; j++)
                {
                    nodeColor = Color.FromArgb(grain.grid[j, i].rgb[0], grain.grid[j, i].rgb[1], grain.grid[j, i].rgb[2]);
                    brush = new SolidBrush(nodeColor);
                    g.FillRectangle(brush, (i * scale), (j * scale), scale, scale);
                }
             }

            pictureBox1.Image = bmp;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
               {

                    if(grain.energyMap[j, i] == 0)
                    {
                        nodeColor = Color.FromArgb(255, 255, 255);
                        brush = new SolidBrush(nodeColor);
                        g2.FillRectangle(brush, (i * scale), (j * scale), scale, scale);
                    }

                    if (grain.energyMap[j, i] == 1)
                    {
                        nodeColor = Color.FromArgb(224, 237, 255);
                        brush = new SolidBrush(nodeColor);
                        g2.FillRectangle(brush, (i * scale), (j * scale), scale, scale);
                    }

                    if (grain.energyMap[j, i] == 2)
                    {
                        nodeColor = Color.FromArgb(191, 217, 255);
                        brush = new SolidBrush(nodeColor);
                        g2.FillRectangle(brush, (i * scale), (j * scale), scale, scale);
                    }

                    if (grain.energyMap[j, i] == 3)
                    {
                        nodeColor = Color.FromArgb(160, 198, 255);
                        brush = new SolidBrush(nodeColor);
                        g2.FillRectangle(brush, (i * scale), (j * scale), scale, scale);
                    }

                    if (grain.energyMap[j, i] == 4)
                    {
                        nodeColor = Color.FromArgb(127, 178, 255);
                        brush = new SolidBrush(nodeColor);
                        g2.FillRectangle(brush, (i * scale), (j * scale), scale, scale);
                    }

                    if (grain.energyMap[j, i] == 5)
                    {
                        nodeColor = Color.FromArgb(91, 156, 255);
                        brush = new SolidBrush(nodeColor);
                        g2.FillRectangle(brush, (i * scale), (j * scale), scale, scale);
                    }

                    if (grain.energyMap[j, i] == 6)
                    {
                        nodeColor = Color.FromArgb(58, 136, 255);
                        brush = new SolidBrush(nodeColor);
                        g2.FillRectangle(brush, (i * scale), (j * scale), scale, scale);
                    }

                    if (grain.energyMap[j, i] == 7)
                    {
                        nodeColor = Color.FromArgb(0, 100, 255);
                        brush = new SolidBrush(nodeColor);
                        g2.FillRectangle(brush, (i * scale), (j * scale), scale, scale);
                    }


                }
            }

            pictureBox2.Image = bmp2;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {

            setSizeScale();
            setMeshSize(size, size);
            int red, green, blue;
            Random rand = new Random();
            Color nodeColor;
            SolidBrush brush;

            if (grainTypeCB.Text == "Random")
            {
                int amount = Int32.Parse(randAmoutTextBox.Text);

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
            }

            if (grainTypeCB.Text == "Homogenous")
            {
                double cols = Int32.Parse(columnsTB.Text);
                double rows = Int32.Parse(rowsTB.Text);

                int colsA = (int)Math.Floor(size / cols); 
                int rowsA = (int)Math.Floor(size / rows); 
                int inc = 1;
                bool flag;

                for(int i = 0; i < cols; i++)
                {
                    int y = colsA * i;
                    for (int j = 0; j < rows; j++)
                    {
                        
                        int x = rowsA * j;

                        grain.grid[x, y].state = inc;
                        inc++;
                        flag = true;
                        

                        while (true)
                        {
                            red = rand.Next(256);
                            green = rand.Next(256);
                            blue = rand.Next(256);

                            for (int k = 0; k < size; k++)
                            {
                                for (int z = 0; z < size; z++)
                                {
                                    if (grain.grid[z, k].rgb[0] == red && grain.grid[z, k].rgb[1] == green && grain.grid[z, k].rgb[2] == blue) { flag = false; }
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
            int amount = Int32.Parse(randAmoutTextBox.Text);
            grain = new GrainGrowth(width, height, amount);
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

        private void boundaryCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            boundary = boundaryCB.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void grainTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        { 
            grainType = grainTypeCB.Text;
            
            if (grainTypeCB.Text == "Random")
            {
                randAmoutTextBox.Visible = true;
                sizeTextBox.Visible = true;
                randAmoutLabel.Visible = true;
                label1.Visible = true;
                columnslbl.Visible = false;
                rowslbl.Visible = false;
                columnsTB.Visible = false;
                rowsTB.Visible = false;
            }

            if(grainTypeCB.Text == "Homogenous")
            {
                sizeTextBox.Visible = true;
                columnslbl.Visible = true;
                rowslbl.Visible = true;
                columnsTB.Visible = true;
                rowsTB.Visible = true;
                label1.Visible = true;


                randAmoutTextBox.Visible = false;
                randAmoutLabel.Visible = false;
            }

            if(grainTypeCB.Text == "Click")
            {
                
                label1.Visible = true;
                sizeTextBox.Visible = true;

                randAmoutLabel.Visible = false;            
                randAmoutTextBox.Visible = false;
                columnslbl.Visible = false;
                rowslbl.Visible = false;
                columnsTB.Visible = false;
                rowsTB.Visible = false;
            }
        }

        private void neighbourCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            neighbour = neighbourCB.Text; 
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (grainTypeCB.Text == "Click")
            {
                int x = e.X;
                int y = e.Y;

                clickFillNode(x, y, size);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox3.Visible = false;
            pictureBox2.Visible = true;
        }

        private void drxBtn_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }

        private void disloBtn_Click(object sender, EventArgs e)
        {
            double maxDislo = getMaxDislocation();
            Color nodeColor;
            SolidBrush brush;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {

                    if (grain.grid[i, j].recystalizationState == true)
                    {
                        nodeColor = Color.FromArgb((int)/*(grain.grid[i, j].dislocationDensity / maxDislo * 255)*/ 255, 0, 0);
                        brush = new SolidBrush(nodeColor);
                    }
                    else
                    {
                        brush = new SolidBrush(Color.Green);
                    }

                    g3.FillRectangle(brush, (i * scale), (j * scale), scale, scale);
                    //if (Mesh_box.Checked == true)
                    //{
                    //    g1.DrawRectangle(pen, x, y, RecWidth, RecHeight);
                    //}
                    //x += RecWidth;
                }

                //x = 0;
                //y += RecHeight;

                pictureBox3.Image = bmp3;
            }
        }

        double getMaxDislocation()
        {
            double max = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (grain.grid[i, j].dislocationDensity > max)
                    {
                        max = grain.grid[i, j].dislocationDensity;
                    }
                }
            }
            return max;
        }

        private void clickFillNode(int x, int y, int size)
        {
            double valueX = x / (600 / size);
            double valueY = y / (600 / size);
            bool flag = true;

            int red, green, blue;
            Random rand = new Random();
            Color nodeColor;
            SolidBrush brush;

            int i = Convert.ToInt32(Math.Floor(valueX));
            int j = Convert.ToInt32(Math.Floor(valueY));

            if (grain.grid[j, i].state == 0)
            {
                grain.grid[j, i].state = findMax(grain.grid);

                while (true)
                {
                    red = rand.Next(256);
                    green = rand.Next(256);
                    blue = rand.Next(256);

                    for (int k = 0; k < size; k++)
                    {
                        for (int z = 0; z < size; z++)
                        {
                            if (grain.grid[z, k].rgb[0] == red && grain.grid[z, k].rgb[1] == green && grain.grid[z, k].rgb[2] == blue) { flag = false; }
                        }
                    }

                    if (flag)
                    {
                        grain.grid[j, i].rgb[0] = red;
                        grain.grid[j, i].rgb[1] = green;
                        grain.grid[j, i].rgb[2] = blue;
                        break;
                    }
                }

                nodeColor = Color.FromArgb(grain.grid[j, i].rgb[0], grain.grid[j, i].rgb[1], grain.grid[j, i].rgb[2]);
                brush = new SolidBrush(nodeColor);
                g.FillRectangle(brush, (i * scale), (j * scale), scale, scale);
            }
            else
            {
                grain.grid[j, i].state = 0;
                g.FillRectangle(Brushes.White, i * scale, j * scale, scale, scale);
            }



            pictureBox1.Image = bmp;
        }

        private int findMax(GGNode[,] grid)
        {
            int check = 1;
            int max = 1;

            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    check = grid[j, i].state;
                    if(check > max)
                    {
                        max = check;
                    }
                }
            }
            max++;

            return max;
        }


    }
}
