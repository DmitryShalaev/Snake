namespace Core;

[Serializable]
public class Map {
	public string Name { get; set; }
	public object MapImage { get; set; }

	public int NumberOfCells { get; set; }
	public HashSet<(int X, int Y)> ЕmptyСells { get; set; }
	public Dictionary<(int X, int Y), Сell> Сells { get; set; }

	public Map() {
		Name = "";
		MapImage = new();

		NumberOfCells = 10;
		ЕmptyСells = new();
		Сells = new();
	}
}
