using System;

namespace SeashellTreasure
{
    public class Seagull
    {
        public Seagull()
        {

        }

        public int SeashellsStolen { get; private set; }

        public void Steal(Beach beach, int row, int col)
        {
            if (Char.IsLetter(beach.Matrix[row][col]))
            {
                SeashellsStolen++;
                beach.Matrix[row][col] = '-';
            }            
        }
    }
}
