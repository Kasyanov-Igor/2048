using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _2048
{
	public class LogicGameField
	{
		private readonly uint[,] _field;

		public const byte COUNT_ROWS = 4;

		public const byte COUNT_COLLUMNS = 4;

		private uint _gameСount = 0;

		Random random = new Random();

		public LogicGameField()
		{
			this._field = new uint[COUNT_ROWS, COUNT_COLLUMNS];

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
			byte randRow = Convert.ToByte(random.Next(COUNT_ROWS));
			byte randCollumn = Convert.ToByte(random.Next(COUNT_COLLUMNS));

			if (this._field[randRow, randCollumn] == 0)
			{
				if (random.Next(100) > 10)
				{
					this._field[randRow, randCollumn] = 2;
				}
				else
				{
					this._field[randRow, randCollumn] = 4;
				}
				return true;
			}
			else
			{
				for (int i = randRow; i < COUNT_ROWS; i++)
				{
					for (int j = randCollumn; j < COUNT_COLLUMNS; j++)
					{
						if (this._field[i, j] == 0)
						{
							if (random.Next(100) > 10)
							{
								this._field[i, j] = 2;
							}
							else
							{
								this._field[i, j] = 4;
							}
							return true;
						}
					}
				}
				for (int i = 0; i < COUNT_ROWS; i++)
				{
					for (int j = 0; j < COUNT_COLLUMNS; j++)
					{
						if (this._field[i, j] == 0)
						{
							if (random.Next(100) > 10)
							{
								this._field[i, j] = 2;
							}
							else
							{
								this._field[i, j] = 4;
							}
							return true;
						}
					}
				}

			}
			return false;
		}

		public void PushUp()
		{
			for (int i = 1; i < COUNT_ROWS; i++)
			{
				for (int j = 0; j < COUNT_COLLUMNS; j++)
				{
					if (this._field[i, j] != 0)
					{
						int doubleI = i;

						while (doubleI > 0)
						{
							if (this._field[doubleI, j] != this._field[doubleI - 1, j] && this._field[doubleI - 1, j] != 0)
							{
								break;
							}

							if (this._field[doubleI, j] == this._field[doubleI - 1, j])
							{
								this._field[doubleI - 1, j] *= 2;
								this._field[doubleI, j] = 0;
								this._gameСount += this._field[doubleI - 1, j];
								break;
							}
							else if (this._field[doubleI - 1, j] == 0)
							{
								uint val = this._field[doubleI, j];
								this._field[doubleI, j] = this._field[doubleI - 1, j];
								this._field[doubleI - 1, j] = val;
								doubleI--;
							}
						}
					}
				}
			}
		}

		public void PushDown()
		{
			for (int i = 2; i >= 0; i--)
			{
				for (int j = 0; j < COUNT_ROWS; j++)
				{
					if (this._field[i, j] != 0)
					{
						int doubleI = i;

						while (doubleI < COUNT_COLLUMNS - 1)
						{
							if (this._field[doubleI, j] != this._field[doubleI + 1, j] && this._field[doubleI + 1, j] != 0)
							{
								break;
							}
							if (this._field[doubleI, j] == this._field[doubleI + 1, j])
							{
								this._field[doubleI + 1, j] *= 2;
								this._field[doubleI, j] = 0;
								this._gameСount += this._field[doubleI + 1, j];
								break;
							}
							else if (this._field[doubleI + 1, j] == 0)
							{
								uint val = this._field[doubleI, j];
								this._field[doubleI, j] = this._field[doubleI + 1, j];
								this._field[doubleI + 1, j] = val;
								doubleI++;
							}
						}
					}
				}


			}

		}

		public void PushRight()
		{

			for (int i = 2; i >= 0; i--)
			{
				for (int j = 0; j < COUNT_ROWS; j++)
				{
					if (this._field[j, i] != 0)
					{
						int doubleI = i;

						while (doubleI < COUNT_COLLUMNS - 1)
						{
							if (this._field[j, doubleI] != this._field[j, doubleI + 1] && this._field[j, doubleI + 1] != 0)
							{
								break;
							}

							if (this._field[j, doubleI] == this._field[j, doubleI + 1])
							{
								this._field[j, doubleI + 1] *= 2;
								this._field[j, doubleI] = 0;
								this._gameСount += this._field[j, doubleI + 1];
								break;
							}
							else if (this._field[j, doubleI + 1] == 0)
							{
								uint val = this._field[j, doubleI];
								this._field[j, doubleI] = this._field[j, doubleI + 1];
								this._field[j, doubleI + 1] = val;
								doubleI++;
							}
						}
					}
				}
			}
		}

		public void PushLeft()
		{
			for (int i = 1; i < COUNT_ROWS; i++)
			{
				for (int j = 0; j < COUNT_COLLUMNS; j++)
				{
					if (this._field[j, i] != 0)
					{
						int doubleI = i;

						while (doubleI > 0)
						{
							if (this._field[j, doubleI] != this._field[j, doubleI - 1] && this._field[j, doubleI - 1] != 0)
							{
								break;
							}

							if (this._field[j, doubleI] == this._field[j, doubleI - 1])
							{
								this._field[j, doubleI - 1] *= 2;
								this._field[j, doubleI] = 0;
								this._gameСount += this._field[j, doubleI - 1];
								break;
							}
							else if (this._field[j, doubleI - 1] == 0)
							{
								uint val = this._field[j, doubleI];
								this._field[j, doubleI] = this._field[j, doubleI - 1];
								this._field[j, doubleI - 1] = val;
								doubleI--;
							}
						}
					}
				}
			}
		}

		public uint[,] GetField()
		{
			return this._field;

		}

	}
}
