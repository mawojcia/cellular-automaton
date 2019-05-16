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

        public Automat1D(int width, int height, int rule)
        {

            grid = new int[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    grid[i, j] = 0;
                }
            }

            grid[0, width / 2] = 1;


            for (int i = 0; i < height - 1; i++)
            {
                for (int j = 0; j < width; j++)
                {

                    if (j == 0)
                    {
                        ruleTab[0] = grid[i, width - 1];
                        ruleTab[1] = grid[i, j];
                        ruleTab[2] = grid[i, j + 1];
                    }

                    else if (j == width - 1)
                    {
                        ruleTab[0] = grid[i, j - 1];
                        ruleTab[1] = grid[i, j];
                        ruleTab[2] = grid[i, 0];
                    }

                    else
                    {
                        ruleTab[0] = grid[i, j - 1];
                        ruleTab[1] = grid[i, j];
                        ruleTab[2] = grid[i, j + 1];
                    }

                    if (rule <= 30) grid[i + 1, j] = rule30(ruleTab);

                    if (rule > 30 && rule <= 60) grid[i + 1, j] = rule60(ruleTab);

                    if (rule > 60 && rule <= 90) grid[i + 1, j] = rule90(ruleTab);

                    if (rule > 90 && rule <= 120) grid[i + 1, j] = rule120(ruleTab);

                    if (rule > 120) grid[i + 1, j] = rule225(ruleTab);

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

        public int rule30(int[] tab)
        {
            if ((tab[0] == 1 && tab[1] == 0 && tab[2] == 0) || (tab[0] == 0 && tab[1] == 1 && tab[2] == 1) ||
                    (tab[0] == 0 && tab[1] == 1 && tab[2] == 0) || (tab[0] == 0 && tab[1] == 0 && tab[2] == 1))
            {

                return 1;
            }

            return 0;
        }

        public int rule60(int[] tab)
        {
            if ((tab[0] == 1 && tab[1] == 0 && tab[2] == 1) || (tab[0] == 1 && tab[1] == 0 && tab[2] == 0) ||
                    (tab[0] == 0 && tab[1] == 1 && tab[2] == 1) || (tab[0] == 0 && tab[1] == 1 && tab[2] == 0))
            {

                return 1;
            }

            return 0;
        }

        public int rule120(int[] tab)
        {
            if ((tab[0] == 1 && tab[1] == 1 && tab[2] == 0) || (tab[0] == 1 && tab[1] == 0 && tab[2] == 1) ||
                    (tab[0] == 1 && tab[1] == 0 && tab[2] == 0) || (tab[0] == 0 && tab[1] == 1 && tab[2] == 1))
            {

                return 1;
            }

            return 0;
        }

        public int rule225(int[] tab)
        {
            if ((tab[0] == 1 && tab[1] == 1 && tab[2] == 1) || (tab[0] == 1 && tab[1] == 1 && tab[2] == 0) ||
                    (tab[0] == 1 && tab[1] == 0 && tab[2] == 1) || (tab[0] == 0 && tab[1] == 0 && tab[2] == 0))
            {

                return 1;
            }

            return 0;
        }
    }
}
