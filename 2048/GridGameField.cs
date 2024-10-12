using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace _2048
{
	public class GridGameField : GridGame
	{
		private const byte CELL_SIZE = 50;

		public GridGameField(Window parentElement) : base()
		{
			for (byte i = 0; i < LogicGameField.COUNT_ROWS; i++)
			{
				this.RowDefinitions.Add(new RowDefinition());
				this.ColumnDefinitions.Add(new ColumnDefinition());
			}

			this._gameField.AddField();
			this._gameField.AddField();

			this.Height = parentElement.Height * 0.80;
			this.Margin = new Thickness(20);

			this.ShowGridLines = true;

			this.Render();
		}

		public override void Render()
		{
			uint[,] logicalGameField = this._gameField.GetField();

			for (int i = 0; i < LogicGameField.COUNT_ROWS; i++)
			{
				for (int k = 0; k < LogicGameField.COUNT_COLLUMNS; ++k)
				{
					if (logicalGameField[i, k] != 0)
					{
						TextBlock textBox = new TextBlock { };

						//textBox.Width = 80;
						//textBox.Width = this.Width / LogicGameField.COUNT_COLLUMNS;

						textBox.FontSize = CELL_SIZE;
						textBox.HorizontalAlignment = HorizontalAlignment.Center;
						textBox.VerticalAlignment = VerticalAlignment.Center;

						textBox.Text = Convert.ToString(logicalGameField[i, k]);

						switch (logicalGameField[i, k])
						{
							case 2:

								textBox.Background = new SolidColorBrush(Color.FromArgb(24, 153, 0, 0));

								break;

							case 4:

								textBox.Background = new SolidColorBrush(Color.FromArgb(72, 153, 0, 0));

								break;
							case 8:

								textBox.Background = new SolidColorBrush(Color.FromArgb(96, 153, 0, 0));

								break;

							case 16:

								textBox.Background = new SolidColorBrush(Color.FromArgb(120, 153, 0, 0));

								break;
							case 32:

								textBox.Background = new SolidColorBrush(Color.FromArgb(144, 153, 0, 0));

								break;

							case 64:

								textBox.Background = new SolidColorBrush(Color.FromArgb(168, 153, 0, 0));

								break;
							case 128:

								textBox.Background = new SolidColorBrush(Color.FromArgb(192, 153, 0, 0));

								break;

							case 256:

								textBox.Background = new SolidColorBrush(Color.FromArgb(216, 153, 0, 0));

								break;
							case 512:

								textBox.Background = new SolidColorBrush(Color.FromArgb(230, 204, 0, 0));

								break;

							case 1024:

								textBox.Background = new SolidColorBrush(Color.FromArgb(240, 204, 0, 0));

								break;

							case 2048:

								textBox.Background = new SolidColorBrush(Color.FromArgb(255, 204, 0, 0));

								break;
						}

						Grid.SetRow(textBox, i);
						Grid.SetColumn(textBox, k);
						this.Children.Add(textBox);
					}
				}
			}
		}


		public override void Drawing()
		{
			this.Children.Clear();

			if (!this._gameField.IsEmptyCell())
			{
				MessageBox.Show("Game over");
			}
			this.Render();
		}
	}
}
