using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System;

namespace _2048
{
	public class GraphicalRectangle : Border
	{
		private double fontSize; //! Size text in TextBlock
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

		/*! 
		* @brief Setting a specific cell color, depending on the number.
		*/
		public void GetColor(uint number)
		{
			switch (number)
			{
				case 2:

					this.Background = new SolidColorBrush(Color.FromArgb(24, 153, 0, 0)); //! LightSalmon color

					break;

				case 4:

					this.Background = new SolidColorBrush(Color.FromArgb(72, 153, 0, 0)); //! DarkSalmon color

					break;
				case 8:

					this.Background = new SolidColorBrush(Color.FromArgb(96, 153, 0, 0)); //! DarkSalmon color

					break;

				case 16:

					this.Background = new SolidColorBrush(Color.FromArgb(120, 153, 0, 0)); //! Salmon color

					break;
				case 32:

					this.Background = new SolidColorBrush(Color.FromArgb(144, 153, 0, 0)); //! Salmon color

					break;

				case 64:

					this.Background = new SolidColorBrush(Color.FromArgb(168, 153, 0, 0)); //! LightSalmon color

					break;
				case 128:

					this.Background = new SolidColorBrush(Color.FromArgb(192, 153, 0, 0)); //! LightSalmon color

					break;

				case 256:

					this.Background = new SolidColorBrush(Color.FromArgb(216, 153, 0, 0)); //! LightCoral color

					break;
				case 512:

					this.Background = new SolidColorBrush(Color.FromArgb(230, 204, 0, 0)); //! LightCoral color

					break;

				case 1024:

					this.Background = new SolidColorBrush(Color.FromArgb(240, 204, 0, 0)); //! IndianRed color

					break;

				case 2048:

					this.Background = new SolidColorBrush(Color.FromArgb(255, 204, 0, 0)); //! FireBrick color

					break;
			}
		}
	}
}