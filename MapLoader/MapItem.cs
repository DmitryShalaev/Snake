namespace MapLoader;
public partial class MapItem : UserControl {
	private static int MapItemCount;
	public readonly int MapID;

	public delegate void Selected(int? mapID);
	public event Selected? MapSelected;
	public event Selected? MapDelete;

	public MapItem(Bitmap mapImage, string mapName) {
		InitializeComponent();
		MapID = MapItemCount++;

		PB_MapImage.Image = mapImage;
		L_MapName.Text = mapName;
	}

	public static void ResetMapItemCount() => MapItemCount = 0;

	private void NewMapItem_Click(object sender, EventArgs e) => MapSelected?.Invoke(MapID);

	private void DeleteToolStripMenuItem_Click(object sender, EventArgs e) {
		MapDelete?.Invoke(MapID);
	}
}
