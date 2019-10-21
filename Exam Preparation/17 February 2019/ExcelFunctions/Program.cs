using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelFunctions
{
    public class Program
    {
        public static void Main()
        {
            var tableRows = int.Parse(Console.ReadLine());
            var table = new string[tableRows][];

            for (int row = 0; row < tableRows; row++)
            {
                table[row] = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            var command = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var header = command[1];
            var headerRow = table[0];
            var headerIndex = Array.IndexOf(table[0], header);

            if (command[0] == "hide")
            {
                for (int row = 0; row < table.Length; row++)
                {
                    var rowData = new List<string>();

                    for (int col = 0; col < table[row].Length; col++)
                    {
                        if (col == headerIndex)
                        {
                            continue;
                        }

                        rowData.Add(table[row][col]);
                    }

                    Console.WriteLine(string.Join(" | ", rowData));
                }
            }
            else if (command[0] == "sort")
            {
                Console.WriteLine(string.Join(" | ", headerRow));

                table = table.OrderBy(x => x[headerIndex]).ToArray();

                for (int row = 0; row < tableRows; row++)
                {
                    if (table[row] != headerRow)
                    {
                        Console.WriteLine(string.Join(" | ", table[row]));
                    }
                }
            }
            else if (command[0] == "filter")
            {
                Console.WriteLine(string.Join(" | ", headerRow));
                var value = command[2];

                for (int row = 0; row < tableRows; row++)
                {
                    if (table[row][headerIndex] == value)
                    {
                        Console.WriteLine(string.Join(" | ", table[row]));
                    }
                }
            }
        }
    }
}
