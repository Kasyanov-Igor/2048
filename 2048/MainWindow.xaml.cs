using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _2048
{
	public partial class MainWindow : Window
	{
		private StackPanel _gameWindow;

		private GridGame _gameField;

		private GridGame _gameScore;
		public MainWindow()
		{
			InitializeComponent();

			this.Background = new SolidColorBrush(Colors.LightGray);

			this._gameField = new GridGameField(this);

			this._gameScore = new GridScore(this, this._gameField._gameField);

			this._gameWindow = new StackPanel() { Orientation = Orientation.Vertical };

			this._gameWindow.Children.Add(this._gameScore);

			this._gameWindow.Children.Add(this._gameField);

			this.Content = _gameWindow;

			this.KeyUp += _gameField.TextBox_Key;

			this._gameField.OnRenderScore += this._gameScore.Drawing;
		}

	}
}
