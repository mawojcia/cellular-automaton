using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cellular_automaton
{
    class GrainGrowth
    {
        public int[,] grid;
        int width, height;

        public GrainGrowth(int width, int height)
        {
            this.height = height;
            this.width = width;

            grid = new int[height, width];
        }

        public void nextIteration()
        {
            int[,] next = new int[width, height];
            //next = grid;
            int neighbors;

            for (int x = 0; x < height; x++)
            {
                for (int y = 0 ; y < width; y++)
                {
                    if(grid[x, y] != 0) {

                        //if (x + 1 < height && grid[x + 1, y] == 0)
                        //{
                        //    next[x + 1, y] = grid[x, y];
                        //}

                        //if (x - 1 >= 0 && grid[x - 1, y] == 0)
                        //{
                        //    next[x - 1, y] = grid[x, y];
                        //}

                        //if (y + 1 < width && grid[x, y + 1] == 0)
                        //{
                        //    next[x, y + 1] = grid[x, y];
                        //}

                        //if (y - 1 >= 0 && grid[x, y - 1] == 0)
                        //{
                        //    next[x, y - 1] = grid[x, y];
                        //}
                        next[x, y] = grid[x, y];

                    }
                    else
                    {
                        neighbors = 0;                     

                        if (x + 1 < height && grid[x + 1, y] != 0)
                        {
                            neighbors++;
                        }

                        if (x - 1 >= 0 && grid[x - 1, y] != 0)
                        {
                            neighbors++;
                        }

                        if (y + 1 < width && grid[x, y + 1] == 0)
                        {
                            next[x, y + 1] = grid[x, y];
                        }

                        if (y - 1 >= 0 && grid[x, y - 1] == 0)
                        {
                            next[x, y - 1] = grid[x, y];
                        }
                    }
                    //else
                    //{
                    //    next[x, y] = grid[x, y];
                    //}

                }

            }
            grid = next;
        }
    }
}
