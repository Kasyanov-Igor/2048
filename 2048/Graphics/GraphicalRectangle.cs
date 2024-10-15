using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System;

namespace _2048
{
	public class GraphicalRectangle : Border
	{
		private double fontSize;
		public GraphicalRectangle(uint number, Grid a)
		{
			this.Width = a.Width / LogicGameField.COUNT_COLLUMNS * 0.90;
			this.Height = a.Height / LogicGameField.COUNT_COLLUMNS * 0.90;

			this.Background = Brushes.LightGray;

			this.CornerRadius = new CornerRadius(20);
			this.Padding = new Thickness(20);

			if (number < 100)
			{
				fontSize = this.Height * 0.5;
			}
			else if (number > 100 && number < 1000)
			{
				fontSize = this.Height * 0.4;
			}
			else
			{
				fontSize = this.Height * 0.3;
			}

			if (number != 0)
			{
				this.Child = new TextBlock
				{
					Text = Convert.ToString(number),
					Foreground = Brushes.Black,
					FontSize = fontSize,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center,
				};
			}
			else
			{
				this.Child = new TextBlock
				{
					Text = String.Empty,
					Foreground = Brushes.Black,
					FontSize = this.Height * 0.5,
				};
			}

			this.GetColor(number);

		}

		public void GetColor(uint number)
		{
			switch (number)
			{
				case 2:

					this.Background = new SolidColorBrush(Color.FromArgb(24, 153, 0, 0));

					break;

				case 4:

					this.Background = new SolidColorBrush(Color.FromArgb(72, 153, 0, 0));

					break;
				case 8:

					this.Background = new SolidColorBrush(Color.FromArgb(96, 153, 0, 0));

					break;

				case 16:

					this.Background = new SolidColorBrush(Color.FromArgb(120, 153, 0, 0));

					break;
				case 32:

					this.Background = new SolidColorBrush(Color.FromArgb(144, 153, 0, 0));

					break;

				case 64:

					this.Background = new SolidColorBrush(Color.FromArgb(168, 153, 0, 0));

					break;
				case 128:

					this.Background = new SolidColorBrush(Color.FromArgb(192, 153, 0, 0));

					break;

				case 256:

					this.Background = new SolidColorBrush(Color.FromArgb(216, 153, 0, 0));

					break;
				case 512:

					this.Background = new SolidColorBrush(Color.FromArgb(230, 204, 0, 0));

					break;

				case 1024:

					this.Background = new SolidColorBrush(Color.FromArgb(240, 204, 0, 0));

					break;

				case 2048:

					this.Background = new SolidColorBrush(Color.FromArgb(255, 204, 0, 0));

					break;
			}
		}
	}
}