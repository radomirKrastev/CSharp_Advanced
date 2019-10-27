namespace BookWorm
{
    public class Player
    {
        public Player(string message)
        {
            this.Position = new int[2];
            this.Message = message;
        }

        public int[] Position { get; set; }
        public string Message { get; private set; }

        public void Move(char [,] matrix, string direction)
        {
            var destinateRow = this.Position[0];
            var destinateCol = this.Position[1];

            if (direction == "up")
            {
                destinateRow--;                
            }
            else if (direction == "down")
            {
                destinateRow++;
            }
            else if (direction == "left")
            {
                destinateCol--;
            }
            else if (direction == "right")
            {
                destinateCol++;
            }

            if (!ValidatePosition(destinateRow, destinateCol, matrix.GetLength(0)))
            {
                if (this.Message.Length > 0)
                {
                    if (this.Message.Length == 1)
                    {
                        this.Message = string.Empty;
                    }
                    else
                    {
                        this.Message = this.Message.Substring(0, this.Message.Length - 1);
                    }
                }
            }
            else
            {
                matrix[this.Position[0], this.Position[1]] = '-';

                if(char.IsLetter(matrix[destinateRow, destinateCol]))
                {
                    this.Message += matrix[destinateRow, destinateCol];
                }
                
                this.Position[0] = destinateRow;
                this.Position[1] = destinateCol;

                matrix[this.Position[0], this.Position[1]] = 'P';
            }
        }

        private bool ValidatePosition(int row, int col, int size)
        {
            return row >= 0 && col >= 0 && row < size && col < size;
        }
    }
}
