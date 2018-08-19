using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class LifeGrid
    {
        int[,] gen;
        int[,] lastGen;
        int genCount;
        int width;
        int height;

        public int GenCount
        {
            get { return genCount; }
        }

        public LifeGrid(int[,] newGrid)
        {
            gen = (int[,])newGrid.Clone();

            genCount = 1;

            width = gen.GetLength(1);
            height = gen.GetLength(0);

            lastGen = new int[height, width];
        }

        private int Neighbors(int x, int y)
        {
            int count = 0;

            // Check for x - 1, y - 1
            if (x > 0 && y > 0)
            {
                if (gen [y - 1, x - 1] == 1)
                    count++;
            }

            // Check for x, y - 1
            if (y > 0)
            {
                if (gen [y - 1, x] == 1)
                    count++;
            }

            // Check for x + 1, y - 1
            if (x < width - 1 && y > 0)
            {
                if (gen [y - 1, x + 1] == 1)
                    count++;
            }

            // Check for x - 1, y
            if (x > 0)
            {
                if (gen [y, x - 1] == 1)
                    count++;
            }

            // Check for x + 1, y
            if (x < width - 1)
            {
                if (gen [y, x + 1] == 1)
                    count++;
            }

            // Check for x - 1, y + 1
            if (x > 0 && y < height - 1)
            {
                if (gen [y + 1, x - 1] == 1)
                    count++;
            }

            // Check for x, y + 1
            if (y < height - 1)
            {
                if (gen [y + 1, x] == 1)
                    count++;
            }

            // Check for x + 1, y + 1
            if (x < width - 1 && y < height - 1)
            {
                if (gen [y + 1, x + 1] == 1)
                    count++;
            }

            return count;
        }

        public void WriteNeighbors()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    Console.Write("{0}", Neighbors(x, y));
                Console.WriteLine();
            }
        }

        public void ProcessNextGen()
        {
            int[,] nextGen = new int[height, width];

            lastGen = (int[,])gen.Clone();

            genCount++;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (gen [y, x] == 0 && Neighbors(x, y) == 3)
                        nextGen [y, x] = 1;
                    if (gen [y, x] == 1 &&
                           (Neighbors(x, y) == 2 || Neighbors(x, y) == 3))
                        nextGen [y, x] = 1;
                }
            }

            gen = (int[,])nextGen.Clone();
        }

        public void DrawGen()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    if (gen [y, x] == 0)
                    {
                        Console.Write(" ");
                    }

                    else if (gen [y, x] == 1)
                    {
                        Console.Write("*");
                    }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int AliveCells()
        {
            int count = 0;

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    if (gen [y, x] == 1)
                        count++;

            return count;
        }
    }
}
