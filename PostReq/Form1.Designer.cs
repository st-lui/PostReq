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
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.findButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.searchPatternTextBox = new System.Windows.Forms.TextBox();
			this.addPositionButton = new System.Windows.Forms.Button();
			this.deletePositionButton = new System.Windows.Forms.Button();
			this.changePositionAmount = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.saveAndSendButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.categoryLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.printRequestButton = new System.Windows.Forms.Button();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.requestRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.stringRepDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stringRepDataGridViewTextBoxColumn});
			this.dataGridView1.Location = new System.Drawing.Point(575, 51);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowHeadersWidth = 15;
			this.dataGridView1.RowTemplate.Height = 18;
			this.dataGridView1.Size = new System.Drawing.Size(454, 311);
			this.dataGridView1.TabIndex = 9;
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
			this.deletePositionButton.UseVisualStyleBackColor = true;
			// 
			// changePositionAmount
			// 
			this.changePositionAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.changePositionAmount.Location = new System.Drawing.Point(390, 166);
			this.changePositionAmount.Name = "changePositionAmount";
			this.changePositionAmount.Size = new System.Drawing.Size(143, 23);
			this.changePositionAmount.TabIndex = 5;
			this.changePositionAmount.Text = "Изменить количество";
			this.changePositionAmount.UseVisualStyleBackColor = true;
			this.changePositionAmount.Click += new System.EventHandler(this.changePositionAmount_Click);
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(390, 310);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(143, 23);
			this.saveButton.TabIndex = 7;
			this.saveButton.Text = "Сохранить";
			this.saveButton.UseVisualStyleBackColor = true;
			// 
			// saveAndSendButton
			// 
			this.saveAndSendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.saveAndSendButton.Location = new System.Drawing.Point(390, 281);
			this.saveAndSendButton.Name = "saveAndSendButton";
			this.saveAndSendButton.Size = new System.Drawing.Size(143, 23);
			this.saveAndSendButton.TabIndex = 6;
			this.saveAndSendButton.Text = "Отправить заявку";
			this.saveAndSendButton.UseVisualStyleBackColor = true;
			this.saveAndSendButton.Click += new System.EventHandler(this.saveAndSendButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(390, 339);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(143, 23);
			this.cancelButton.TabIndex = 8;
			this.cancelButton.Text = "Закрыть без сохранения";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoryLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 374);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1020, 22);
			this.statusStrip1.TabIndex = 10;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// categoryLabel
			// 
			this.categoryLabel.Name = "categoryLabel";
			this.categoryLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// printRequestButton
			// 
			this.printRequestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.printRequestButton.Location = new System.Drawing.Point(390, 223);
			this.printRequestButton.Name = "printRequestButton";
			this.printRequestButton.Size = new System.Drawing.Size(143, 23);
			this.printRequestButton.TabIndex = 5;
			this.printRequestButton.Text = "Печать заявки";
			this.printRequestButton.UseVisualStyleBackColor = true;
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			// 
			// requestRowBindingSource
			// 
			this.requestRowBindingSource.DataSource = typeof(PostReq.Model.RequestRow);
			this.requestRowBindingSource.CurrentChanged += new System.EventHandler(this.requestRowBindingSource_CurrentChanged);
			// 
			// stringRepDataGridViewTextBoxColumn
			// 
			this.stringRepDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.stringRepDataGridViewTextBoxColumn.DataPropertyName = "StringRep";
			this.stringRepDataGridViewTextBoxColumn.HeaderText = "";
			this.stringRepDataGridViewTextBoxColumn.Name = "stringRepDataGridViewTextBoxColumn";
			this.stringRepDataGridViewTextBoxColumn.ReadOnly = true;
			this.stringRepDataGridViewTextBoxColumn.Width = 19;
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
			this.Name = "AddRequestForm";
			this.Text = "Новая заявка";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form1_Load);
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
		private System.Windows.Forms.ToolStripStatusLabel categoryLabel;
		private System.Windows.Forms.Button printRequestButton;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.DataGridViewTextBoxColumn stringRepDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource requestRowBindingSource;
	}
}

