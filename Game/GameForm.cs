using Core.Map;
using Core.Snake;

namespace Game {
	public partial class GameForm : Form {
		private readonly Map Map;

		private readonly Bitmap bmp;
		private readonly Graphics gfx;

		private readonly Snake Snake;
		private readonly FoodFactory foodFactory;

		public GameForm(Map map) {
			InitializeComponent();
			Map = map;
			Snake = (Snake)map.Snake.Clone();
			foodFactory = new(Map);
			Snake.CreateFood = foodFactory.CreateFood;
			Snake.FoodPoint = Snake.CreateFood();

			bmp = new(Map.MapImage);
			gfx = Graphics.FromImage(bmp);
			gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			PB_Map.BackgroundImage = Map.MapImage;

			GameLoop();
		}

		private async void GameLoop() {
			while(true) {
				Snake.Move();

				gfx.Clear(Color.Empty);

				foreach(var (X, Y) in Snake.Body)
					gfx.FillRectangle(new SolidBrush(Color.Red), (float)(X * Map.CellSize) - 1, (float)(Y * Map.CellSize) - 1, (float)Map.CellSize, (float)Map.CellSize);

				gfx.FillRectangle(new SolidBrush(Color.Green), (float)(Snake.FoodPoint.X * Map.CellSize) - 1, (float)(Snake.FoodPoint.Y * Map.CellSize) - 1, (float)Map.CellSize, (float)Map.CellSize);

				PB_Map.Image = bmp;

				await Task.Delay(100);
			}
		}

		private void GameForm_KeyUp(object sender, KeyEventArgs e) => Snake.Rotation(e.KeyData);
	}
}