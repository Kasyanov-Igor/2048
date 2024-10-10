using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace _2048
{
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();

			GridGameField game = new GridGameField(this);
			GameScore score = new GameScore(this);


			this.KeyUp += game.TextBox_Key;
		}

	}
}
