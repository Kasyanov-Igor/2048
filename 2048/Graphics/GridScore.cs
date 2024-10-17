using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _2048
{
	public class GridScore : Grid
	{
		public LogicGameField _gameField; //! An instance of the class responsible for the logic of the game
		public GridScore(Window parentElement, LogicGameField gameField)
		{
			this._gameField = gameField;

			this.ColumnDefinitions.Add(new ColumnDefinition());
			this.ColumnDefinitions.Add(new ColumnDefinition());

			this.Height = parentElement.Width * 0.15;

			this.Render();

			this.ShowGridLines = true;
			this.Background = this.Background = new SolidColorBrush(Colors.LightGray);
		}

		/*! 
		* @brief Visual rendering of cells.
		*/
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
					string filePath = "./Score.txt"; //! Path to file

					string score = "0"; //! Game score

					if (File.Exists(filePath) == true)
					{
						using (StreamReader reader = new StreamReader(filePath))
						{
							score = reader.ReadLine(); //! Reader to text in file

							reader.Close();
						}
					}

					textBox.Text = "RECORD - " + score;
				}
				if (i == 1)
				{
					textBox.Text = "GLASSES - " + Convert.ToString(this._gameField.GetGameСount()); //! Сurrent game score
				}
				Grid.SetColumn(textBox, i); //! Placement instance in colum to grid
				this.Children.Add(textBox); //! Add textBlox int this grid
			}

		}

		/*! 
		* @brief Сlearing the previous drawing and drawing a new one.
		*/
		public void Drawing()
		{
			this.Children.Clear();

			this.Render();

		}
	}
}