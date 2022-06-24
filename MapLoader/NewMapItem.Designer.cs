namespace MapLoader;

partial class NewMapItem {
	/// <summary> 
	/// Обязательная переменная конструктора.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary> 
	/// Освободить все используемые ресурсы.
	/// </summary>
	/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
	protected override void Dispose(bool disposing) {
		if(disposing && (components != null)) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Код, автоматически созданный конструктором компонентов

	/// <summary> 
	/// Требуемый метод для поддержки конструктора — не изменяйте 
	/// содержимое этого метода с помощью редактора кода.
	/// </summary>
	private void InitializeComponent() {
			this.panel1 = new System.Windows.Forms.Panel();
			this.PB_MapImage = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PB_MapImage)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.PB_MapImage);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(5, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(240, 350);
			this.panel1.TabIndex = 0;
			this.panel1.Click += new System.EventHandler(this.NewMapItem_Click);
			// 
			// PB_MapImage
			// 
			this.PB_MapImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PB_MapImage.Image = global::MapLoader.Properties.Resources.NewIcon;
			this.PB_MapImage.Location = new System.Drawing.Point(0, 0);
			this.PB_MapImage.Name = "PB_MapImage";
			this.PB_MapImage.Size = new System.Drawing.Size(240, 350);
			this.PB_MapImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PB_MapImage.TabIndex = 1;
			this.PB_MapImage.TabStop = false;
			this.PB_MapImage.Click += new System.EventHandler(this.NewMapItem_Click);
			// 
			// NewMapItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(5, 5, 0, 0);
			this.Name = "NewMapItem";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Size = new System.Drawing.Size(250, 360);
			this.Click += new System.EventHandler(this.NewMapItem_Click);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PB_MapImage)).EndInit();
			this.ResumeLayout(false);

	}

	#endregion

	private Panel panel1;
	private PictureBox PB_MapImage;
}
