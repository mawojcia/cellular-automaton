using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cellular_automaton
{
    class Automat1D
    {

        public int[] ruleTab = new int[3];
        public int[,] grid;

        public Automat1D(int widith, int height)
        {
            //int[] vector = new int[widith];
            //int[] vector2 = new int[widith];

            grid = new int[widith,height];

            for (int i = 0; i < widith; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    grid[i, j] = 0;
                }
            }

            grid[widith / 2, 0] = 1;


            for(int i = 0; i < height - 1; i++)
            {
                for(int j = 0; j < widith - 3; j++)
                {
                    ruleTab[0] = grid[i, j];
                    ruleTab[1] = grid[i, j+1];
                    ruleTab[2] = grid[i, j+2];

                    grid[i + 1, j + 1] = rule90(ruleTab);
                }
            }
        }

        public int rule90(int[] tab)
        {
            if ((tab[0] == 1 && tab[1] == 1 && tab[2] == 0) || (tab[0] == 1 && tab[1] == 0 && tab[2] == 0) ||
                    (tab[0] == 0 && tab[1] == 1 && tab[2] == 1) || (tab[0] == 0 && tab[1] == 0 && tab[2] == 1))
            {

                return 1;
            }

            return 0;
        }
    }
}
