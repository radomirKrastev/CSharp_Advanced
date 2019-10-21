using System.Collections.Generic;

namespace SpaceStationEstablishment
{
    public class Spaceship
    {
        public Spaceship()
        {
            this.Position = new int[2];
            this.PositionInBorders = true;
        }

        public int[] Position { get; private set; }
        public int StarPower { get; private set; }
        public bool PositionInBorders { get; private set; }

        public void Move(char[,] matrix, string direction, Dictionary<int, int[]> blackHoles)
        {
            var row = this.Position[0];
            var col = this.Position[1];

            if (direction == "up")
            {
                var destinationRow = this.Position[0] - 1;
                var destinationCol = this.Position[1];

                MoveSpaceship(matrix, destinationRow, destinationCol, row, col, blackHoles);
            }
            else if (direction == "down")
            {
                var destinationRow = this.Position[0] + 1;
                var destinationCol = this.Position[1];

                MoveSpaceship(matrix, destinationRow, destinationCol, row, col, blackHoles);
            }
            else if (direction == "right")
            {
                var destinationRow = this.Position[0];
                var destinationCol = this.Position[1] + 1;

                MoveSpaceship(matrix, destinationRow, destinationCol, row, col, blackHoles);
            }
            else if (direction == "left")
            {
                var destinationRow = this.Position[0];
                var destinationCol = this.Position[1] - 1;

                MoveSpaceship(matrix, destinationRow, destinationCol, row, col, blackHoles);
            }
        }

        private void MoveSpaceship(char[,] matrix, int destinationRow, int destinationCol, int row, int col, Dictionary<int, int[]> blackHoles)
        {
            if (CheckOutOfBorders(matrix, destinationRow, destinationCol))
            {
                PositionInBorders = false;
                matrix[row, col] = '-';
                return;
            }

            if (matrix[destinationRow, destinationCol] == 'O')
            {
                matrix[row, col] = '-';
                ActivateBlackHoles(matrix, destinationRow, destinationCol, blackHoles);
            }
            else if (matrix[destinationRow, destinationCol] == '-')
            {
                matrix[row, col] = '-';
                matrix[destinationRow, destinationCol] = 'S';

                AdjustCurrentPosition(destinationRow, destinationCol);
            }
            else if (int.TryParse((matrix[destinationRow, destinationCol]).ToString(), out int starPower))
            {
                matrix[row, col] = '-';
                matrix[destinationRow, destinationCol] = 'S';
                this.StarPower += starPower;

                AdjustCurrentPosition(destinationRow, destinationCol);                
            }
        }

        private void AdjustCurrentPosition(int row, int col)
        {
            this.Position[0] = row;
            this.Position[1] = col;
        }

        private void ActivateBlackHoles(char[,] matrix, int destinationRow, int destinationCol, Dictionary<int, int[]> blackHoles)
        {
            var currentBlackHole = -1;

            foreach (var blackHole in blackHoles)
            {
                if (blackHole.Value[0] == destinationRow && blackHole.Value[1] == destinationCol)
                {
                    matrix[blackHole.Value[0], blackHole.Value[1]] = '-';
                    currentBlackHole = blackHole.Key;
                }
            }

            blackHoles.Remove(currentBlackHole);

            foreach (var blackHole in blackHoles)
            {
                matrix[blackHole.Value[0], blackHole.Value[1]] = 'S';

                AdjustCurrentPosition(blackHole.Value[0], blackHole.Value[1]);
            }
        }

        private bool CheckOutOfBorders(char[,] matrix, int row, int col)
        {
            var rows = matrix.GetUpperBound(0) + 1;
            var cols = matrix.GetUpperBound(1) + 1;

            return row < 0 || col < 0 || row >= rows || col >= cols;
        }
    }
}
