namespace MapLoader;

partial class Loader {
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
			this.FLP_Maps = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// FLP_Maps
			// 
			this.FLP_Maps.AutoScroll = true;
			this.FLP_Maps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FLP_Maps.Location = new System.Drawing.Point(0, 0);
			this.FLP_Maps.Margin = new System.Windows.Forms.Padding(0);
			this.FLP_Maps.Name = "FLP_Maps";
			this.FLP_Maps.Size = new System.Drawing.Size(1296, 733);
			this.FLP_Maps.TabIndex = 0;
			// 
			// Loader
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1296, 733);
			this.Controls.Add(this.FLP_Maps);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Loader";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Map Loader";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Loader_FormClosing);
			this.Load += new System.EventHandler(this.Loader_Load);
			this.ResumeLayout(false);

	}

	#endregion

	private FlowLayoutPanel FLP_Maps;
}
