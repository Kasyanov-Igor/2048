using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _2048
{
	public class GridScore : Grid
	{
		public LogicGameField _gameField;
		public GridScore(Window parentElement, LogicGameField gameField)
		{
			this._gameField = gameField; ;

			this.ColumnDefinitions.Add(new ColumnDefinition());
			this.ColumnDefinitions.Add(new ColumnDefinition());

			this.Height = parentElement.Width * 0.15;

			this.Render();

			this.ShowGridLines = true;
			this.Background = this.Background = new SolidColorBrush(Colors.LightGray);

		}

		public void Render()
		{
			for (byte i = 0; i < 2; i++)
			{
				TextBlock textBox = new TextBlock { };
				textBox.HorizontalAlignment = HorizontalAlignment.Center;
				textBox.VerticalAlignment = VerticalAlignment.Center;
				textBox.FontSize = 30;

				if (i == 0)
				{
					string filePath = "./Score.txt";

					string score = null;

					if (File.Exists(filePath) == true)
					{
						using (StreamReader reader = new StreamReader(filePath))
						{
							score = reader.ReadLine();

							reader.Close();
						}
					}
					textBox.Text = "RECORD - " + score;


					}
				if (i == 1)
				{
					textBox.Text = "GLASSES - " + Convert.ToString(this._gameField.GetGameСount());
				}
				Grid.SetColumn(textBox, i);
				this.Children.Add(textBox);
			}

		}

		public void Drawing()
		{
			this.Children.Clear();

			this.Render();

		}
	}
}
