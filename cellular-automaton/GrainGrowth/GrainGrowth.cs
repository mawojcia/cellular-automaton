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

            for (int x = 0; x < height; x++)
            {
                for (int y = 0 ; y < width; y++)
                {
                    
                }

            }
        }
    }
}
