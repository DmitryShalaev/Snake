using System.Runtime.Serialization.Formatters.Binary;
using Core;

namespace MapLoader;

public partial class Loader : Form {
	private readonly string Personal = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

	private readonly List<Map> maps;

	public Loader() {
		InitializeComponent();

		maps = Deserialize();
	}

	private void VisualizeMapsList() {
		FLP_Maps.Controls.Clear();

		MapItem.ResetMapItemCount();

		NewMapItem newMapItem = new();
		newMapItem.MapSelected += MapItem_MapSelected;
		FLP_Maps.Controls.Add(newMapItem);

		foreach(var item in maps) {
			MapItem MapItem = new(item.MapImage, item.Name);
			MapItem.MapSelected += MapItem_MapSelected;
			MapItem.MapDelete += MapItem_MapDelete;
			FLP_Maps.Controls.Add(MapItem);
		}
	}

	private void MapItem_MapDelete(int? mapID) {
		if(mapID != null) {
			maps.RemoveAt((int)mapID);
			VisualizeMapsList();
		}
	}

	private void Serialize() {
		using(FileStream fs = new(Personal + "\\Maps.dat", FileMode.OpenOrCreate)) {
			BinaryFormatter formatter = new();

			formatter.Serialize(fs, maps);
		}
	}

	private List<Map> Deserialize() {
		try {
			using(FileStream fs = new(Personal + "\\Maps.dat", FileMode.Open)) {
				BinaryFormatter formatter = new();
				return (List<Map>)formatter.Deserialize(fs);
			}
		} catch(FileNotFoundException) {
			return new();
		}
	}

	private void Loader_Load(object sender, EventArgs e) => VisualizeMapsList();

	private void MapItem_MapSelected(int? MapID) {
		if(MapID == null) {
			maps.Add(new(($"Map ¹{FLP_Maps.Controls.Count}"), Properties.Resources.error, 10, null, null));
			VisualizeMapsList();
		} else {
			MessageBox.Show(MapID.ToString());
		}
	}

	private void Loader_FormClosing(object sender, FormClosingEventArgs e) => Serialize();
}

