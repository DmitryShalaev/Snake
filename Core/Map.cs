using System.Drawing;

namespace Core;
[Serializable]
public class Map {
	public string Name { get; private set; }
	public Bitmap MapImage { get; private set; }

	public int NumberOfCells { get; private set; }
	public HashSet<(int X, int Y)> ЕmptyСells { get; private set; }
	public Dictionary<(int X, int Y), Сell> Сells { get; private set; }

	public Map(string name, Bitmap mapImage, int numberOfCells, HashSet<(int X, int Y)> еmptyСells, Dictionary<(int X, int Y), Сell> сells) {
		Name = name;
		MapImage = mapImage;
		NumberOfCells = numberOfCells;
		ЕmptyСells = еmptyСells;
		Сells = сells;
	}
}
