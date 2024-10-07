using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _2048
{
    public class GridGameField : Grid
    {
        private LogicGameField _gameField;

        private const byte _cellSize = 50;

        public GridGameField(Window parentElement)
        {
            this._gameField = new LogicGameField();

           parentElement.Content = this;

            for (byte i = 0; i < LogicGameField.COUNT_ROWS; i++)
            {
                RowDefinitions.Add(new RowDefinition());
                ColumnDefinitions.Add(new ColumnDefinition());
            }

            this.Margin = new Thickness(10, 100, 10, 10);

            this.ShowGridLines = true;
        }

        public void RenderGameField()
        {
            this._gameField.AddField();
            byte[,] logicalGameField = this._gameField.GetField();

            for (int i = 0; i < LogicGameField.COUNT_ROWS; i++)
            {
                for (int k = 0; k < LogicGameField.COUNT_COLLUMNS; ++k)
                {
                    if (logicalGameField[i, k] == 1)
                    {
                      
                        TextBox textBox = new TextBox {};
                        textBox.Text = "2";

                       textBox.FontSize = _cellSize;
                        textBox.HorizontalAlignment = HorizontalAlignment.Center;
                        textBox.VerticalAlignment = VerticalAlignment.Center;

                        Grid.SetRow(textBox, i);
                        Grid.SetColumn(textBox, k);
                        this.Children.Add(textBox);
                    }
                    //if(logicalGameField[i, k] == 4)
                    //{


                    //    this.Children.Add(gameFigure);//< Белые
                    //    Grid.SetRow(gameFigure, i);
                    //    Grid.SetColumn(gameFigure, k);
                    //}
                }

            }
        }

            public bool GameOver()
        {
            if(this._gameField.CheckEmptySells() == false)
            {
                return true;
            }
            return false;
        }
    }
}
