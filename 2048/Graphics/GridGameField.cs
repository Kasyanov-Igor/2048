using System;
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

		public LogicGameField _gameField;

		public GridGameField(Window parentElement)
		{
			for (byte i = 0; i < LogicGameField.COUNT_ROWS; i++)
			{
				this.RowDefinitions.Add(new RowDefinition());
				this.ColumnDefinitions.Add(new ColumnDefinition());
			}

			_gameField = new LogicGameField();

			this._gameField.AddField();
			this._gameField.AddField();
			this.Height = parentElement.Width * 0.9;
			this.Width = parentElement.Width * 0.9;
			this.Margin = new Thickness(10);
			//this.ShowGridLines = true;
		   this.Background = new SolidColorBrush(Colors.DarkGray);

			this.Render();
		}


		public void Render()
		{
			uint[,] logicalGameField = this._gameField.GetField();

			for (int i = 0; i < LogicGameField.COUNT_ROWS; i++)
			{
				for (int k = 0; k < LogicGameField.COUNT_COLLUMNS; ++k)
				{				
					GraphicalRectangle textBox = new GraphicalRectangle(Convert.ToString(logicalGameField[i, k]), this);

					Grid.SetRow(textBox, i);
					Grid.SetColumn(textBox, k);
					this.Children.Add(textBox);
				}
			}
		}

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
			}

			this.OnRenderScore?.Invoke();
		}

		public void Drawing()
		{
			this.Children.Clear();

			this.Render();
		}
	}
}
