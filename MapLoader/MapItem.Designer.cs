﻿namespace MapLoader;

partial class MapItem {
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
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.CMS_MapItem = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.PB_MapImage = new System.Windows.Forms.PictureBox();
			this.L_MapName = new System.Windows.Forms.Label();
			this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.CMS_MapItem.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PB_MapImage)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.ContextMenuStrip = this.CMS_MapItem;
			this.panel1.Controls.Add(this.PB_MapImage);
			this.panel1.Controls.Add(this.L_MapName);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(4, 4);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(211, 262);
			this.panel1.TabIndex = 0;
			this.panel1.Click += new System.EventHandler(this.MapItem_Click);
			// 
			// CMS_MapItem
			// 
			this.CMS_MapItem.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.CMS_MapItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.changeToolStripMenuItem});
			this.CMS_MapItem.Name = "CMS_MapItem";
			this.CMS_MapItem.Size = new System.Drawing.Size(181, 70);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
			// 
			// PB_MapImage
			// 
			this.PB_MapImage.ContextMenuStrip = this.CMS_MapItem;
			this.PB_MapImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PB_MapImage.Location = new System.Drawing.Point(0, 0);
			this.PB_MapImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PB_MapImage.Name = "PB_MapImage";
			this.PB_MapImage.Size = new System.Drawing.Size(211, 241);
			this.PB_MapImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PB_MapImage.TabIndex = 1;
			this.PB_MapImage.TabStop = false;
			this.PB_MapImage.Click += new System.EventHandler(this.MapItem_Click);
			// 
			// L_MapName
			// 
			this.L_MapName.ContextMenuStrip = this.CMS_MapItem;
			this.L_MapName.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.L_MapName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.L_MapName.Location = new System.Drawing.Point(0, 241);
			this.L_MapName.Name = "L_MapName";
			this.L_MapName.Size = new System.Drawing.Size(211, 21);
			this.L_MapName.TabIndex = 0;
			this.L_MapName.Text = "Map Name";
			this.L_MapName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.L_MapName.Click += new System.EventHandler(this.MapItem_Click);
			// 
			// changeToolStripMenuItem
			// 
			this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
			this.changeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.changeToolStripMenuItem.Text = "Change";
			this.changeToolStripMenuItem.Click += new System.EventHandler(this.ChangeToolStripMenuItem_Click);
			// 
			// MapItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ContextMenuStrip = this.CMS_MapItem;
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 0, 0);
			this.Name = "MapItem";
			this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Size = new System.Drawing.Size(219, 270);
			this.Click += new System.EventHandler(this.MapItem_Click);
			this.panel1.ResumeLayout(false);
			this.CMS_MapItem.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PB_MapImage)).EndInit();
			this.ResumeLayout(false);

	}

	#endregion

	private Panel panel1;
	private Label L_MapName;
	private PictureBox PB_MapImage;
	private ContextMenuStrip CMS_MapItem;
	private ToolStripMenuItem deleteToolStripMenuItem;
	private ToolStripMenuItem changeToolStripMenuItem;
}
