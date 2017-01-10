namespace PostReq
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.создатьКопиюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.открытьЗаявкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.напечататьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.загрузитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.addRequestToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.copyRequestToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openRequestToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.printRequestToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.uploadDataToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.postamtComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1111, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.выходToolStripMenuItem});
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.файлToolStripMenuItem.Text = "&Файл";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(105, 6);
			// 
			// выходToolStripMenuItem
			// 
			this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
			this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
			this.выходToolStripMenuItem.Text = "В&ыход";
			this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.Column1,
            this.Column2,
            this.Percent});
			this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
			this.dataGridView1.DataSource = this.bindingSource1;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 49);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(1111, 212);
			this.dataGridView1.TabIndex = 2;
			this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
			this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
			this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьКопиюToolStripMenuItem,
            this.открытьЗаявкуToolStripMenuItem,
            this.напечататьToolStripMenuItem,
            this.загрузитьДанныеToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(193, 92);
			// 
			// создатьКопиюToolStripMenuItem
			// 
			this.создатьКопиюToolStripMenuItem.Name = "создатьКопиюToolStripMenuItem";
			this.создатьКопиюToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.создатьКопиюToolStripMenuItem.Text = "Создать копию";
			this.создатьКопиюToolStripMenuItem.Click += new System.EventHandler(this.создатьКопиюToolStripMenuItem_Click);
			// 
			// открытьЗаявкуToolStripMenuItem
			// 
			this.открытьЗаявкуToolStripMenuItem.Name = "открытьЗаявкуToolStripMenuItem";
			this.открытьЗаявкуToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.открытьЗаявкуToolStripMenuItem.Text = "Открыть";
			this.открытьЗаявкуToolStripMenuItem.Click += new System.EventHandler(this.открытьЗаявкуToolStripMenuItem_Click);
			// 
			// напечататьToolStripMenuItem
			// 
			this.напечататьToolStripMenuItem.Name = "напечататьToolStripMenuItem";
			this.напечататьToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.напечататьToolStripMenuItem.Text = "Напечатать";
			this.напечататьToolStripMenuItem.Click += new System.EventHandler(this.напечататьToolStripMenuItem_Click);
			// 
			// загрузитьДанныеToolStripMenuItem
			// 
			this.загрузитьДанныеToolStripMenuItem.Name = "загрузитьДанныеToolStripMenuItem";
			this.загрузитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.загрузитьДанныеToolStripMenuItem.Text = "Загрузить накладную";
			this.загрузитьДанныеToolStripMenuItem.Click += new System.EventHandler(this.загрузитьДанныеToolStripMenuItem_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRequestToolStripButton,
            this.copyRequestToolStripButton,
            this.openRequestToolStripButton,
            this.printRequestToolStripButton,
            this.uploadDataToolStripButton,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.postamtComboBox});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1111, 25);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// addRequestToolStripButton
			// 
			this.addRequestToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addRequestToolStripButton.Image")));
			this.addRequestToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.addRequestToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.addRequestToolStripButton.Name = "addRequestToolStripButton";
			this.addRequestToolStripButton.Size = new System.Drawing.Size(108, 22);
			this.addRequestToolStripButton.Text = "Создать заявку";
			this.addRequestToolStripButton.Click += new System.EventHandler(this.addRequestToolStripButton_Click);
			// 
			// copyRequestToolStripButton
			// 
			this.copyRequestToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyRequestToolStripButton.Image")));
			this.copyRequestToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.copyRequestToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyRequestToolStripButton.Name = "copyRequestToolStripButton";
			this.copyRequestToolStripButton.Size = new System.Drawing.Size(173, 22);
			this.copyRequestToolStripButton.Text = "Создать заявку из текущей";
			this.copyRequestToolStripButton.Click += new System.EventHandler(this.copyRequestToolStripButton_Click);
			// 
			// openRequestToolStripButton
			// 
			this.openRequestToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openRequestToolStripButton.Image")));
			this.openRequestToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.openRequestToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openRequestToolStripButton.Name = "openRequestToolStripButton";
			this.openRequestToolStripButton.Size = new System.Drawing.Size(112, 22);
			this.openRequestToolStripButton.Text = "Открыть заявку";
			this.openRequestToolStripButton.Click += new System.EventHandler(this.openRequestToolStripButton_Click);
			// 
			// printRequestToolStripButton
			// 
			this.printRequestToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printRequestToolStripButton.Image")));
			this.printRequestToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.printRequestToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printRequestToolStripButton.Name = "printRequestToolStripButton";
			this.printRequestToolStripButton.Size = new System.Drawing.Size(128, 22);
			this.printRequestToolStripButton.Text = "Напечатать заявку";
			this.printRequestToolStripButton.Click += new System.EventHandler(this.printRequestToolStripButton_Click);
			// 
			// uploadDataToolStripButton
			// 
			this.uploadDataToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("uploadDataToolStripButton.Image")));
			this.uploadDataToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.uploadDataToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.uploadDataToolStripButton.Name = "uploadDataToolStripButton";
			this.uploadDataToolStripButton.Size = new System.Drawing.Size(145, 22);
			this.uploadDataToolStripButton.Text = "Загрузить накладную";
			this.uploadDataToolStripButton.Click += new System.EventHandler(this.uploadDataToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(13, 22);
			this.toolStripLabel2.Text = "с";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(21, 22);
			this.toolStripLabel1.Text = "по";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// postamtComboBox
			// 
			this.postamtComboBox.Name = "postamtComboBox";
			this.postamtComboBox.Size = new System.Drawing.Size(121, 25);
			// 
			// fromDateTimePicker
			// 
			this.fromDateTimePicker.Location = new System.Drawing.Point(196, 153);
			this.fromDateTimePicker.Name = "fromDateTimePicker";
			this.fromDateTimePicker.Size = new System.Drawing.Size(150, 21);
			this.fromDateTimePicker.TabIndex = 4;
			this.fromDateTimePicker.ValueChanged += new System.EventHandler(this.fromDateTimePicker_ValueChanged);
			// 
			// toDateTimePicker
			// 
			this.toDateTimePicker.Location = new System.Drawing.Point(196, 113);
			this.toDateTimePicker.Name = "toDateTimePicker";
			this.toDateTimePicker.Size = new System.Drawing.Size(150, 21);
			this.toDateTimePicker.TabIndex = 5;
			this.toDateTimePicker.ValueChanged += new System.EventHandler(this.toDateTimePicker_ValueChanged);
			// 
			// bindingSource1
			// 
			this.bindingSource1.DataSource = typeof(PostReq.Model.Request);
			// 
			// idDataGridViewTextBoxColumn
			// 
			this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
			this.idDataGridViewTextBoxColumn.HeaderText = "Номер заявки";
			this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			this.idDataGridViewTextBoxColumn.ReadOnly = true;
			this.idDataGridViewTextBoxColumn.Width = 214;
			// 
			// dateDataGridViewTextBoxColumn
			// 
			this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
			this.dateDataGridViewTextBoxColumn.HeaderText = "Дата заявки";
			this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
			this.dateDataGridViewTextBoxColumn.ReadOnly = true;
			this.dateDataGridViewTextBoxColumn.Width = 213;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "State.Name";
			this.dataGridViewTextBoxColumn1.HeaderText = "Состояние";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 214;
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "User.Fio";
			this.Column1.HeaderText = "Автор";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 213;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "User.Post.Name";
			this.Column2.HeaderText = "Почтамт";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 214;
			// 
			// Percent
			// 
			this.Percent.DataPropertyName = "Percent";
			dataGridViewCellStyle1.Format = "F2";
			this.Percent.DefaultCellStyle = dataGridViewCellStyle1;
			this.Percent.HeaderText = "Процент";
			this.Percent.Name = "Percent";
			this.Percent.ReadOnly = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1111, 261);
			this.Controls.Add(this.toDateTimePicker);
			this.Controls.Add(this.fromDateTimePicker);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Заявки на поставку товаров";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton addRequestToolStripButton;
		private System.Windows.Forms.ToolStripButton copyRequestToolStripButton;
		private System.Windows.Forms.ToolStripButton openRequestToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripComboBox postamtComboBox;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.BindingSource bindingSource1;
		private System.Windows.Forms.DateTimePicker fromDateTimePicker;
		private System.Windows.Forms.DateTimePicker toDateTimePicker;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem открытьЗаявкуToolStripMenuItem;
		private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
		private System.Windows.Forms.ToolStripMenuItem создатьКопиюToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem загрузитьДанныеToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton uploadDataToolStripButton;
		private System.Windows.Forms.ToolStripButton printRequestToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem напечататьToolStripMenuItem;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Percent;
	}
}