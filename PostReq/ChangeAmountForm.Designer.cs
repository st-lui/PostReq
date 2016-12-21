namespace PostReq
{
	partial class ChangeAmountForm
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
			this.acceptButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.nomLabel = new System.Windows.Forms.Label();
			this.edIzmLabel = new System.Windows.Forms.Label();
			this.valueTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// acceptButton
			// 
			this.acceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.acceptButton.Location = new System.Drawing.Point(104, 75);
			this.acceptButton.Name = "acceptButton";
			this.acceptButton.Size = new System.Drawing.Size(75, 23);
			this.acceptButton.TabIndex = 1;
			this.acceptButton.Text = "ОК";
			this.acceptButton.UseVisualStyleBackColor = true;
			this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(185, 75);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Отмена";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(131, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Введите количество для";
			// 
			// nomLabel
			// 
			this.nomLabel.AutoSize = true;
			this.nomLabel.Location = new System.Drawing.Point(16, 22);
			this.nomLabel.Name = "nomLabel";
			this.nomLabel.Size = new System.Drawing.Size(31, 13);
			this.nomLabel.TabIndex = 3;
			this.nomLabel.Text = "1111";
			// 
			// edIzmLabel
			// 
			this.edIzmLabel.AutoSize = true;
			this.edIzmLabel.Location = new System.Drawing.Point(125, 41);
			this.edIzmLabel.Name = "edIzmLabel";
			this.edIzmLabel.Size = new System.Drawing.Size(25, 13);
			this.edIzmLabel.TabIndex = 4;
			this.edIzmLabel.Text = "tttttt";
			// 
			// valueTextBox
			// 
			this.valueTextBox.Location = new System.Drawing.Point(19, 38);
			this.valueTextBox.Name = "valueTextBox";
			this.valueTextBox.Size = new System.Drawing.Size(100, 20);
			this.valueTextBox.TabIndex = 0;
			// 
			// ChangeAmountForm
			// 
			this.AcceptButton = this.acceptButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(272, 110);
			this.Controls.Add(this.valueTextBox);
			this.Controls.Add(this.edIzmLabel);
			this.Controls.Add(this.nomLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.acceptButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ChangeAmountForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Количество товара";
			this.Load += new System.EventHandler(this.ChangeAmountForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button acceptButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label nomLabel;
		private System.Windows.Forms.Label edIzmLabel;
		private System.Windows.Forms.TextBox valueTextBox;
	}
}