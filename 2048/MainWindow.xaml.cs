using System.Windows;

namespace _2048
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			GridGameField game = new GridGameField(this);

		}
	}
}
