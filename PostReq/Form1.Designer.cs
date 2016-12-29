namespace PostReq
{
	partial class AddRequestForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRequestForm));
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.findButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this._Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FactAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label2 = new System.Windows.Forms.Label();
			this.searchPatternTextBox = new System.Windows.Forms.TextBox();
			this.addPositionButton = new System.Windows.Forms.Button();
			this.deletePositionButton = new System.Windows.Forms.Button();
			this.changePositionAmount = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.saveAndSendButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.categoryStatusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.infoStatusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.printRequestButton = new System.Windows.Forms.Button();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.edIzmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.goodsIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.requestIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.stringRepDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.amountStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.requestRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.requestRowBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.treeView1.HideSelection = false;
			this.treeView1.Location = new System.Drawing.Point(12, 51);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(359, 311);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// findButton
			// 
			this.findButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.findButton.Location = new System.Drawing.Point(390, 78);
			this.findButton.Name = "findButton";
			this.findButton.Size = new System.Drawing.Size(143, 23);
			this.findButton.TabIndex = 2;
			this.findButton.Text = "Найти";
			this.toolTip1.SetToolTip(this.findButton, "Поиск по номенклатуре");
			this.findButton.UseVisualStyleBackColor = true;
			this.findButton.Click += new System.EventHandler(this.findButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Номенклатура";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Name,
            this.Amount,
            this.Column1,
            this.Column2,
            this.idDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.edIzmDataGridViewTextBoxColumn,
            this.goodsIdDataGridViewTextBoxColumn,
            this.requestIdDataGridViewTextBoxColumn,
            this.stringRepDataGridViewTextBoxColumn,
            this.amountStringDataGridViewTextBoxColumn,
            this.FactAmount,
            this.Percent});
			this.dataGridView1.DataSource = this.requestRowBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(575, 51);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowHeadersWidth = 15;
			this.dataGridView1.RowTemplate.Height = 18;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(454, 311);
			this.dataGridView1.TabIndex = 10;
			// 
			// _Name
			// 
			this._Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this._Name.DataPropertyName = "Name";
			this._Name.HeaderText = "Номенклатура";
			this._Name.Name = "_Name";
			this._Name.ReadOnly = true;
			this._Name.Width = 105;
			// 
			// Amount
			// 
			this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Amount.DataPropertyName = "AmountString";
			this.Amount.HeaderText = "Количество";
			this.Amount.Name = "Amount";
			this.Amount.ReadOnly = true;
			this.Amount.Width = 92;
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "Price";
			dataGridViewCellStyle1.Format = "F2";
			this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
			this.Column1.HeaderText = "Цена";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "Cost";
			dataGridViewCellStyle2.Format = "F2";
			this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
			this.Column2.HeaderText = "Сумма";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// FactAmount
			// 
			this.FactAmount.DataPropertyName = "FactAmount";
			dataGridViewCellStyle3.Format = "f3";
			this.FactAmount.DefaultCellStyle = dataGridViewCellStyle3;
			this.FactAmount.HeaderText = "Факт";
			this.FactAmount.Name = "FactAmount";
			this.FactAmount.ReadOnly = true;
			// 
			// Percent
			// 
			this.Percent.DataPropertyName = "Percent";
			dataGridViewCellStyle4.Format = "f2";
			this.Percent.DefaultCellStyle = dataGridViewCellStyle4;
			this.Percent.HeaderText = "Процент";
			this.Percent.Name = "Percent";
			this.Percent.ReadOnly = true;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(572, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Состав заявки";
			// 
			// searchPatternTextBox
			// 
			this.searchPatternTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.searchPatternTextBox.Location = new System.Drawing.Point(390, 51);
			this.searchPatternTextBox.Name = "searchPatternTextBox";
			this.searchPatternTextBox.Size = new System.Drawing.Size(143, 21);
			this.searchPatternTextBox.TabIndex = 1;
			this.searchPatternTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchPatternTextBox_KeyPress);
			// 
			// addPositionButton
			// 
			this.addPositionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.addPositionButton.Location = new System.Drawing.Point(390, 108);
			this.addPositionButton.Name = "addPositionButton";
			this.addPositionButton.Size = new System.Drawing.Size(143, 23);
			this.addPositionButton.TabIndex = 3;
			this.addPositionButton.Text = "Добавить в заявку";
			this.toolTip1.SetToolTip(this.addPositionButton, "Добавить выбранную позицию в заявку");
			this.addPositionButton.UseVisualStyleBackColor = true;
			this.addPositionButton.Click += new System.EventHandler(this.addPositionButton_Click);
			// 
			// deletePositionButton
			// 
			this.deletePositionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.deletePositionButton.Location = new System.Drawing.Point(390, 137);
			this.deletePositionButton.Name = "deletePositionButton";
			this.deletePositionButton.Size = new System.Drawing.Size(143, 23);
			this.deletePositionButton.TabIndex = 4;
			this.deletePositionButton.Text = "Убрать из заявки";
			this.toolTip1.SetToolTip(this.deletePositionButton, "Удалить выбранную позицию из заявки");
			this.deletePositionButton.UseVisualStyleBackColor = true;
			this.deletePositionButton.Click += new System.EventHandler(this.deletePositionButton_Click);
			// 
			// changePositionAmount
			// 
			this.changePositionAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.changePositionAmount.Location = new System.Drawing.Point(390, 166);
			this.changePositionAmount.Name = "changePositionAmount";
			this.changePositionAmount.Size = new System.Drawing.Size(143, 23);
			this.changePositionAmount.TabIndex = 5;
			this.changePositionAmount.Text = "Изменить количество";
			this.toolTip1.SetToolTip(this.changePositionAmount, "Изменить количество товара по выбранной позиции");
			this.changePositionAmount.UseVisualStyleBackColor = true;
			this.changePositionAmount.Click += new System.EventHandler(this.changePositionAmount_Click);
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(390, 310);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(143, 23);
			this.saveButton.TabIndex = 8;
			this.saveButton.Text = "Сохранить";
			this.toolTip1.SetToolTip(this.saveButton, "Сохранить заявку без отправки");
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// saveAndSendButton
			// 
			this.saveAndSendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.saveAndSendButton.Location = new System.Drawing.Point(390, 281);
			this.saveAndSendButton.Name = "saveAndSendButton";
			this.saveAndSendButton.Size = new System.Drawing.Size(143, 23);
			this.saveAndSendButton.TabIndex = 7;
			this.saveAndSendButton.Text = "Отправить заявку";
			this.toolTip1.SetToolTip(this.saveAndSendButton, "Сохранить и отправить заявку в УФПС");
			this.saveAndSendButton.UseVisualStyleBackColor = true;
			this.saveAndSendButton.Click += new System.EventHandler(this.saveAndSendButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(390, 339);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(143, 23);
			this.cancelButton.TabIndex = 9;
			this.cancelButton.Text = "Закрыть без сохранения";
			this.toolTip1.SetToolTip(this.cancelButton, "Закрыть окно без сохранения заявки");
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoryStatusBarLabel,
            this.infoStatusBarLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 374);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1020, 22);
			this.statusStrip1.TabIndex = 10;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// categoryStatusBarLabel
			// 
			this.categoryStatusBarLabel.Name = "categoryStatusBarLabel";
			this.categoryStatusBarLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// infoStatusBarLabel
			// 
			this.infoStatusBarLabel.Name = "infoStatusBarLabel";
			this.infoStatusBarLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// printRequestButton
			// 
			this.printRequestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.printRequestButton.Location = new System.Drawing.Point(390, 223);
			this.printRequestButton.Name = "printRequestButton";
			this.printRequestButton.Size = new System.Drawing.Size(143, 23);
			this.printRequestButton.TabIndex = 6;
			this.printRequestButton.Text = "Печать заявки";
			this.toolTip1.SetToolTip(this.printRequestButton, "Вывести печатную формы заявки");
			this.printRequestButton.UseVisualStyleBackColor = true;
			this.printRequestButton.Click += new System.EventHandler(this.printRequestButton_Click);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			// 
			// idDataGridViewTextBoxColumn
			// 
			this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
			this.idDataGridViewTextBoxColumn.HeaderText = "Id";
			this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			this.idDataGridViewTextBoxColumn.ReadOnly = true;
			this.idDataGridViewTextBoxColumn.Visible = false;
			// 
			// amountDataGridViewTextBoxColumn
			// 
			this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
			this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
			this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
			this.amountDataGridViewTextBoxColumn.ReadOnly = true;
			this.amountDataGridViewTextBoxColumn.Visible = false;
			// 
			// nameDataGridViewTextBoxColumn
			// 
			this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
			this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			this.nameDataGridViewTextBoxColumn.ReadOnly = true;
			this.nameDataGridViewTextBoxColumn.Visible = false;
			// 
			// edIzmDataGridViewTextBoxColumn
			// 
			this.edIzmDataGridViewTextBoxColumn.DataPropertyName = "EdIzm";
			this.edIzmDataGridViewTextBoxColumn.HeaderText = "EdIzm";
			this.edIzmDataGridViewTextBoxColumn.Name = "edIzmDataGridViewTextBoxColumn";
			this.edIzmDataGridViewTextBoxColumn.ReadOnly = true;
			this.edIzmDataGridViewTextBoxColumn.Visible = false;
			// 
			// goodsIdDataGridViewTextBoxColumn
			// 
			this.goodsIdDataGridViewTextBoxColumn.DataPropertyName = "GoodsId";
			this.goodsIdDataGridViewTextBoxColumn.HeaderText = "GoodsId";
			this.goodsIdDataGridViewTextBoxColumn.Name = "goodsIdDataGridViewTextBoxColumn";
			this.goodsIdDataGridViewTextBoxColumn.ReadOnly = true;
			this.goodsIdDataGridViewTextBoxColumn.Visible = false;
			// 
			// requestIdDataGridViewTextBoxColumn
			// 
			this.requestIdDataGridViewTextBoxColumn.DataPropertyName = "RequestId";
			this.requestIdDataGridViewTextBoxColumn.HeaderText = "RequestId";
			this.requestIdDataGridViewTextBoxColumn.Name = "requestIdDataGridViewTextBoxColumn";
			this.requestIdDataGridViewTextBoxColumn.ReadOnly = true;
			this.requestIdDataGridViewTextBoxColumn.Visible = false;
			// 
			// stringRepDataGridViewTextBoxColumn
			// 
			this.stringRepDataGridViewTextBoxColumn.DataPropertyName = "StringRep";
			this.stringRepDataGridViewTextBoxColumn.HeaderText = "StringRep";
			this.stringRepDataGridViewTextBoxColumn.Name = "stringRepDataGridViewTextBoxColumn";
			this.stringRepDataGridViewTextBoxColumn.ReadOnly = true;
			this.stringRepDataGridViewTextBoxColumn.Visible = false;
			// 
			// amountStringDataGridViewTextBoxColumn
			// 
			this.amountStringDataGridViewTextBoxColumn.DataPropertyName = "AmountString";
			this.amountStringDataGridViewTextBoxColumn.HeaderText = "AmountString";
			this.amountStringDataGridViewTextBoxColumn.Name = "amountStringDataGridViewTextBoxColumn";
			this.amountStringDataGridViewTextBoxColumn.ReadOnly = true;
			this.amountStringDataGridViewTextBoxColumn.Visible = false;
			// 
			// requestRowBindingSource
			// 
			this.requestRowBindingSource.DataSource = typeof(PostReq.Model.RequestRow);
			this.requestRowBindingSource.CurrentChanged += new System.EventHandler(this.requestRowBindingSource_CurrentChanged);
			// 
			// AddRequestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1020, 396);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.saveAndSendButton);
			this.Controls.Add(this.printRequestButton);
			this.Controls.Add(this.changePositionAmount);
			this.Controls.Add(this.deletePositionButton);
			this.Controls.Add(this.addPositionButton);
			this.Controls.Add(this.searchPatternTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.findButton);
			this.Controls.Add(this.treeView1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AddRequestForm";
			this.ShowInTaskbar = false;
			this.Text = "Новая заявка";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddRequestForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddRequestForm_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AddRequestForm_KeyUp);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.requestRowBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Button findButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox searchPatternTextBox;
		private System.Windows.Forms.Button addPositionButton;
		private System.Windows.Forms.Button deletePositionButton;
		private System.Windows.Forms.Button changePositionAmount;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button saveAndSendButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel categoryStatusBarLabel;
		private System.Windows.Forms.Button printRequestButton;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.BindingSource requestRowBindingSource;
		private System.Windows.Forms.ToolStripStatusLabel infoStatusBarLabel;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Percent;
		private System.Windows.Forms.DataGridViewTextBoxColumn FactAmount;
		private System.Windows.Forms.DataGridViewTextBoxColumn amountStringDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn stringRepDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn requestIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn goodsIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn edIzmDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
		private System.Windows.Forms.DataGridViewTextBoxColumn _Name;
	}
}

