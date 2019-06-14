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
        public int NumberOfStates;
        GGNode[,] newGrid;
        public double[,] densityMap;
        public int[,] energyMap;
        int width, height;
        double DeltaDislocationDensity = 0, DislocationDensity = 0, RecrystalizationTimeStep = 0, DislocationDensityCritical;
        WriteToFile writeToFile = new WriteToFile("E:\\git\\cellular-automaton\\dislocationDensity.txt");



        public GrainGrowth(int width, int height, int numOfStates)
        {
            this.height = height;
            this.width = width;
            //this.mode = mode;

            NumberOfStates += numOfStates;
            grid = new GGNode[height, width];
            energyMap = new int[height, width];
            densityMap = new double[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    grid[j, i] = new GGNode();
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    energyMap[j, i] = 0;
                }
            }

            newGrid = absorbing(grid);
        }

        public void nextIteration(String neighbour, String boundary, String grainType)
        {
            GGNode[,] next = new GGNode[width, height];

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

                if (neighbour == "Moore")
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

                                for (int i = -1; i <= 1; i++)
                                {
                                    for (int j = -1; j <= 1; j++)
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
            if (boundary == "Periodic")
            {

                if (neighbour == "Von Neumann")
                {
                    GGNode[] nodes = new GGNode[4];
                    int[] neighbours = new int[4];

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {

                            if (grid[x, y].state == 0)
                            {

                                neighbours[0] = grid[periodic(x, width), periodic(y - 1, height)].state;
                                neighbours[1] = grid[periodic(x, width), periodic(y + 1, height)].state;
                                neighbours[2] = grid[periodic(x + 1, width), periodic(y, height)].state;
                                neighbours[3] = grid[periodic(x - 1, width), periodic(y, height)].state;

                                nodes[0] = grid[periodic(x, width), periodic(y - 1, height)];
                                nodes[1] = grid[periodic(x, width), periodic(y + 1, height)];
                                nodes[2] = grid[periodic(x + 1, width), periodic(y, height)];
                                nodes[3] = grid[periodic(x - 1, width), periodic(y, height)];

                                frequencyResult = mostFrequent(neighbours, 4);

                                if (frequencyResult != 0)
                                {
                                    for (int i = 0; i < 4; i++)
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

                                for (int i = -1; i < 2; i++)
                                {
                                    for (int j = -1; j < 2; j++)
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
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
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
            for (int i = 0; i < n; i++)
            {
                sum = sum + arr[i];
            }
            if (sum == 0) return 0;

            for (int i = 0; i < n; i++)
            {
                if (arr[i] != 0)
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


        public void monteCarlo(String neighbour, String boundary)
        {

            GGNode[,] next = new GGNode[width, height];
            Random rand = new Random();
            double kt = 2.5;
            GGNode[] nodes;
            int amount = 4;
            int energy = 0;
            int randomNeighbourState;
            int randomNeighbourEnergy = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    next[j, i] = new GGNode();

                }
            }

            if (neighbour == "Von Neumann")
            {
                nodes = new GGNode[4];
                amount = 4;
            }

            if (neighbour == "Moore")
            {
                nodes = new GGNode[9];
                amount = 9;
            }

            if (neighbour == "Pentagonal")
            {
                nodes = new GGNode[6];
                amount = 6;
            }

            if (neighbour == "Hexagonal")
            {
                nodes = new GGNode[7];
                amount = 7;
            }


            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    energy = 0;
                    randomNeighbourEnergy = 0;

                    nodes = getNeighbours(x, y, amount, boundary, neighbour);

                    for (int i = 0; i < nodes.Length; i++)
                    {
                        if (nodes[i].state != grid[x, y].state)
                        {
                            energy++;
                        }
                    }

                    energyMap[x, y] = energy;

                    randomNeighbourState = nodes[rand.Next(0, nodes.Length)].state;

                    for (int i = 0; i < nodes.Length; i++)
                    {
                        if (nodes[i].state != randomNeighbourState) randomNeighbourEnergy++;
                    }

                    if (randomNeighbourEnergy <= energy)
                    {
                        for (int i = 0; i < nodes.Length; i++)
                        {
                            if (randomNeighbourState == nodes[i].state)
                            {
                                next[x, y] = nodes[i];
                                energyMap[x, y] = randomNeighbourEnergy;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (rand.NextDouble() <= Math.Exp(-(randomNeighbourEnergy - energy) / kt))
                        {
                            for (int i = 0; i < nodes.Length; i++)
                            {
                                if (randomNeighbourState == nodes[i].state)
                                {
                                    next[x, y] = nodes[i];
                                    energyMap[x, y] = randomNeighbourEnergy;
                                    break;
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
                    if (next[x, y].state == 0) next[x, y] = grid[x, y];
                }
            }

            grid = next;
        }

        //public GGNode[,] calculateEnergyMap(int x, int y, GGNode[] nodes, GGNode[,] next)
        //{
        //    Random rand = new Random();
        //    int energy = 0;
        //    int randomNeighbourState;
        //    int randomNeighbourEnergy = 0;
        //    double kt = 2.5;

        //    for (int i = 0; i < nodes.Length; i++)
        //    {
        //        if (nodes[i].state != grid[x, y].state)
        //        {
        //            energy++;
        //        }
        //    }

        //    energyMap[x, y] = energy;

        //    randomNeighbourState = nodes[rand.Next(0, nodes.Length)].state;

        //    for (int i = 0; i < nodes.Length; i++)
        //    {
        //        if (nodes[i].state != randomNeighbourState) randomNeighbourEnergy++;
        //    }

        //    if (randomNeighbourEnergy <= energy)
        //    {
        //        for (int i = 0; i < nodes.Length; i++)
        //        {
        //            if (randomNeighbourState == nodes[i].state)
        //            {
        //                next[x, y] = nodes[i];
        //                energyMap[x, y] = randomNeighbourEnergy;
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (rand.NextDouble() <= Math.Exp(-(randomNeighbourEnergy - energy) / kt))
        //        {
        //            for (int i = 0; i < nodes.Length; i++)
        //            {
        //                if (randomNeighbourState == nodes[i].state)
        //                {
        //                    next[x, y] = nodes[i];
        //                    energyMap[x, y] = randomNeighbourEnergy;
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    return next;
        //}

        public GGNode[] getNeighbours(int x, int y, int amount, String boundary, String neighbour)
        {
            GGNode[] nodes = new GGNode[amount];

            if (boundary == "Periodic")
            {
                if (neighbour == "Von Neumann")
                {

                    nodes[0] = grid[periodic(x, width), periodic(y - 1, height)];
                    nodes[1] = grid[periodic(x, width), periodic(y + 1, height)];
                    nodes[2] = grid[periodic(x + 1, width), periodic(y, height)];
                    nodes[3] = grid[periodic(x - 1, width), periodic(y, height)];

                }

                else if (neighbour == "Moore")
                {
                    int k = 0;
                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            nodes[k] = grid[periodic(x + j, width), periodic(y + i, height)];
                            k++;
                        }
                    }
                }

                else if (neighbour == "Pentagonal")
                {

                    Random rand = new Random();
                    int k = 0;
                    int mode = rand.Next(4);
                    for (int i = -1; i <= 1; i++)
                    {
                        if (mode == 2 && i == -1) i++;

                        for (int j = -1; j <= 1; j++)
                        {
                            if (mode == 1 && j == -1) j++;

                            nodes[k] = grid[periodic(x + j, width), periodic(y + i, height)];
                            k++;
                            if (mode == 0 && j == 0) j++;
                        }
                        if (mode == 3 && i == 0) i++;
                    }
                }

                else if (neighbour == "Hexagonal")
                {
                    Random rand = new Random();
                    int k = 0;
                    int mode = rand.Next(2);
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if (mode == 0 && i == -1 && j == -1) j++;
                            if (mode == 1 && i == 1 && j == -1) j++;
                            nodes[k] = grid[periodic(x + j, width), periodic(y + i, height)];
                            k++;
                            if (mode == 0 && i == 1 && j == 0) j++;
                            if (mode == 1 && i == -1 && j == 0) j++;
                        }
                    }
                }
            }

            if (boundary == "Absorbing")
            {
                newGrid = absorbing(grid);
                x++;
                y++;
                if (neighbour == "Von Neumann")
                {
                    nodes[0] = newGrid[x - 1, y];
                    nodes[1] = newGrid[x + 1, y];
                    nodes[2] = newGrid[x, y + 1];
                    nodes[3] = newGrid[x, y - 1];
                }

                if (neighbour == "Moore")
                {
                    int k = 0;
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            nodes[k] = newGrid[x + j, y + i];
                            k++;
                        }
                    }
                }

                if (neighbour == "Pentagonal")
                {
                    int k = 0;
                    Random rand = new Random();
                    int mode = rand.Next(4);

                    for (int i = -1; i <= 1; i++)
                    {
                        if (mode == 2 && i == -1) i++;

                        for (int j = -1; j <= 1; j++)
                        {
                            if (mode == 1 && j == -1) j++;
                            nodes[k] = newGrid[x + j, y + i];
                            k++;
                            if (mode == 0 && j == 0) j++;
                        }

                        if (mode == 3 && i == 0) i++;
                    }
                }

                if (neighbour == "Hexagonal")
                {
                    int k = 0;
                    Random rand = new Random();
                    int mode = rand.Next(2);

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if (mode == 0 && i == -1 && j == -1) j++;
                            if (mode == 1 && i == 1 && j == -1) j++;
                            nodes[k] = newGrid[x + j, y + i];
                            k++;
                            if (mode == 0 && i == 1 && j == 0) j++;
                            if (mode == 1 && i == -1 && j == 0) j++;
                        }
                    }
                }
            }

            return nodes;
        }

        public void Recrystalization(double DeltaT, double Percent, double A, double B, String neighbour, String boundary)
        {
            Random rand = new Random();
            GGNode[,] next = new GGNode[width, height];
            GGNode[] nodes;
            int amount = 0;
            bool ifBorder = false;
            int NumberOfStates = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    next[j, i] = new GGNode();
                }
            }

            DeltaDislocationDensity = (A / B + (1 - A / B) * Math.Exp(-B * RecrystalizationTimeStep)) - DislocationDensity;


            DislocationDensity = ((A / B) + (1 - A / B) * Math.Exp(-1 * B * RecrystalizationTimeStep));
            DislocationDensityCritical = 46842668.25;
            writeToFile.SaveToFile(DislocationDensity);
            RecrystalizationTimeStep = RecrystalizationTimeStep + DeltaT;

            double avaragePackage = (DeltaDislocationDensity / (height * width)) * Percent;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    next[i, j].dislocationDensity = next[i, j].dislocationDensity + 1;
                    densityMap[i, j] += avaragePackage;
                    DeltaDislocationDensity -= avaragePackage;
                }
            }

            if (neighbour == "Von Neumann")
            {
                nodes = new GGNode[4];
                amount = 4;
            }

            if (neighbour == "Moore")
            {
                nodes = new GGNode[9];
                amount = 9;
            }

            if (neighbour == "Pentagonal")
            {
                nodes = new GGNode[6];
                amount = 6;
            }

            if (neighbour == "Hexagonal")
            {
                nodes = new GGNode[7];
                amount = 7;
            }

            double randomPackage;
            int Randx, Randy;
            double proability;

            while (DeltaDislocationDensity > 0)
            {
                Randx = rand.Next(0, height);
                Randy = rand.Next(0, width);

                nodes = getNeighbours(Randx, Randy, amount, boundary, neighbour);
                ifBorder = check(nodes, amount, Randx, Randy);

                if (ifBorder)
                {
                    proability = rand.NextDouble();
                    randomPackage = DeltaDislocationDensity * rand.NextDouble();
                    if (randomPackage <= DeltaDislocationDensity && proability > 0.2)
                    {
                        next[Randx, Randy].dislocationDensity = next[Randx, Randy].dislocationDensity + 1;
                        densityMap[Randx, Randy] += randomPackage;
                        DeltaDislocationDensity -= randomPackage;
                    }
                    if (DeltaDislocationDensity < 0.00001)
                    {
                        DeltaDislocationDensity = 0;
                    }
                }
                else
                {
                    proability = rand.NextDouble();
                    randomPackage = DeltaDislocationDensity * rand.NextDouble();
                    if (randomPackage <= DeltaDislocationDensity && proability <= 0.2)
                    {
                        next[Randx, Randy].dislocationDensity = next[Randx, Randy].dislocationDensity + 1;
                        densityMap[Randx, Randy] += randomPackage;
                        DeltaDislocationDensity -= randomPackage;
                    }
                    if (DeltaDislocationDensity < 0.00001)
                    {
                        DeltaDislocationDensity = 0;
                    }
                }

            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    nodes = getNeighbours(i, j, amount, boundary, neighbour);
                    if (check(nodes, amount, i, j) && next[i, j].dislocationDensity > DislocationDensityCritical && next[i, i].recystalizationState == false)
                    {
                        NumberOfStates++;
                        next[i, j].state = NumberOfStates;
                        bool flag = true;
                        while (true)
                        {
                            int red = rand.Next(256);
                            int green = rand.Next(256);
                            int blue = rand.Next(256);

                            for (int k = 0; k < height; k++)
                            {
                                for (int z = 0; z < width; z++)
                                {
                                    if (next[z, k].rgb[0] == red && next[z, k].rgb[1] == green && next[z, k].rgb[2] == blue) { flag = false; }
                                }
                            }

                            if (flag)
                            {
                                next[j, i].rgb[0] = red;
                                next[j, i].rgb[1] = green;
                                next[j, i].rgb[2] = blue;
                                break;
                            }
                        }
                        next[i, j].dislocationDensity = 0;
                        densityMap[i, j] = 0;
                        next[i, j].recystalizationState = true;
                    }
                }
            }

            

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (grid[i, j].recystalizationState != true)
                    {
                        nodes = getNeighbours(i, j, amount, boundary, neighbour);
                        int tmp = checkIfRecrystalized(nodes, amount, i, j);

                        if (tmp != 0 && grid[i, j].recystalizationState != true)
                        {
                            if (checkIfDislocations(nodes,amount, i, j))
                            {
                                grid[i, j].state = tmp;
                                grid[i, j].dislocationDensity = 0;
                                densityMap[i, j] = 0;
                                grid[i, j].recystalizationState = true;
                            }
                        }
                    }
                }
            }
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (next[x, y].state == 0) next[x, y] = grid[x, y];
                }
            }

            grid = next;
        }


        public bool check(GGNode[] nodes, int amount, int x, int y)
        {
            for (int i = 0; i < amount; i++)
            {
                if (nodes[i].state != grid[x, y].state) return true;
            }
            return false;
        }

        public int checkIfRecrystalized(GGNode[] nodes, int amount, int x, int y)
        {
            for (int i = 0; i < amount; i++)
            {
                if (nodes[i].state != grid[x, y].state) return nodes[i].state;
            }
            return 0;
        }

        public bool checkIfDislocations(GGNode[] nodes, int amount, int x, int y)
        {
            for (int i = 0; i < amount; i++)
            {
                if (nodes[i].dislocationDensity > grid[x, y].dislocationDensity) return false;
            }
            return true;
        }
    }
}
