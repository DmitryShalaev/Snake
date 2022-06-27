using Core;

namespace MapConstructor;

public partial class Constructor : Form {
	public delegate void Save(Map map);
	public event Save? MapSave;

	private int NumberOfCells => int.Parse(TB_NumberOfCells.Text);
	private decimal CellSize => PB_Map.Width / (decimal)NumberOfCells;
	private readonly Pen CellPen = new(Color.Black);

	private Bitmap? Grid;

	private Map Map { get; }

	public Constructor(Map map) {
		InitializeComponent();
		Map = map;

		TB_MapName.Text = Map.Name;
		TB_NumberOfCells.Text = Map.NumberOfCells.ToString();

		DrawMap();
	}

	private Bitmap CreateGrid() {
		Bitmap bmp = new(PB_Map.Width, PB_Map.Height);
		Graphics gfx = Graphics.FromImage(bmp);
		gfx.Clear(Color.White);
		gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

		for(int i = 1; i < NumberOfCells; i++) {
			gfx.DrawLine(CellPen, (float)(i * CellSize) - CellPen.Width, 0, (float)(i * CellSize) - CellPen.Width, PB_Map.Height);
			gfx.DrawLine(CellPen, 0, (float)(i * CellSize) - CellPen.Width, PB_Map.Width, (float)(i * CellSize) - CellPen.Width);
		}

		return Grid = bmp;
	}

	private Bitmap DrawMap() {
		Bitmap bmp = new(Grid ?? CreateGrid());
		Graphics gfx = Graphics.FromImage(bmp);
		gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

		foreach(var item in Map.OccupiedCells)
			gfx.FillRectangle(new SolidBrush(item.Value), (float)(item.Key.X * CellSize) - CellPen.Width, (float)(item.Key.Y * CellSize) - CellPen.Width, (float)CellSize, (float)CellSize);

		PB_Map.Image = bmp;
		return bmp;
	}

	private (int X, int Y) GetCellForPoint(Point point) => ((int)(point.X / CellSize), (int)(point.Y / CellSize));

	private void SelectCell((int X, int Y) value) {
		if(!Map.OccupiedCells.ContainsKey(value)) {
			Map.OccupiedCells.Add(value, Color.Black);
		} else {
			Map.OccupiedCells.Remove(value);
		}
	}

	private void Constructor_FormClosing(object sender, FormClosingEventArgs e) {
		Map.Name = TB_MapName.Text;
		Map.NumberOfCells = int.Parse(TB_NumberOfCells.Text.Length != 0 ? TB_NumberOfCells.Text : "1");

		Map.MapImage = DrawMap();

		Map.≈mpty—ells.Clear();
		for(int x = 0; x < NumberOfCells; x++)
			for(int y = 0; y < NumberOfCells; y++)
				if(!Map.OccupiedCells.ContainsKey((x, y)))
					Map.≈mpty—ells.Add((x, y));

		MapSave?.Invoke(Map);
	}

	private void TB_NumberOfCells_KeyPress(object sender, KeyPressEventArgs e) {
		char number = e.KeyChar;
		if(!char.IsDigit(number) && number != 8)
			e.Handled = true;
	}

	private void TB_NumberOfCells_TextChanged(object sender, EventArgs e) {
		if(TB_NumberOfCells.Text.Length != 0 && TB_NumberOfCells.Text != "0") {
			CreateGrid();
			DrawMap();
		}
	}

	private void PB_Map_MouseUP(object sender, MouseEventArgs e) {
		if(e.Button == MouseButtons.Left) {
			SelectCell(GetCellForPoint(e.Location));
			DrawMap();
		}
	}

	private void EraseToolStripMenuItem_Click(object sender, EventArgs e) {
		Map.OccupiedCells.Clear();
		DrawMap();
	}
}
