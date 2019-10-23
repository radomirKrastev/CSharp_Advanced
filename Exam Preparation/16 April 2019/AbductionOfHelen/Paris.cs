namespace AbductionOfHelen
{
    public class Paris
    {
        private int energy;

        public Paris(int energy)
        {
            this.energy = energy;
            this.IsAlive = this.energy > 0;
            this.SavedHelen = false;
            this.Position = new int[2];
        }

        public int Energy => this.energy;
        public bool IsAlive { get; private set; }
        public bool SavedHelen { get; private set; }
        public int[] Position { get; set; }

        public void Move(char[][] matrix, string direction)
        {
            var destinedRow = this.Position[0];
            var destinedCol = this.Position[1];

            if (direction == "up")
            {
                destinedRow -= 1;
            }
            else if (direction == "down")
            {
                destinedRow += 1;
            }
            else if (direction == "left")
            {
                destinedCol -= 1;
            }
            else if (direction == "right")
            {
                destinedCol += 1;
            }

            this.energy -= 1;

            if (ValidatePosition(matrix, destinedRow, destinedCol))
            {
                MovePosition(matrix, destinedRow, destinedCol);
                AdjustField(matrix);
            }

            if (this.energy <= 0 && this.SavedHelen == false)
            {
                this.IsAlive = false;
                matrix[this.Position[0]][this.Position[1]] = 'X';
            }
        }

        private void AdjustField(char[][] matrix)
        {
            if (matrix[this.Position[0]][this.Position[1]] == 'S')
            {
                FightEnemy(matrix);
            }
            else if (matrix[this.Position[0]][this.Position[1]] == 'H')
            {
                matrix[this.Position[0]][this.Position[1]] = '-';
                this.SavedHelen = true;
            }
            else if (matrix[this.Position[0]][this.Position[1]] == '-')
            {
                matrix[this.Position[0]][this.Position[1]] = 'P';
            }
        }

        private void MovePosition(char[][] matrix, int destinedRow, int destinedCol)
        {
            matrix[this.Position[0]][this.Position[1]] = '-';
            this.Position[0] = destinedRow;
            this.Position[1] = destinedCol;
        }

        private void FightEnemy(char[][] matrix)
        {
            this.energy -= 2;
            matrix[this.Position[0]][this.Position[1]] = 'P';
        }

        private bool ValidatePosition(char[][] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row <= matrix.GetUpperBound(0) && col < matrix[row].Length;
        }
    }
}
