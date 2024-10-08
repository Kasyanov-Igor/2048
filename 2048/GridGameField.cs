﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _2048
{
	public class GridGameField : Grid
	{
		private LogicGameField _gameField;

		private const byte _cellSize = 50;

		public GridGameField(Window parentElement)
		{
			this._gameField = new LogicGameField();

			parentElement.Content = this;

			for (byte i = 0; i < LogicGameField.COUNT_ROWS; i++)
			{
				RowDefinitions.Add(new RowDefinition());
				ColumnDefinitions.Add(new ColumnDefinition());
			}

			this._gameField.AddField();
			this._gameField.AddField();
			this.RenderGameField();

			this.Margin = new Thickness(10, 100, 10, 10);

			this.ShowGridLines = true;
		}

		public void RenderGameField()
		{
			uint[,] logicalGameField = this._gameField.GetField();

			for (int i = 0; i < LogicGameField.COUNT_ROWS; i++)
			{
				for (int k = 0; k < LogicGameField.COUNT_COLLUMNS; ++k)
				{
					TextBlock textBox = new TextBlock { };

					textBox.FontSize = _cellSize;
					textBox.HorizontalAlignment = HorizontalAlignment.Center;
					textBox.VerticalAlignment = VerticalAlignment.Center;

					if (logicalGameField[i, k] != 0)
					{
						textBox.Text = Convert.ToString(logicalGameField[i, k]);

						Grid.SetRow(textBox, i);
						Grid.SetColumn(textBox, k);
						this.Children.Add(textBox);
					}
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
					this.Drawing();

					break;

				case Key.Right:

					if (this._gameField.PushRight())
					{
						this._gameField.AddField();
					}
					this.Drawing();

					break;

				case Key.Up:

					if (this._gameField.PushUp())
					{
						this._gameField.AddField();
					}
					this.Drawing();

					break;

				case Key.Down:

					if (this._gameField.PushDown())
					{
						this._gameField.AddField();
					}
					this.Drawing();

					break;
			}
		}

		public void Drawing()
		{
			this.Children.Clear();

			if (!this._gameField.IsEmptyCell())
			{
				MessageBox.Show("Game over");
			}

			this.RenderGameField();

		}
	}
}
