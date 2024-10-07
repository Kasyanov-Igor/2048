using System;

namespace _2048
{
    public class LogicGameField
    {
        private readonly byte[,] _field;

        public const byte COUNT_ROWS = 4;

        public const byte COUNT_COLLUMNS = 4;

        public LogicGameField()
        {
            this._field = new byte[COUNT_ROWS, COUNT_COLLUMNS];

            for (int i = 0; i < COUNT_ROWS; i++)
            {
                for (int k = 0; k < COUNT_COLLUMNS; k++)
                {
                    // Set empty cells
                    this._field[i, k] = 0;
                }
            }
        }

        public bool AddField()
        {
            Random random = new Random();
            byte randRow = Convert.ToByte(random.Next(COUNT_ROWS));
            byte randCollumn = Convert.ToByte(random.Next(COUNT_COLLUMNS));

            while (CheckEmptySells() == true)
            {
                if (this._field[randRow, randCollumn] == 0)
                {
                    this._field[randRow, randCollumn] = 1;

                    return true;
                }
            }
    
            return false;
        }

        public bool CheckEmptySells()
        {
            foreach (byte cell in this._field)
            {
                if (cell == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public byte[,] GetField()
        {
            return this._field;

        }

    }
}
