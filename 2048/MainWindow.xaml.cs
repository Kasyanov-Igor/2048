using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
			game.RenderGameField();
            game.RenderGameField();
            game.RenderGameField();
            game.RenderGameField();



        }
	}
}
