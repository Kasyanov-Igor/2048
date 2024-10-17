using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _2048
{
	public partial class MainWindow : Window
	{
		private StackPanel _gameWindow;

		private GridGameField _gameField;

		private GridScore _gameScore;

		private LogicGameField _logicGameField;

		public MainWindow()
		{
			InitializeComponent();

            this._logicGameField = new LogicGameField();

            this.Background = new SolidColorBrush(Colors.LightGray);

			this._gameField = new GridGameField(this, this._logicGameField);

			this._gameScore = new GridScore(this, this._logicGameField);

			this._gameWindow = new StackPanel() { Orientation = Orientation.Vertical };

			this._gameWindow.Children.Add(this._gameScore);

			this._gameWindow.Children.Add(this._gameField);

			this.Content = _gameWindow;

			this.KeyUp += _logicGameField.TextBox_Key;
			this._logicGameField.OnRenderScore += this._gameScore.Drawing;
			this._logicGameField.OnRenderGameFild += this._gameField.Drawing;
		}

	}
}
