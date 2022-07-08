using Core.Map;

namespace MapConstructor;

public partial class Constructor : Form {
	public delegate void Save(Map map);
	public event Save? MapSave;
	
	private bool LMB_Pressed = false;
	private Point? LastCell;

	private readonly Map Map;
	private readonly DrawMap drawMap;

	public Constructor(Map map) {
		InitializeComponent();
		Map = map;
		drawMap = new(Map, PB_Map);

		TB_MapName.Text = Map.Name;
		TB_NumberOfCells.Text = Map.NumberOfCells.ToString();

		drawMap.Draw();
	}

	private Point GetCellForPoint(Point point) => new((int)(point.X / drawMap.CellSize), (int)(point.Y / drawMap.CellSize));

	private void SelectCell(Point value) {
		if(!Map.OccupiedCells.ContainsKey(value)) {
			Map.OccupiedCells.Add(value, Color.Black);
		} else {
			Map.OccupiedCells.Remove(value);
		}
	}

	private void Constructor_FormClosing(object sender, FormClosingEventArgs e) {
		Map.Name = TB_MapName.Text;
		Map.NumberOfCells = drawMap.NumberOfCells;

		Map.MapImage = drawMap.Draw();

		Map.≈mpty—ells.Clear();
		for(int x = 0; x < drawMap.NumberOfCells; x++)
			for(int y = 0; y < drawMap.NumberOfCells; y++)
				if(!Map.OccupiedCells.ContainsKey(new(x, y)))
					Map.≈mpty—ells.Add(new(x, y));

		MapSave?.Invoke(Map);
	}

	private void TB_NumberOfCells_KeyPress(object sender, KeyPressEventArgs e) {
		char number = e.KeyChar;
		if(!char.IsDigit(number) && number != 8)
			e.Handled = true;
	}

	private void TB_NumberOfCells_TextChanged(object sender, EventArgs e) {
		if(TB_NumberOfCells.Text.Length != 0 && TB_NumberOfCells.Text != "0") {
			drawMap.NumberOfCells = int.Parse(TB_NumberOfCells.Text);
			drawMap.CreateGrid();
			drawMap.Draw();
		}
	}

	private void EraseToolStripMenuItem_Click(object sender, EventArgs e) {
		Map.OccupiedCells.Clear();
		drawMap.Draw();
	}

	private void PB_Map_MouseUP(object sender, MouseEventArgs e) => LMB_Pressed = false;

	private void PB_Map_MouseDown(object sender, MouseEventArgs e) {
		if(e.Button == MouseButtons.Left) {
			LMB_Pressed = true;

			PB_Map_MouseMove(sender, e);
		}
	}

	private void PB_Map_MouseMove(object sender, MouseEventArgs e) {
		Point Cell = GetCellForPoint(e.Location);

		if(LMB_Pressed && LastCell != Cell) {
			SelectCell(Cell);
			drawMap.Draw();

			LastCell = Cell;
		}
	}
}
