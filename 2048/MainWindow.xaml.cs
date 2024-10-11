using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace _2048
{
	public partial class MainWindow : Window
	{
		private StackPanel _wind;

		private GridGame _gameField;//???????????????

		private GridGame _score;
		public MainWindow()
		{
			InitializeComponent();

			this._gameField = new GridGameField(this);

			this._score = new GridScore();

			this._wind = new StackPanel() { Orientation = Orientation.Vertical };

			this._wind.Children.Add(this._score);

			this._wind.Children.Add(this._gameField);

			this.Content = _wind;

			//this._score.Drawing();



			this.KeyUp += _gameField.TextBox_Key;
			this.KeyUp += _score.TextBox_Key;

		}

	}
}
