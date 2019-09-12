using System;
using System.Linq;

namespace JaggedArrayModifications
{
    public class Program
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            var jaggedArray = new int[size][];

            for (int i = 0; i < size; i++)
            {
                var subArray = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[i] = subArray;
            }

            var command = Console.ReadLine().Split();

            while (command[0] != "END")
            {
                var row = int.Parse(command[1]);
                var position = int.Parse(command[2]);
                var value = int.Parse(command[3]);

                if(row<0
                    ||row>size-1
                    ||position<0
                    || position > jaggedArray[row].Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (command[0] == "Add")
                {
                    jaggedArray[row][position] += value;
                }
                else
                {
                    jaggedArray[row][position] -= value;
                }

                command = Console.ReadLine().Split();
            }

            foreach (var subArray in jaggedArray)
            {
                Console.WriteLine(string.Join(" ",subArray));
            }
        }
    }
}
