using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _2048
{
	public class GraphicalTile : TextBlock
	{
		private const byte CELL_SIZE = 50;
		public GraphicalTile(uint n, Grid a)
		{
			this.FontSize = CELL_SIZE;
			this.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
			this.VerticalAlignment = System.Windows.VerticalAlignment.Center;

			this.Width = 100;
			this.Height = 105;

			//this.Width = a.Width / LogicGameField.COUNT_COLLUMNS; // ???

			if (n == 0)
			{
				this.Text = " ";

			}

			this.Text = Convert.ToString(n);

			GetColor(n);

		}

		public void GetColor(uint number)
		{
			switch (number)
			{
				case 0:

					this.Background = new SolidColorBrush(Colors.LightGray);
					this.Text = " ";
					break;
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


