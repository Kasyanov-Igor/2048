using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace _2048
{
	public class GridGameField : Grid
	{
		public delegate void RenderScore();

		public event RenderScore OnRenderScore;

		public LogicGameField _gameField; //! An instance of the class responsible for the logic of the game

		public GridGameField(Window parentElement)
		{
			for (byte i = 0; i < LogicGameField.COUNT_ROWS; i++)
			{
				this.RowDefinitions.Add(new RowDefinition()); //! Add row to grid
				this.ColumnDefinitions.Add(new ColumnDefinition()); //! Add colum to grid
			}

			_gameField = new LogicGameField();

			this._gameField.AddField();
			this._gameField.AddField();

			this.Height = parentElement.Width * 0.9; //! Height adjustment depending on the window
			this.Width = parentElement.Width * 0.9; //! Width adjustment depending on the window

			this.Margin = new Thickness(10);

			this.Background = new SolidColorBrush(Colors.DarkGray); //! Setting the background

			this.Render();
		}

		/*! 
		* @brief Visual rendering of cells.
		*/
		public void Render()
		{
			uint[,] logicalGameField = this._gameField.GetField();

			for (int i = 0; i < LogicGameField.COUNT_ROWS; i++)
			{
				for (int k = 0; k < LogicGameField.COUNT_COLLUMNS; ++k)
				{
					if (logicalGameField[i, k] == 2048)
					{
						MessageBox.Show(" You win !!! ");
					}
					GraphicalRectangle textBox = new GraphicalRectangle(logicalGameField[i, k], this); //!< Class instance with text

					Grid.SetRow(textBox, i); //! Placement instance in row to grid
					Grid.SetColumn(textBox, k); //! Placement instance in row to grid
					this.Children.Add(textBox); //! Add instance to grid
				}
			}
		}

		/*! 
		* @brief When the button is pressed, it implements the movement of all the plates in a certain direction.
		*/
		public void TextBox_Key(object sender, KeyEventArgs e)
		{
			switch (e.Key)
			{
				case Key.Left:

					if (this._gameField.PushLeft())
					{
						this._gameField.AddField();
					}
					break;

				case Key.Right:

					if (this._gameField.PushRight())
					{
						this._gameField.AddField();
					}
					break;

				case Key.Up:

					if (this._gameField.PushUp())
					{
						this._gameField.AddField();
					}
					break;

				case Key.Down:

					if (this._gameField.PushDown())
					{
						this._gameField.AddField();
					}
					break;
			}
			this.Drawing();

			if (!this._gameField.IsEmptyCell() && !this._gameField.PushDown() && !this._gameField.PushUp() && !this._gameField.PushRight() && !this._gameField.PushLeft())
			{
				MessageBox.Show("Game over");
				this.SaveData("Score");
			}

			this.OnRenderScore?.Invoke();
		}

		/*! 
		* @brief Сlearing the previous drawing and drawing a new one.
		*/
		public void Drawing()
		{
			this.Children.Clear();

			this.Render();
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

			if (Convert.ToUInt32(firstLine) < this._gameField.GetGameСount())
			{
				using (StreamWriter writer = new StreamWriter(filePath))
				{
					writer.WriteLine(this._gameField.GetGameСount()); //!< Writer in file

					writer.Close();
				}
			}
		}


	}
}

