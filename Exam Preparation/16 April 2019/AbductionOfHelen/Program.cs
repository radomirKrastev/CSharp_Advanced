using System;

namespace AbductionOfHelen
{
    public class Program
    {
        public static void Main()
        {
            var initialEnergy = int.Parse(Console.ReadLine());
            var rows = int.Parse(Console.ReadLine());;

            var paris = new Paris(initialEnergy);
            var matrix = InitializeMatrix(rows, paris);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        paris.Position[0] = row;
                        paris.Position[1] = col;
                    }
                }
            }

            while (paris.IsAlive == true && paris.SavedHelen == false)
            {
                var command = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var direction = command[0];
                var spartanRow = int.Parse(command[1]);
                var spartanCol = int.Parse(command[2]);

                matrix[spartanRow][spartanCol] = 'S';
                paris.Move(matrix, direction);
            }

            if (paris.SavedHelen == true)
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {paris.Energy}");
            }
            else
            {
                Console.WriteLine($"Paris died at {paris.Position[0]};{paris.Position[1]}.");
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static char[][] InitializeMatrix(int rows, Paris paris)
        {
            var matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine().ToCharArray();

                matrix[row] = line;
            }

            return matrix;
        }
    }
}
