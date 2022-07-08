namespace Core.Map;

[Serializable]
public class Map {
	public string Name { get; set; }
	public Bitmap MapImage { get; set; }

	public int NumberOfCells { get; set; }
	public HashSet<Point> ЕmptyСells { get; set; }
	public Dictionary<Point, Color> OccupiedCells { get; set; }

	public Snake.Snake Snake { get; set; }

	public Map() {
		Name = "Some text";
		MapImage = Resources.Resource.error;

		NumberOfCells = 10;
		ЕmptyСells = new();
		OccupiedCells = new();

		Snake = new();
	}
}

public class DrawMap {
	private Bitmap? Grid;

	private Map Map { get; }

	public PictureBox Picture { get; }
	public Pen CellPen { get; set; }
	public int NumberOfCells { get; set; }
	public decimal CellSize => Picture.Width / (decimal)NumberOfCells;

	public DrawMap(Map map, PictureBox picture) {
		Map = map;
		Picture = picture;

		NumberOfCells = map.NumberOfCells;

		CellPen = new(Color.Black);
	}

	public Bitmap CreateGrid() {
		Bitmap bmp = new(Picture.Width, Picture.Height);
		Graphics gfx = Graphics.FromImage(bmp);
		gfx.Clear(Color.White);
		gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

		for(int i = 1; i < NumberOfCells; i++) {
			gfx.DrawLine(CellPen, (float)(i * CellSize) - CellPen.Width, 0, (float)(i * CellSize) - CellPen.Width, Picture.Height);
			gfx.DrawLine(CellPen, 0, (float)(i * CellSize) - CellPen.Width, Picture.Width, (float)(i * CellSize) - CellPen.Width);
		}
		return Grid = bmp;
	}

	public Bitmap Draw() {
		Bitmap bmp = new(Grid ?? CreateGrid());
		Graphics gfx = Graphics.FromImage(bmp);
		gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

		foreach(var item in Map.OccupiedCells)
			gfx.FillRectangle(new SolidBrush(item.Value), (float)(item.Key.X * CellSize) - CellPen.Width, (float)(item.Key.Y * CellSize) - CellPen.Width, (float)CellSize, (float)CellSize);
		Picture.Image = bmp;
		return bmp;
	}
}
