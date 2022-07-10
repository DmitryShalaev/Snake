namespace Game {
	partial class GameForm {
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
			this.PB_Map = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.PB_Map)).BeginInit();
			this.SuspendLayout();
			// 
			// PB_Map
			// 
			this.PB_Map.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PB_Map.Location = new System.Drawing.Point(5, 5);
			this.PB_Map.Margin = new System.Windows.Forms.Padding(0);
			this.PB_Map.Name = "PB_Map";
			this.PB_Map.Size = new System.Drawing.Size(800, 800);
			this.PB_Map.TabIndex = 0;
			this.PB_Map.TabStop = false;
			// 
			// GameForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(810, 810);
			this.Controls.Add(this.PB_Map);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "GameForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.PB_Map)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private PictureBox PB_Map;
	}
}