using Core.Map;
using Core.Snake;

namespace MapConstructor;

public partial class Constructor : Form {
	public delegate void Save(Map map);
	public event Save? MapSave;

	private bool LMB_Pressed = false;
	private (int X, int Y)? LastCell;

	private readonly Map Map;
	private readonly Bitmap bmpBack;
	private readonly Bitmap bmpFront;

	public Pen CellPen = new(Color.Black);

	public Constructor(Map map) {
		InitializeComponent();
		Map = map;

		bmpBack = new(PB_Map.Width, PB_Map.Height);
		bmpFront = new(PB_Map.Width, PB_Map.Height);

		TB_MapName.Text = Map.Name;
		TB_NumberOfCells.Text = Map.NumberOfCells.ToString();

		DrawMap();
	}

	private (int X, int Y) GetCellForPoint(Point point) => ((int)(point.X / Map.CellSize), (int)(point.Y / Map.CellSize));

	private void SelectCell((int X, int Y) value) {
		if(!Map.Snake.Body.Contains(value)) {
			if(!Map.OccupiedCells.ContainsKey(value)) {
				Map.OccupiedCells.Add(value, Color.Black);
			} else {
				Map.OccupiedCells.Remove(value);
			}
		}
	}

	private void SelectSnake((int X, int Y) value) {
		if(!Map.OccupiedCells.ContainsKey(value)) {
			if(!Map.Snake.Body.Contains(value)) {
				if(Map.Snake.Body.Count > 0) {
					if(Math.Abs(value.X - Map.Snake.Body[^1].X) + Math.Abs(value.Y - Map.Snake.Body[^1].Y) == 1)
						Map.Snake.Body.Add(value);
				} else {
					Map.Snake.Body.Add(value);
				}
			} else {
				int index = Map.Snake.Body.IndexOf(value);
				Map.Snake.Body.RemoveRange(index, Map.Snake.Body.Count - index);
			}
		}
	}

	public Bitmap CreateGrid() {
		Graphics gfx = Graphics.FromImage(bmpBack);
		gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
		gfx.Clear(Color.Empty);

		for(int i = 1; i < Map.NumberOfCells; i++) {
			gfx.DrawLine(CellPen, (float)(i * Map.CellSize) - CellPen.Width, 0, (float)(i * Map.CellSize) - CellPen.Width, PB_Map.Height);
			gfx.DrawLine(CellPen, 0, (float)(i * Map.CellSize) - CellPen.Width, PB_Map.Width, (float)(i * Map.CellSize) - CellPen.Width);
		}
		PB_Map.BackgroundImage = bmpBack;
		return bmpBack;
	}
	public Bitmap DrawMap(bool drawSnake = true) {
		Graphics gfx = Graphics.FromImage(bmpFront);
		gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
		gfx.Clear(Color.Empty);

		foreach(var item in Map.OccupiedCells)
			gfx.FillRectangle(new SolidBrush(item.Value), (float)(item.Key.X * Map.CellSize) - CellPen.Width, (float)(item.Key.Y * Map.CellSize) - CellPen.Width, (float)Map.CellSize, (float)Map.CellSize);

		if(drawSnake)
			for(int i = 0; i < Map.Snake.Body.Count; i++) {
				gfx.FillRectangle(new SolidBrush(i == Map.Snake.Body.Count - 1 ? Color.Blue : Color.Red), (float)(Map.Snake.Body[i].X * Map.CellSize) - 1, (float)(Map.Snake.Body[i].Y * Map.CellSize) - 1, (float)Map.CellSize, (float)Map.CellSize);
			}

		PB_Map.Image = bmpFront;
		return bmpFront;
	}
	private void Constructor_FormClosing(object sender, FormClosingEventArgs e) {
		Map.Name = TB_MapName.Text;

		Bitmap bmp = new(PB_Map.Width, PB_Map.Height);
		Graphics gfx = Graphics.FromImage(bmp);
		gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
		gfx.DrawImage(CreateGrid(), 0, 0);
		gfx.DrawImage(DrawMap(false), 0, 0);

		Map.MapImage = bmp;
		Map.ÅmptyÑells.Clear();
		for(int x = 0; x < Map.NumberOfCells; x++)
			for(int y = 0; y < Map.NumberOfCells; y++)
				if(!Map.OccupiedCells.ContainsKey((x, y)))
					Map.ÅmptyÑells.Add((x, y));

		foreach(var item in Map.Snake.Body)
			Map.ÅmptyÑells.Remove(item);

		if(Map.Snake.Body.Count > 1) {
			if(Map.Snake.Body[^1].X > Map.Snake.Body[^2].X)
				Map.Snake.Direction = Direction.RIGHT;
			else if(Map.Snake.Body[^1].X < Map.Snake.Body[^2].X)
				Map.Snake.Direction = Direction.LEFT;
			else if(Map.Snake.Body[^1].Y > Map.Snake.Body[^2].Y)
				Map.Snake.Direction = Direction.DOWN;
			else
				Map.Snake.Direction = Direction.UP;
		}

		MapSave?.Invoke(Map);
	}

	private void TB_NumberOfCells_KeyPress(object sender, KeyPressEventArgs e) {
		char number = e.KeyChar;
		if(!char.IsDigit(number) && number != 8)
			e.Handled = true;
	}

	private void TB_NumberOfCells_TextChanged(object sender, EventArgs e) {
		if(TB_NumberOfCells.Text.Length != 0 && TB_NumberOfCells.Text != "0") {
			Map.NumberOfCells = int.Parse(TB_NumberOfCells.Text);
			Map.CellSize = PB_Map.Width / (decimal)Map.NumberOfCells;
			CreateGrid();
			DrawMap();
		}
	}

	private void EraseToolStripMenuItem_Click(object sender, EventArgs e) {
		Map.OccupiedCells.Clear();
		Map.Snake.Body.Clear();
		DrawMap();
	}

	private void PB_Map_MouseUP(object sender, MouseEventArgs e) {
		LMB_Pressed = false;
		LastCell = null;
	}

	private void PB_Map_MouseDown(object sender, MouseEventArgs e) {
		if(e.Button == MouseButtons.Left) {
			LMB_Pressed = true;

			PB_Map_MouseMove(sender, e);
		}
	}

	private void PB_Map_MouseMove(object sender, MouseEventArgs e) {
		(int X, int Y) Cell = GetCellForPoint(e.Location);

		if(LMB_Pressed && LastCell != Cell) {
			if(!CB_Snake.Checked)
				SelectCell(Cell);
			else
				SelectSnake(Cell);

			DrawMap();

			LastCell = Cell;
		}
	}
}
