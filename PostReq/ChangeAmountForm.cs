using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PostReq.Model;

namespace PostReq
{
	public partial class ChangeAmountForm : Form
	{
		private readonly string name;
		private readonly string edIzm;
		public double Value{ get; private set; }
		double currentValue;

		public ChangeAmountForm()
		{
			InitializeComponent();
		}

		public ChangeAmountForm(string name,string edIzm)
		{
			this.name = name;
			this.edIzm = edIzm;
			InitializeComponent();
			currentValue = 0;
		}

		public ChangeAmountForm(string name, string edIzm, double currentValue)
		{
			InitializeComponent();
			this.name = name;
			this.edIzm = edIzm;
			this.currentValue = currentValue;
		}

		private void acceptButton_Click(object sender, EventArgs e)
		{
			bool parsed = false;
			double val = 0;
			parsed = double.TryParse(valueTextBox.Text,NumberStyles.Float,CultureInfo.GetCultureInfo("en-US"),out val);
			if (parsed)
			{
				Value = val;
				DialogResult=DialogResult.OK;
				Close();
			}
			else
			{
				parsed = double.TryParse(valueTextBox.Text, NumberStyles.Float, CultureInfo.GetCultureInfo("ru-RU"), out val);
				if (parsed)
				{
					Value = val;
					DialogResult = DialogResult.OK;
					Close();
				}
				else
				{
					MessageBox.Show("Введено некорректное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
		}

		private void ChangeAmountForm_Load(object sender, EventArgs e)
		{
			nomLabel.Text = name;
			edIzmLabel.Text = edIzm;
			valueTextBox.Text = currentValue.ToString("f3");
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
