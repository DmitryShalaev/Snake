namespace Core.Map;

[Serializable]
public class Map {
	public string Name { get; set; }
	public Bitmap MapImage { get; set; }

	public int NumberOfCells { get; set; }
	public decimal CellSize { get; set; }
	public HashSet<(int X, int Y)> ЕmptyСells { get; set; }
	public Dictionary<(int X, int Y), Color> OccupiedCells { get; set; }

	public Snake.Snake Snake { get; set; }

	public Map() {
		Name = "Some text";
		MapImage = Resources.Resource.error;

		NumberOfCells = 10;
		CellSize = 80;
		ЕmptyСells = new();
		OccupiedCells = new();

		Snake = new(this);
	}
}