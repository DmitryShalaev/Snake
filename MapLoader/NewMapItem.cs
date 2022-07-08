namespace MapLoader;
public partial class NewMapItem : UserControl {
	public delegate void Selected(int? mapID);
	public event Selected? MapChange;

	public NewMapItem() => InitializeComponent();

	private void NewMapItem_Click(object sender, EventArgs e) => MapChange?.Invoke(null);
}
