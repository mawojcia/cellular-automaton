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

        public GrainGrowth(int width, int height)
        {
            this.height = height;
            this.width = width;
            //this.mode = mode;

            grid = new GGNode[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    grid[j, i] = new GGNode();
                }
            }
        }

        public void nextIteration(String neighbour, String boundary, String grainType)
        {
            GGNode[,] next = new GGNode[width, height];
            GGNode[,] newGrid;
            int frequencyResult;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    next[j, i] = new GGNode();
                }
            }

            if (boundary == "Absorbing")
            {
                newGrid = absorbing(grid);

                if (neighbour == "Von Neumann")
                {
                    GGNode[] nodes = new GGNode[4];
                    int[] neighbours = new int[4];

                    for (int y = 1; y < newGrid.GetLength(0) - 1; y++)
                    {
                        for (int x = 1; x < newGrid.GetLength(1) - 1; x++)
                        {

                            if (newGrid[x, y].state == 0)
                            {
                                neighbours[0] = newGrid[x - 1, y].state;
                                neighbours[1] = newGrid[x + 1, y].state;
                                neighbours[2] = newGrid[x, y + 1].state;
                                neighbours[3] = newGrid[x, y - 1].state;

                                nodes[0] = newGrid[x - 1, y];
                                nodes[1] = newGrid[x + 1, y];
                                nodes[2] = newGrid[x, y + 1];
                                nodes[3] = newGrid[x, y - 1];

                                frequencyResult = mostFrequent(neighbours, 4);

                                if (frequencyResult != 0)
                                {
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (frequencyResult == nodes[i].state)
                                        {
                                            next[x - 1, y - 1] = nodes[i];
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }

                if(neighbour == "Moore")
                {
                    GGNode[] nodes = new GGNode[9];
                    int[] neighbours = new int[9];
                    int k = 0;

                    for (int y = 1; y < newGrid.GetLength(0) - 1; y++)
                    {
                        for (int x = 1; x < newGrid.GetLength(1) - 1; x++)
                        {
                            k = 0;

                            if (newGrid[x, y].state == 0)
                            {

                                for(int i = -1; i <= 1; i++)
                                {
                                    for(int j = -1; j <= 1; j++)
                                    {
                                        neighbours[k] = newGrid[x + j, y + i].state;
                                        nodes[k] = newGrid[x + j, y + i];
                                        k++;
                                    }
                                }

                                frequencyResult = mostFrequent(neighbours, 9);

                                if (frequencyResult != 0)
                                {
                                    for (int i = 0; i < 9; i++)
                                    {
                                        if (frequencyResult == nodes[i].state)
                                        {
                                            next[x - 1, y - 1] = nodes[i];
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }

                if (neighbour == "Pentagonal")
                {
                    GGNode[] nodes = new GGNode[6];
                    int[] neighbours = new int[6];
                    Random rand = new Random();
                    int mode;
                    int k = 0;

                    for (int y = 1; y < newGrid.GetLength(0) - 1; y++)
                    {
                        for (int x = 1; x < newGrid.GetLength(1) - 1; x++)
                        {
                            k = 0;
                            mode = rand.Next(4);

                            if (newGrid[x, y].state == 0)
                            {

                                for (int i = -1; i <= 1; i++)
                                {
                                    if (mode == 2 && i == -1) i++;

                                    for (int j = -1; j <= 1; j++)
                                    {
                                        if (mode == 1 && j == -1) j++;
                                        neighbours[k] = newGrid[x + j, y + i].state;
                                        nodes[k] = newGrid[x + j, y + i];
                                        k++;
                                        if (mode == 0 && j == 0) j++;                                      
                                    }

                                    if (mode == 3 && i == 0) i++;
                                }

                                frequencyResult = mostFrequent(neighbours, 6);

                                if (frequencyResult != 0)
                                {
                                    for (int i = 0; i < 6; i++)
                                    {
                                        if (frequencyResult == nodes[i].state)
                                        {
                                            next[x - 1, y - 1] = nodes[i];
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }


                if (neighbour == "Hexagonal")
                {
                    GGNode[] nodes = new GGNode[7];
                    int[] neighbours = new int[7];
                    Random rand = new Random();
                    int mode;
                    int k = 0;

                    for (int y = 1; y < newGrid.GetLength(0) - 1; y++)
                    {
                        for (int x = 1; x < newGrid.GetLength(1) - 1; x++)
                        {
                            k = 0;
                            mode = rand.Next(2);

                            if (newGrid[x, y].state == 0)
                            {

                                for (int i = -1; i <= 1; i++)
                                { 
                                    for (int j = -1; j <= 1; j++)
                                    {
                                        if (mode == 0 && i == -1 && j == -1) j++;
                                        if (mode == 1 && i == 1 && j == -1) j++;
                                        neighbours[k] = newGrid[x + j, y + i].state;
                                        nodes[k] = newGrid[x + j, y + i];
                                        k++;
                                        if (mode == 0 && i == 1 && j == 0) j++;
                                        if (mode == 1 && i == -1 && j == 0) j++;
                                    } 
                                }

                                frequencyResult = mostFrequent(neighbours, 7);

                                if (frequencyResult != 0)
                                {
                                    for (int i = 0; i < 7; i++)
                                    {
                                        if (frequencyResult == nodes[i].state)
                                        {
                                            next[x - 1, y - 1] = nodes[i];
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            if(boundary == "Periodic")
            {

                if (neighbour == "Von Neumann")
                {
                    GGNode[] nodes = new GGNode[4];
                    int[] neighbours = new int[4];

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {

                            if(grid[x, y].state == 0)
                            {

                                neighbours[0] = grid[periodic(x, width), periodic(y-1, height)].state;
                                neighbours[1] = grid[periodic(x, width), periodic(y + 1, height)].state;
                                neighbours[2] = grid[periodic(x + 1, width), periodic(y, height)].state;
                                neighbours[3] = grid[periodic(x - 1, width), periodic(y, height)].state;

                                nodes[0] = grid[periodic(x, width), periodic(y - 1, height)];
                                nodes[1] = grid[periodic(x, width), periodic(y + 1, height)];
                                nodes[2] = grid[periodic(x + 1, width), periodic(y, height)];
                                nodes[3] = grid[periodic(x - 1, width), periodic(y, height)];

                                frequencyResult = mostFrequent(neighbours, 4);

                                if(frequencyResult != 0)
                                {
                                    for(int i = 0; i < 4; i++)
                                    {
                                        if (frequencyResult == nodes[i].state)
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

                if (neighbour == "Moore")
                {
                    GGNode[] nodes = new GGNode[9];
                    int[] neighbours = new int[9];
                    int k;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            k = 0;

                            if (grid[x, y].state == 0)
                            {

                                for(int i = -1; i < 2; i++)
                                {
                                    for(int j = -1; j < 2; j++)
                                    {
                                        neighbours[k] = grid[periodic(x + j, width), periodic(y + i, height)].state;
                                        nodes[k] = grid[periodic(x + j, width), periodic(y + i, height)];
                                        k++;
                                    }
                                }

                                frequencyResult = mostFrequent(neighbours, 9);

                                if (frequencyResult != 0)
                                {
                                    for (int i = 0; i < 9; i++)
                                    {
                                        if (frequencyResult == nodes[i].state)
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

                if (neighbour == "Pentagonal")
                {
                    GGNode[] nodes = new GGNode[6];
                    int[] neighbours = new int[6];
                    Random rand = new Random();
                    int mode;
                    int k = 0;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            k = 0;
                            mode = rand.Next(4);

                            if (grid[x, y].state == 0)
                            {

                                for (int i = -1; i <= 1; i++)
                                {
                                    if (mode == 2 && i == -1) i++;

                                    for (int j = -1; j <= 1; j++)
                                    {
                                        if (mode == 1 && j == -1) j++;
                                        neighbours[k] = grid[periodic(x + j, width), periodic(y + i, height)].state;
                                        nodes[k] = grid[periodic(x + j, width), periodic(y + i, height)];
                                        k++;
                                        if (mode == 0 && j == 0) j++;
                                    }
                                    if (mode == 3 && i == 0) i++;
                                }

                                frequencyResult = mostFrequent(neighbours, 6);

                                if (frequencyResult != 0)
                                {
                                    for (int i = 0; i < 6; i++)
                                    {
                                        if (frequencyResult == nodes[i].state)
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

                if (neighbour == "Hexagonal")
                {
                    GGNode[] nodes = new GGNode[7];
                    int[] neighbours = new int[7];
                    Random rand = new Random();
                    int mode;
                    int k = 0;

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            k = 0;
                            mode = rand.Next(2);

                            if (grid[x, y].state == 0)
                            {

                                for (int i = -1; i <= 1; i++)
                                {
                                    for (int j = -1; j <= 1; j++)
                                    {
                                        if (mode == 0 && i == -1 && j == -1) j++;
                                        if (mode == 1 && i == 1 && j == -1) j++;
                                        neighbours[k] = grid[periodic(x + j, width), periodic(y + i, height)].state;
                                        nodes[k] = grid[periodic(x + j, width), periodic(y + i, height)];
                                        k++;
                                        if (mode == 0 && i == 1 && j == 0) j++;
                                        if (mode == 1 && i == -1 && j == 0) j++;
                                    }
                                }

                                frequencyResult = mostFrequent(neighbours, 7);

                                if (frequencyResult != 0)
                                {
                                    for (int i = 0; i < 7; i++)
                                    {
                                        if (frequencyResult == nodes[i].state)
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

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (grid[x, y].state != 0 && next[x, y].state != grid[x, y].state) next[x, y] = grid[x, y];
                }
            }

            grid = next;
        }

        public GGNode[,] absorbing(GGNode[,] grid)
        {
            int length = grid.GetLength(0);
            length = length + 2;

            GGNode[,] newGrid = new GGNode[length, length];
            for(int i = 0; i < length; i++)
            {
                for(int j = 0; j < length; j++)
                {
                    newGrid[j, i] = new GGNode();
                }
            }

            for (int i = 1; i < length - 1; i++)
            {
                for (int j = 1; j < length - 1; j++)
                {
                    newGrid[j, i] = grid[j - 1, i - 1];
                }
            }

            return newGrid;
        }

        public int periodic(int x, int m)
        {
            int result = (x % m + m) % m;
            return result;
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
