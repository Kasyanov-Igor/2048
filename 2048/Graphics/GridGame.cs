using System.Windows.Controls;
using System.Windows.Input;

namespace _2048
{
	public class GridGame : Grid
	{
		public delegate void RenderScore();

		public event RenderScore OnRenderScore;

		public LogicGameField _gameField;

		public GridGame()
		{
			_gameField = new LogicGameField();
		}

		public virtual void Render() { }

		public virtual void Drawing() { }

		public virtual void TextBox_Key(object sender, KeyEventArgs e)
		{
			switch (e.Key)
			{
				case Key.Left:

					if (this._gameField.PushLeft())
					{
						this._gameField.AddField();
					}
					break;

				case Key.Right:

					if (this._gameField.PushRight())
					{
						this._gameField.AddField();
					}
					break;

				case Key.Up:

					if (this._gameField.PushUp())
					{
						this._gameField.AddField();
					}
					break;

				case Key.Down:

					if (this._gameField.PushDown())
					{
						this._gameField.AddField();
					}
					break;
			}
			this.Drawing();
			this.OnRenderScore?.Invoke();
		}
	}
}
