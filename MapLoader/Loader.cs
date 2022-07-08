using System.Runtime.Serialization.Formatters.Binary;
using Core.Map;
using MapConstructor;
using Game;

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
		newMapItem.MapChange += MapItem_MapChange;
		FLP_Maps.Controls.Add(newMapItem);

		foreach(var item in maps) {
			MapItem MapItem = new(item.MapImage, item.Name);
			MapItem.MapSelected += MapItem_MapSelected;
			MapItem.MapChange += MapItem_MapChange;
			MapItem.MapDelete += MapItem_MapDelete;
			FLP_Maps.Controls.Add(MapItem);
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
		} catch(Exception) {
			return new();
		}
	}

	private void Loader_Load(object sender, EventArgs e) => VisualizeMapsList();

	private void MapItem_MapChange(int? MapID) {
		if(MapID == null) {
			Constructor constructor = new(new());
			constructor.MapSave += (map) => {
				maps.Add(map);
				VisualizeMapsList();
			};
			Hide();
			constructor.ShowDialog();
			Show();
		} else {
			Constructor constructor = new(maps[(int)MapID]);
			constructor.MapSave += (map) => {
				VisualizeMapsList();
			};
			Hide();
			constructor.ShowDialog();
			Show();
		}
	}

	private void MapItem_MapSelected(int? MapID) {
		if(MapID != null) {
			GameForm game = new(maps[MapID.Value]);
					
			Hide();
			game.ShowDialog();
			Show();
		}
	}

	private void MapItem_MapDelete(int? mapID) {
		if(mapID != null) {
			maps.RemoveAt((int)mapID);
			VisualizeMapsList();
		}
	}

	private void Loader_FormClosing(object sender, FormClosingEventArgs e) => Serialize();
}

