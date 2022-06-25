namespace Core;

[Serializable]
public class Map {
	public string Name { get; set; }
	public System.Drawing.Bitmap MapImage { get; set; }

	public int NumberOfCells { get; set; }
	public HashSet<(int X, int Y)> ЕmptyСells { get; set; }
	public Dictionary<(int X, int Y), System.Drawing.Color> OccupiedCells { get; set; }

	public Map() {
		Name = "Some text";
		MapImage = Resources.Resource.error;

		NumberOfCells = 10;
		ЕmptyСells = new();
		OccupiedCells = new();
	}
}
