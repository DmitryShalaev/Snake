using Core;

namespace MapConstructor;

public partial class Constructor : Form {
	public delegate void Save(Map map);
	public event Save? MapSave;

	public Map Map { get; }

	public Constructor(Map map) {
		InitializeComponent();
		Map = map;

		TB_MapName.Text = Map.Name;
		TB_NumberOfCells.Text = Map.NumberOfCells.ToString();
	}

	private void Constructor_FormClosing(object sender, FormClosingEventArgs e) {
		Map.Name = TB_MapName.Text;
		Map.NumberOfCells = int.Parse(TB_NumberOfCells.Text);

		MapSave?.Invoke(Map);
	}

	private void TB_NumberOfCells_KeyPress(object sender, KeyPressEventArgs e) {
		char number = e.KeyChar;
		if(!char.IsDigit(number) && number != 8) e.Handled = true;
	}
}
