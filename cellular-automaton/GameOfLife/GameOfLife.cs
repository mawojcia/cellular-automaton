using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace cellular_automaton
{
    class GameOfLife
    {
        int columns;
        int rows;

        public int[,] grid;

        public GameOfLife(int columns, int rows)
        {           
            this.columns = columns;
            this.rows = rows;

            grid = new int[columns, rows];          
        }

        public void nextGeneration()
        {
            int[,] next = new int[columns, rows];

            for (int x = 1; x < columns - 1; x++)
            {
                for (int y = 1; y < rows - 1; y++)
                {
                    int neighbors = 0;
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            neighbors = neighbors + grid[x + i, y + j];
                        }
                    }
                    neighbors = neighbors - grid[x, y];

                    if (grid[x, y] == 1 && neighbors < 2) next[x, y] = 0;
                    else if (grid[x, y] == 1 && neighbors > 3) next[x, y] = 0;
                    else if (grid[x, y] == 0 && neighbors == 3) next[x, y] = 1;
                    else next[x, y] = grid[x, y];
                }

            }
            grid = next;


            //return next;

        }

        public void setValueFromClick()
        {

        }
    }
}
