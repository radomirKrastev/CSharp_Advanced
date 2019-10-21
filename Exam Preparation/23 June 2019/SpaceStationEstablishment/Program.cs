using System;

namespace SpaceStationEstablishment
{
    public class Program
    {
        public static void Main()
        {
            var squareMatrixSize = int.Parse(Console.ReadLine());
            var rows = squareMatrixSize;
            var cols = squareMatrixSize;

            var space = new Space();
            var spaceship = new Spaceship();
            space.InitializeMatrix(rows, cols, spaceship);
            
            while(spaceship.PositionInBorders==true && spaceship.StarPower < 50)
            {
                var direction = Console.ReadLine();
                spaceship.Move(space.Matrix, direction, space.BlackHoles);
            }

            PrintOutput(spaceship, space);            
        }

        private static void PrintOutput(Spaceship spaceship, Space space)
        {
            if (spaceship.PositionInBorders == false)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }
            else
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }

            Console.WriteLine($"Star power collected: {spaceship.StarPower}");

            Console.WriteLine(space);
        }
    }
}
