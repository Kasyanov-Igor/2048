using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace _2048
{
	public class LogicGameField
	{
		private readonly uint[,] _field; //! Game field

		public const byte COUNT_ROWS = 4; //! Count rows in game

		public const byte COUNT_COLLUMNS = 4; //! Count collums in game

		private uint _gameСount = 0; //! Count score game

		public delegate void RenderScore();

		public event RenderScore OnRenderScore;

		public delegate void RenderGameFild();

		public event RenderGameFild OnRenderGameFild;

		public LogicGameField()
		{
			this._field = new uint[COUNT_ROWS, COUNT_COLLUMNS];

			for (int i = 0; i < COUNT_ROWS; i++)
			{
				for (int k = 0; k < COUNT_COLLUMNS; k++)
				{
					this._field[i, k] = 0;
				}
			}
		}

		/*! 
		* @brief Creates 90 percent of the digit 2, 10 percent of the digit 4 and places it on the playing field.
		*/
		public bool AddField()
		{
			Random random = new Random();
			byte randRow = Convert.ToByte(random.Next(COUNT_ROWS)); //! Random row number
			byte randCollumn = Convert.ToByte(random.Next(COUNT_COLLUMNS)); //! Random collum number

			if (this._field[randRow, randCollumn] == 0)
			{
				if (random.Next(100) > 10)
				{
					this._field[randRow, randCollumn] = 2; //! Adding a number to a field
				}
				else
				{
					this._field[randRow, randCollumn] = 4; //! Adding a number to a field
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
								this._field[i, j] = 2; //! Adding a number to a field
							}
							else
							{
								this._field[i, j] = 4; //! Adding a number to a field
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
								this._field[i, j] = 2; //! Adding a number to a field
							}
							else
							{
								this._field[i, j] = 4; //! Adding a number to a field
							}
							return true;
						}
					}
				}

			}
			return false;
		}

		/*! 
		* @brief Moves all pieces in an upward direction.
		* @return True - when moving plates; False - plate movement is not possible.
		*/
		public bool PushUp()
		{
			bool checkMove = false;

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
							/*! 
							* @if The cells are the same.
							*	 Add the figures and add them to the gameCount.
							* @endif
							*/
							if (this._field[doubleI, j] == this._field[doubleI - 1, j])
							{
								this._field[doubleI - 1, j] *= 2;
								this._field[doubleI, j] = 0;
								this._gameСount += this._field[doubleI - 1, j];
								checkMove = true;
								break;
							}
							/*! 
						  * @else if The empty cell .
						  *		Move the cells in the direction.
						  * @endif
						  */
							else if (this._field[doubleI - 1, j] == 0)
							{
								uint val = this._field[doubleI, j];
								this._field[doubleI, j] = this._field[doubleI - 1, j];
								this._field[doubleI - 1, j] = val;
								checkMove = true;
								doubleI--;
							}
						}
					}
				}
			}
			return checkMove;
		}

		/*! 
		* @brief Moves all pieces in an doun direction.
		* @return True - when moving plates; False - plate movement is not possible.
		*/
		public bool PushDown()
		{
			bool checkMove = false;

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
							/*! 
							* @if The cells are the same.
							*	 Add the figures and add them to the gameCount.
							* @endif
							*/
							if (this._field[doubleI, j] == this._field[doubleI + 1, j])
							{
								this._field[doubleI + 1, j] *= 2;
								this._field[doubleI, j] = 0;
								this._gameСount += this._field[doubleI + 1, j];
								checkMove = true;
								break;
							}
							/*! 
							* @else if The empty cell .
							*		Move the cells in the direction.
							* @endif
							*/
							else if (this._field[doubleI + 1, j] == 0)
							{
								uint val = this._field[doubleI, j];
								this._field[doubleI, j] = this._field[doubleI + 1, j];
								this._field[doubleI + 1, j] = val;
								checkMove = true;
								doubleI++;
							}
						}
					}
				}


			}
			return checkMove;
		}

		/*! 
		* @brief Moves all pieces in an rith direction.
		* @return True - when moving plates; False - plate movement is not possible.
		*/
		public bool PushRight()
		{
			bool checkMove = false;

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
							/*! 
							* @if The cells are the same.
							*	 Add the figures and add them to the gameCount.
							* @endif
							*/
							if (this._field[j, doubleI] == this._field[j, doubleI + 1])
							{
								this._field[j, doubleI + 1] *= 2;
								this._field[j, doubleI] = 0;
								this._gameСount += this._field[j, doubleI + 1];
								checkMove = true;
								break;
							}
							/*! 
							* @else if The empty cell .
							*		Move the cells in the direction.
							* @endif
							*/
							else if (this._field[j, doubleI + 1] == 0)
							{
								uint val = this._field[j, doubleI];
								this._field[j, doubleI] = this._field[j, doubleI + 1];
								this._field[j, doubleI + 1] = val;
								checkMove = true;
								doubleI++;
							}
						}
					}
				}
			}
			return checkMove;
		}

		/*! 
		* @brief Moves all pieces in an left direction.
		* @return True - when moving plates; False - plate movement is not possible.
		*/
		public bool PushLeft()
		{
			bool checkMove = false;

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
							/*! 
							* @if The cells are the same.
							*	 Add the figures and add them to the gameCount.
							* @endif
							*/
							if (this._field[j, doubleI] == this._field[j, doubleI - 1])
							{
								this._field[j, doubleI - 1] *= 2;
								this._field[j, doubleI] = 0;
								this._gameСount += this._field[j, doubleI - 1];
								checkMove = true;
								break;
							}
							/*! 
							* @else if The empty cell .
							*		Move the cells in the direction.
							* @endif
							*/
							else if (this._field[j, doubleI - 1] == 0)
							{
								uint val = this._field[j, doubleI];
								this._field[j, doubleI] = this._field[j, doubleI - 1];
								this._field[j, doubleI - 1] = val;
								checkMove = true;
								doubleI--;
							}
						}
					}
				}
			}
			return checkMove;
		}

		/*! 
		* @brief Checking for empty cells.
		* @return True - there are empty cells; False - there are no empty cells.
		*/
		public bool IsEmptyCell()
		{
			for (int i = 0; i < COUNT_ROWS; i++)
			{
				for (int j = 0; j < COUNT_COLLUMNS; j++)
				{
					if (_field[i, j] == 0)
					{
						return true;
					}
				}
			}
			return false;
		}

		/*! 
		* @brief Checking for wins or losses in the game.
		* @return True - win or lose, end game; False - game on.
		*/
		public bool GameWinAndOver()
		{
			for (int i = 0; i < COUNT_ROWS; i++)
			{
				for (int j = 0; j < COUNT_COLLUMNS; j++)
				{
					if (_field[i, j] == 2048)
					{
						MessageBox.Show(" You win !!! ");
						return true;
					}
					if (!this.IsEmptyCell() && !this.PushDown() && !this.PushUp() && !this.PushRight() && !this.PushLeft())
					{
						MessageBox.Show("Game over");
						return true;
					}
				}
			}
			return false;
		}

		/*! 
		* @brief When the button is pressed, it implements the movement of all the plates in a certain direction.
		*/
		public void TextBox_Key(object sender, KeyEventArgs e)
		{
			switch (e.Key)
			{
				case Key.Left:

					if (this.PushLeft())
					{
						this.AddField();
					}
					break;

				case Key.Right:

					if (this.PushRight())
					{
						this.AddField();
					}
					break;

				case Key.Up:

					if (this.PushUp())
					{
						this.AddField();
					}
					break;

				case Key.Down:

					if (this.PushDown())
					{
						this.AddField();
					}
					break;
			}

			if (this.GameWinAndOver())
			{
				this.SaveData("Score");
			}

			this.OnRenderGameFild?.Invoke();
			this.OnRenderScore?.Invoke();
		}

		/*! 
		* @brief Saving the best result of the game to a file, in the absence of a file creates it.
		*/
		private void SaveData(string fileName, string directory = "./", string format = ".txt")
		{
			string filePath = Path.Combine(directory, fileName + format);  //!< File path

			string firstLine = null; //!< File contents

			if (File.Exists(filePath) == false)
			{
				using (FileStream file = File.Create(filePath)) { }  //!< Create file
				using (StreamWriter writer = new StreamWriter(filePath))
				{
					writer.WriteLine("0");

					writer.Close();
				}
			}

			if (File.Exists(filePath)) //!< File opening check
			{
				using (StreamReader reader = new StreamReader(filePath))
				{
					firstLine = reader.ReadLine(); //!< Reading file

					reader.Close();
				}
			}

			if (Convert.ToUInt32(firstLine) < this.GetGameСount())
			{
				using (StreamWriter writer = new StreamWriter(filePath))
				{
					writer.WriteLine(this.GetGameСount()); //!< Writer in file

					writer.Close();
				}
			}
		}

		public uint[,] GetField()
		{
			return this._field;
		}

		public uint GetGameСount()
		{
			return this._gameСount;
		}
	}
}
