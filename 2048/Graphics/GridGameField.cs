using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace _2048
{
	public class GridGameField : GridGame
	{
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

			//this.ShowGridLines = true;
		   this.Background = this.Background = new SolidColorBrush(Colors.DarkGray);


			this.Render();
		}


		public override void Render()
		{
			uint[,] logicalGameField = this._gameField.GetField();

			for (int i = 0; i < LogicGameField.COUNT_ROWS; i++)
			{
				for (int k = 0; k < LogicGameField.COUNT_COLLUMNS; ++k)
				{
					//if (logicalGameField[i, k] != 0)
					//{
						GraphicalTile textBox = new GraphicalTile(logicalGameField[i, k], this);
					
						Grid.SetRow(textBox, i);
						Grid.SetColumn(textBox, k);
						this.Children.Add(textBox);
					//}
				

					//	Line line = new Line();
					//line.StrokeThickness = 10;
					//	//line.X1 = 0;
					//	//line.Y1 = 0;
					//	line.X2 = 500;
					//	//line.Y2 = 0;

					//	line.Stroke = new SolidColorBrush(Colors.Black);
					//Grid.SetRow(line, i);
					//Grid.SetColumn(line, k);

					//this.Children.Add(line);

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
