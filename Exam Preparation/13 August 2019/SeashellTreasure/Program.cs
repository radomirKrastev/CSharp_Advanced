using System;
using System.Collections.Generic;
using System.Linq;

namespace SeashellTreasure
{
    public class Program
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            var beach = new Beach(rows);
            SetMatrix(beach, rows);
            
            var command = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var seashellsCollected = new List<char>();
            var seagull = new Seagull();

            while (command[0] != "Sunset")
            {
                var row = int.Parse(command[1]);
                var col = int.Parse(command[2]);

                if (command[0] == "Collect")
                {
                    if (ValidateCoordinates(beach, row, col))
                    {
                        if (char.IsLetter(beach.Matrix[row][col]))
                        {
                            seashellsCollected.Add(beach.Matrix[row][col]);
                            beach.Matrix[row][col] = '-';
                        }
                    }
                }
                else if (command[0] == "Steal")
                {
                    var direction = command[3];
                    MoveSeagull(beach, row, col, direction, seagull);
                }

                command = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            }

            PrintOutput(beach, seashellsCollected, seagull);
        }

        private static void PrintOutput(Beach beach, List<char> seashellsCollected, Seagull seagull)
        {
            Console.WriteLine(beach);

            if (seashellsCollected.Count > 0)
            {
                Console.Write($"Collected seashells: {seashellsCollected.Count}");
                Console.WriteLine($" -> {string.Join(", ", seashellsCollected)}");
            }
            else
            {
                Console.WriteLine($"Collected seashells: {seashellsCollected.Count}");
            }

            Console.WriteLine($"Stolen seashells: {seagull.SeashellsStolen}");
        }

        private static void MoveSeagull(Beach beach, int row, int col, string direction, Seagull seagull)
        {
            if (ValidateCoordinates(beach, row, col))
            {
                seagull.Steal(beach, row, col);

                for (int i = 1; i <= 3; i++)
                {
                    var destinationRow = row;
                    var destinationCol = col;

                    if (direction == "up")
                    {
                        destinationRow = row - i;
                    }
                    else if (direction == "down")
                    {
                        destinationRow = row + i;
                    }
                    else if (direction == "left")
                    {
                        destinationCol = col - i;
                    }
                    else if (direction == "right")
                    {
                        destinationCol = col + i;
                    }

                    if (ValidateCoordinates(beach, destinationRow, destinationCol))
                    {
                        seagull.Steal(beach, destinationRow, destinationCol);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static void SetMatrix(Beach beach, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                beach.Matrix[row] = line;
            }
        }

        private static bool ValidateCoordinates(Beach beach, int row, int col)
        {
            return row >= 0 && col >= 0 && row < beach.Matrix.GetLength(0) && col < beach.Matrix[row].Length;
        }
    }
}
