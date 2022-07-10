using Core.Map;
using Core.Snake;

namespace Game {
	public partial class GameForm : Form {
		private readonly Map Map;

		private readonly Bitmap bmp;
		private readonly Graphics gfx;

		private readonly Snake Snake;

		private bool flag;

		public GameForm(Map map) {
			InitializeComponent();
			Map = map;
			Snake = (Snake)map.Snake.Clone();

			Random random = new();
			Snake.GetRandom += random.Next;
			Snake.End += EndGame;
			Snake.SpawnEat();

			bmp = new(Map.MapImage);
			gfx = Graphics.FromImage(bmp);
			gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			PB_Map.BackgroundImage = Map.MapImage;

			flag = true;
			GameLoop();
		}

		private async void GameLoop() {
			while(flag) {
				Snake.Move();

				gfx.Clear(Color.Empty);

				for(int i = 0; i < Snake.Body.Count; i++) {
					gfx.FillRectangle(new SolidBrush(i == Snake.Body.Count - 1 ? Color.Blue : Color.Red), (float)(Snake.Body[i].X * Map.CellSize) - 1, (float)(Snake.Body[i].Y * Map.CellSize) - 1, (float)Map.CellSize, (float)Map.CellSize);
				}

				gfx.FillRectangle(new SolidBrush(Color.Green), (float)(Snake.FoodPoint.X * Map.CellSize) - 1, (float)(Snake.FoodPoint.Y * Map.CellSize) - 1, (float)Map.CellSize, (float)Map.CellSize);

				PB_Map.Image = bmp;
				Text = $"Score: {Snake.Body.Count}";

				await Task.Delay(100);
			}
		}

		private void EndGame(string str) {
			flag = false;

			MessageBox.Show(str);

			Close();
		}

		private void GameForm_KeyUp(object sender, KeyEventArgs e) => Snake.Rotation(e.KeyData);

		private void GameForm_FormClosing(object sender, FormClosingEventArgs e) => flag = false;
	}
}