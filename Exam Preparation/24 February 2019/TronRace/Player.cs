namespace TronRace
{
    public class Player
    {
        public Player(char trail)
        {
            this.IsAlive = true;
            this.Trail = trail;
            this.Position = new int[2];
        }

        public int[] Position { get; set; }
        public bool IsAlive { get; private set; }
        public char Trail { get; set; }

        public void Move(char[,] matrix,string direction)
        {
            var destinateRow = this.Position[0];
            var destinateCol = this.Position[1];

            if (direction == "up")
            {
                destinateRow -= 1;

                if (!InBorderValidator(matrix, destinateRow, destinateCol))
                {
                    destinateRow = matrix.GetUpperBound(0);
                }                
            }
            else if(direction == "down")
            {
                destinateRow += 1;

                if (!InBorderValidator(matrix, destinateRow, destinateCol))
                {
                    destinateRow = 0;
                }
            }
            else if(direction == "left")
            {
                destinateCol -= 1;

                if (!InBorderValidator(matrix, destinateRow, destinateCol))
                {
                    destinateCol = matrix.GetUpperBound(1);
                }
            }
            else if(direction == "right")
            {
                destinateCol += 1;

                if (!InBorderValidator(matrix, destinateRow, destinateCol))
                {
                    destinateCol = 0;
                }
            }

            AdjustPosition(destinateRow, destinateCol);
            MoveOrDie(matrix);
        }

        private void MoveOrDie(char[,] matrix)
        {
            if (matrix[this.Position[0], this.Position[1]] != '*' && matrix[this.Position[0], this.Position[1]] != this.Trail)
            {
                matrix[this.Position[0], this.Position[1]] = 'x';
                this.IsAlive = false;
            }
            else
            {
                matrix[this.Position[0], this.Position[1]] = this.Trail;
            }
        }

        private void LeaveTrail(char[,] matrix)
        {
            matrix[this.Position[0], this.Position[1]] = this.Trail;
        }

        private void AdjustPosition(int destinateRow, int destinateCol)
        {
            this.Position[0] = destinateRow;
            this.Position[1] = destinateCol;
        }

        private bool InBorderValidator(char [,] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 && row <= matrix.GetUpperBound(0) && col <= matrix.GetUpperBound(1);
        }
    }
}
