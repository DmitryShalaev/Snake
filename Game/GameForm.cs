using Core.Map;

namespace Game {
	public partial class GameForm : Form {
		private readonly Map Map;
		private readonly DrawMap drawMap;
		private readonly Bitmap Bitmap;

		public GameForm(Map map) {
			InitializeComponent();
			Map = map;
			drawMap = new(Map, PB_Map);

			Bitmap = drawMap.Draw();
		}
	}
}