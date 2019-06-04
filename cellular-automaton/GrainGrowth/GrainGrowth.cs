using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cellular_automaton
{
    class GrainGrowth
    {
        public GGNode[,] grid;
        int width, height;
        GGNode[] neighbours;
        String mode;

        public GrainGrowth(int width, int height)
        {
            this.height = height;
            this.width = width;
            //this.mode = mode;

            grid = new GGNode[height, width];

            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    grid[j, i] = new GGNode();
                }
            }

            mode = "neumann";
        }

        public void nextIteration(String neighbour, String boundary, String grainType)
        {
            GGNode[,] next = new GGNode[width, height];
            int frequencyResult;
            int[] neighbours = new int[4];
            for (int i = 0; i < 4; i++) neighbours[i] = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    next[j, i] = new GGNode();
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0 ; x < width; x++)
                {
                    if (neighbour == "Von Neumann")
                    {

                        if (boundary == "Absorbing")
                        {
                            if (grid[x, y].state == 0)
                            {
                                GGNode[] nodes = new GGNode[4];
                                for (int i = 0; i < 4; i++) nodes[i] = new GGNode();
                                
                                if(x > 0 && x < width - 1)
                                {
                                    neighbours[0] = grid[x - 1, y].state;
                                    neighbours[1] = grid[x + 1, y].state;

                                    //next[x - 1, y] = grid[x - 1, y];
                                    //next[x + 1, y] = grid[x + 1, y];

                                    nodes[0] = grid[x - 1, y];
                                    nodes[1] = grid[x + 1, y];

                                    Console.Write("MIEJSCE 1");
                                }
                                if(y > 0 && y < height - 1)
                                {
                                    neighbours[2] = grid[x, y + 1].state;
                                    neighbours[3] = grid[x, y - 1].state;

                                    //next[x, y + 1] = grid[x, y + 1];
                                    //next[x, y - 1] = grid[x, y - 1];

                                    nodes[2] = grid[x, y + 1];
                                    nodes[3] = grid[x, y - 1];

                                    Console.Write("MIEJSCE 2");
                                }
                                if (x == 0)
                                {
                                    neighbours[0] = grid[x + 1, y].state;

                                    //next[x + 1, y] = grid[x + 1, y];

                                    nodes[0] = grid[x + 1, y];

                                    Console.Write("MIEJSCE 3");
                                }
                                if(y == 0)
                                {
                                    neighbours[2] = grid[x, y + 1].state;

                                    //next[x, y + 1] = grid[x, y + 1];

                                    nodes[2] = grid[x, y + 1];

                                    Console.Write("MIEJSCE 4");
                                }
                                if(x == width - 1)
                                {
                                    neighbours[0] = grid[x - 1, y].state;

                                    //next[x - 1, y] = grid[x - 1, y];

                                    nodes[0] = grid[x - 1, y];

                                    Console.Write("MIEJSCE 5");
                                }
                                if (y == height - 1)
                                {
                                    neighbours[2] = grid[x, y - 1].state;

                                    //next[x, y - 1] = grid[x, y - 1];

                                    nodes[2] = grid[x, y - 1];

                                    Console.Write("MIEJSCE 6");
                                }

                                frequencyResult = mostFrequent(neighbours, 4);

                                if(frequencyResult != 0)
                                {
                                    for(int i = 0; i < 4; i ++)
                                    {
                                        if(frequencyResult == nodes[i].state)
                                        {
                                            next[x, y] = nodes[i];
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }

            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    if (grid[x, y].state != 0 && next[x, y].state != grid[x, y].state) next[x, y] = grid[x, y];
                }
            }
            grid = next;
        }


        public GGNode vonNeumann(int x, int y)
        {
            int frequencyResult;
            int[] neighbourState = new int[4];
            GGNode ggnode = new GGNode();

            neighbours = new GGNode[4];

            neighbours[0] = grid[periodic((x - 1), width), periodic(y, height)];
            neighbours[1] = grid[periodic((x + 1), width), periodic(y, height)];
            neighbours[2] = grid[periodic(x, width), periodic(y + 1, height)];
            neighbours[3] = grid[periodic(x, width), periodic(y - 1, height)];

            for (int i = 0; i < 4; i++) { neighbourState[i] = neighbours[i].state; }

            frequencyResult = mostFrequent(neighbourState, 4);

            for (int i = 0; i < 4; i++)
            {
                if (frequencyResult == neighbours[i].state) return neighbours[i];
            }

            return neighbours[0];
        }

        public int periodic(int x, int m)
        {
            int result = (x % m + m) % m;
            return result;
        }

        public void setMode(String mode)
        {
            this.mode = mode;
        }

        public int mostFrequent(int[] arr, int n)
        {
            // Sort the array 
            Array.Sort(arr);

            // find the max frequency using  
            // linear traversal

            int max_count = 1, res = arr[0];
            int curr_count = 1;


            int sum = 0;
            for(int i = 0; i < n; i++)
            {
                sum = sum + arr[i];
            }
            if (sum == 0) return 0;

            for(int i = 0; i < n; i++)
            {
                if(arr[i] != 0)
                {
                    res = arr[i];
                    break;
                }
            }           

            for (int i = 1; i < n; i++)
            {

                if (arr[i] != 0)
                {
                    if (arr[i] == arr[i - 1])
                        curr_count++;

                    else
                    {
                        if (curr_count > max_count)
                        {
                            max_count = curr_count;
                            res = arr[i - 1];
                        }
                        curr_count = 1;
                    }
                }
                
            }

            // If last element is most frequent 
            if (curr_count > max_count)
            {
                max_count = curr_count;
                res = arr[n - 1];
            }

            return res;
        }
    }
}
