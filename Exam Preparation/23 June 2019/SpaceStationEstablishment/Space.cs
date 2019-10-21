using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStationEstablishment
{
    public class Space
    {
        public char [,] Matrix { get; private set; }
        public Dictionary<int, int[]> BlackHoles { get; private set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            for (int row = 0; row <= this.Matrix.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= this.Matrix.GetUpperBound(1); col++)
                {
                    output.Append(this.Matrix[row, col]);
                }

                output.AppendLine();
            }

            return output.ToString().TrimEnd();
        }

        public void InitializeMatrix(int rows, int cols, Spaceship spaceship)
        {
            this.Matrix = new char[rows, cols];
            this.BlackHoles = new Dictionary<int, int[]>();

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    this.Matrix[row, col] = line[col];

                    if (this.Matrix[row, col] == 'S')
                    {
                        spaceship.Position[0] = row;
                        spaceship.Position[1] = col;
                    }
                    else if (this.Matrix[row, col] == 'O')
                    {
                        if (this.BlackHoles.Count < 2)
                        {
                            var blackHolePosition = new int[2];
                            blackHolePosition[0] = row;
                            blackHolePosition[1] = col;

                            this.BlackHoles.Add(this.BlackHoles.Count, blackHolePosition);
                        }
                    }
                }
            }
        }
    }
}
