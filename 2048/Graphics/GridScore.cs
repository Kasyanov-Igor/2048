using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _2048
{
	public class GridScore : GridGame
	{
		public GridScore() : base()
		{
			this.ColumnDefinitions.Add(new ColumnDefinition());
			this.ColumnDefinitions.Add(new ColumnDefinition());

			this.Render();

			this.ShowGridLines = true;
			this.Background = this.Background = new SolidColorBrush(Colors.LightGray);

		}

		public override void Render()
		{
			for (byte i = 0; i < 2; i++)
			{
				TextBlock textBox = new TextBlock { };
				textBox.HorizontalAlignment = HorizontalAlignment.Center;
				textBox.VerticalAlignment = VerticalAlignment.Center;
				textBox.FontSize = 30;

				if (i == 0)
				{
					textBox.Text = "RECORD - " + "2024";
				}
				if (i == 1)
				{
					textBox.Text = "GLASSES - " + Convert.ToString(this._gameField.GetGameСount());
				}
				Grid.SetColumn(textBox, i);
				this.Children.Add(textBox);
			}

		}

		public override void Drawing()
		{
			this.Children.Clear();

			this.Render();

		}
	}
}
