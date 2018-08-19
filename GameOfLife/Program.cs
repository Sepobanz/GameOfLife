using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.Write("Enter the height: ");
            int height = int.Parse(Console.ReadLine());
            Console.Write("Enter the width: ");
            int width = int.Parse(Console.ReadLine());

            int[,] randomGrid = new int[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    randomGrid[x, y] = rand.Next(0, 2);
                }
            }

            LifeGrid lifeGrid = new LifeGrid(randomGrid);

            Console.WriteLine("Generation 0");
            lifeGrid.DrawGen();

            while (lifeGrid.AliveCells() > 0)
            {
                string response;

                Console.WriteLine("\nGeneration {0}", lifeGrid.GenCount);

                lifeGrid.ProcessNextGen();

                lifeGrid.DrawGen();

                if (lifeGrid.AliveCells() == 0)
                {
                    Console.WriteLine("Game over!");
                }
                else
                {
                    Console.Write("Keep going? (y/n): ");

                    response = Console.ReadLine();

                    if (response.ToLower() == "n")
                        break;
                }
            }
        }
    }
}
