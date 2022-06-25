namespace MapConstructor;

partial class Constructor {
	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	///  Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing) {
		if(disposing && (components != null)) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	///  Required method for Designer support - do not modify
	///  the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
			this.panel1 = new System.Windows.Forms.Panel();
			this.PB_Map = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.TB_MapName = new System.Windows.Forms.TextBox();
			this.TB_NumberOfCells = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PB_Map)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.PB_Map);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(356, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(768, 768);
			this.panel1.TabIndex = 0;
			// 
			// PB_Map
			// 
			this.PB_Map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PB_Map.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PB_Map.Location = new System.Drawing.Point(5, 5);
			this.PB_Map.Margin = new System.Windows.Forms.Padding(0);
			this.PB_Map.Name = "PB_Map";
			this.PB_Map.Size = new System.Drawing.Size(758, 758);
			this.PB_Map.TabIndex = 0;
			this.PB_Map.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Margin = new System.Windows.Forms.Padding(0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Map Name:";
			// 
			// TB_MapName
			// 
			this.TB_MapName.Location = new System.Drawing.Point(133, 5);
			this.TB_MapName.Name = "TB_MapName";
			this.TB_MapName.Size = new System.Drawing.Size(155, 27);
			this.TB_MapName.TabIndex = 2;
			// 
			// TB_NumberOfCells
			// 
			this.TB_NumberOfCells.Location = new System.Drawing.Point(133, 39);
			this.TB_NumberOfCells.Name = "TB_NumberOfCells";
			this.TB_NumberOfCells.Size = new System.Drawing.Size(155, 27);
			this.TB_NumberOfCells.TabIndex = 4;
			this.TB_NumberOfCells.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_NumberOfCells_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 42);
			this.label2.Margin = new System.Windows.Forms.Padding(0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(121, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "Number Of Cells:";
			// 
			// Constructor
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1124, 768);
			this.Controls.Add(this.TB_NumberOfCells);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.TB_MapName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Constructor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Map Constructor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Constructor_FormClosing);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PB_Map)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion

	private Panel panel1;
	private PictureBox PB_Map;
	private Label label1;
	private TextBox TB_MapName;
	private TextBox TB_NumberOfCells;
	private Label label2;
}
