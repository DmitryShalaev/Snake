namespace Core;

[Serializable]
public class Map {
	public string Name { get; set; }
	public System.Drawing.Bitmap MapImage { get; set; }

	public int NumberOfCells { get; set; }
	public HashSet<(int X, int Y)> ЕmptyСells { get; set; }
	public Dictionary<(int X, int Y), Сell> Сells { get; set; }

	public Map() {
		Name = "";
		MapImage = new(1, 1);

		NumberOfCells = 10;
		ЕmptyСells = new();
		Сells = new();
	}
}
