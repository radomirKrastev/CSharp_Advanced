using System;
using System.Linq;

namespace TheGarden
{
    public class Program
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var garden = new char[rows][];
            SetGarden(garden);

            var command = Console.ReadLine();

            var carrots = 0;
            var potatoes = 0;
            var lettuce = 0;

            var mole = new Mole();

            while (command != "End of Harvest")
            {
                var tokens = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var action = tokens[0];
                var row = int.Parse(tokens[1]);
                var col = int.Parse(tokens[2]);

                if (action == "Harvest")
                {
                    if (ValidateCoordinates(garden, row, col))
                    {
                        if (garden[row][col]== 'C')
                        {
                            carrots++;
                            garden[row][col] = ' ';
                        }
                        else if(garden[row][col] == 'P')
                        {
                            potatoes++;
                            garden[row][col] = ' ';
                        }
                        else if (garden[row][col] == 'L')
                        {
                            lettuce++;
                            garden[row][col] = ' ';
                        }
                    }
                }
                else if (action == "Mole")
                {
                    var direction = tokens[3];

                    Harm(garden, row, col, mole, direction);
                }

                command = Console.ReadLine();
            }

            foreach (var row in garden)
            {
                Console.WriteLine(string.Join(" ", row));
            }
            
            Console.WriteLine($"Carrots: {carrots}");
            Console.WriteLine($"Potatoes: {potatoes}");
            Console.WriteLine($"Lettuce: {lettuce}");
            Console.WriteLine($"Harmed vegetables: {mole.VegetablesHarmed}");
        }

        private static void Harm(char[][] garden, int row, int col, Mole mole, string direction)
        {
            var nextRow = row;
            var nextCol = col;

            var counter = 1;

            while (ValidateCoordinates(garden, nextRow, nextCol))
            {
                if (counter++ % 2 != 0)
                {
                    mole.Harm(garden, nextRow, nextCol);
                }

                if (direction.ToLower() == "up")
                {
                    nextRow--;
                }
                else if (direction.ToLower() == "down")
                {
                    nextRow++;
                }
                else if (direction.ToLower() == "left")
                {
                    nextCol--;
                }
                else if (direction.ToLower() == "right")
                {
                    nextCol++;
                }
            }
        }
        
        private static bool ValidateCoordinates(char[][] garden, int row, int col)
        {
            return row >= 0 && col >= 0 && row < garden.GetLength(0) && col < garden[row].Length;
        }

        private static void SetGarden(char[][] garden)
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                var line = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();

                garden[row] = line;
            }
        }
    }
}
