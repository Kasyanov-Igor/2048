using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace _2048
{
	public class GameScore : StackPanel
	{
		private LogicGameField _gameField;

		private TextBlock _score;

		private TextBlock _recordscore;
		public GameScore(Window parentElement)
		{
			parentElement.Content = this;

			Orientation = Orientation.Horizontal;
			HorizontalAlignment = HorizontalAlignment.Center;
			VerticalAlignment = VerticalAlignment.Top;

			this._recordscore = new TextBlock { HorizontalAlignment = HorizontalAlignment.Center };
			this._score = new TextBlock { HorizontalAlignment = HorizontalAlignment.Center };

			this.RenderScore();

		}


		public void RenderScore()
		{

			TextBlock score = new TextBlock { HorizontalAlignment = HorizontalAlignment.Center };

			score.FontSize = 50;
			score.Text = "0";
			this.Children.Add(score);

		}


		public void Drawing()
		{
			this.Children.Clear();

			this.RenderScore();

		}

	}
}
