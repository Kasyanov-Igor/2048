using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _2048
{
	public class GridGameField : Grid
	{

		public LogicGameField _gameField; //! An instance of the class responsible for the logic of the game

		public GridGameField(Window parentElement, LogicGameField gameField)
		{
			for (byte i = 0; i < LogicGameField.COUNT_ROWS; i++)
			{
				this.RowDefinitions.Add(new RowDefinition()); //! Add row to grid
				this.ColumnDefinitions.Add(new ColumnDefinition()); //! Add colum to grid
			}

			_gameField = gameField;

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

					GraphicalRectangle textBox = new GraphicalRectangle(logicalGameField[i, k], this); //!< Class instance with text

					Grid.SetRow(textBox, i); //! Placement instance in row to grid
					Grid.SetColumn(textBox, k); //! Placement instance in row to grid
					this.Children.Add(textBox); //! Add instance to grid
				}
			}
		}

		/*! 
		* @brief Сlearing the previous drawing and drawing a new one.
		*/
		public void Drawing()
		{
			this.Children.Clear();

			this.Render();
		}
	}
}

