using System.Windows;
using System.Windows.Controls;


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
						GraphicalTile textBox = new GraphicalTile(logicalGameField[i, k], this);
                    
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
