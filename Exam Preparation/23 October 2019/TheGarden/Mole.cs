using System;

namespace TheGarden
{
    public class Mole
    {
        public int VegetablesHarmed { get; private set; }

        public void Harm(char[][] garden, int row, int col)
        {
            if (Char.IsLetter(garden[row][col]))
            {
                garden[row][col] = ' ';
                VegetablesHarmed++;
            }
        }
    }
}
