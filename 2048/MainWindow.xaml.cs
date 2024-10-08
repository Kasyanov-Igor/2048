using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace _2048
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private TextBox moveGameСount;
		public MainWindow()
		{
			InitializeComponent();

			GridGameField game = new GridGameField(this);

			this.KeyUp += game.TextBox_Key;
		}

	}
}
