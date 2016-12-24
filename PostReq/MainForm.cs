using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using PostReq.Controller;
using PostReq.Model;
using PostReq.Util;

namespace PostReq
{
	public partial class MainForm : Form
	{
		NomLoader nomLoader;
		FilterModel filterModel;
		public MainForm()
		{
			InitializeComponent();
			Text += $" {Assembly.GetExecutingAssembly().GetName().Version}";
			bindingSource1.DataSource = RequestController.GetRequests(filterModel);
			//dataGridView1.DataSource = requestBindingSource;
			//for (int i = 0; i < dataGridView1.ColumnCount; i++)
			//{
			//	dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
			//}
			nomLoader = NomLoader.Create();
			nomLoader.UpdateLocalNom();
			filterModel = new FilterModel();
		}

		private void выходToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
		}

		private void Refresh(DataGridView gridView)
		{
			CurrencyManager cm = (CurrencyManager)gridView.BindingContext[gridView.DataSource];
			cm.Refresh();
		}

		void setGridSelectedItem(int id)
		{
			for (int i = 0; i < bindingSource1.List.Count; i++)
			{
				Request req = (Request)bindingSource1.List[i];
				if (req.Id == id)
				{
					bindingSource1.Position = i;
				}
			}
		}

		private void addRequestToolStripButton_Click(object sender, EventArgs e)
		{
			AddRequestForm addRequestForm = new AddRequestForm(Utils.FormMode.New, nomLoader);
			addRequestForm.ShowDialog();
			if (addRequestForm.Result > 0)
			{
				bindingSource1.DataSource = RequestController.GetRequests(filterModel);
				setGridSelectedItem(addRequestForm.Result);
				//Refresh(dataGridView1);
			}

		}

		void editCurrentRequest()
		{
			AddRequestForm addRequestForm = new AddRequestForm(Utils.FormMode.Edit, nomLoader, ((Request)bindingSource1.Current).Id);
			addRequestForm.ShowDialog();
			if (addRequestForm.Result > 0)
			{
				bindingSource1.DataSource = RequestController.GetRequests(filterModel);
			}
		}

		private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				editCurrentRequest();
			}
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			editCurrentRequest();
		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			//DataGridView grid = (DataGridView)sender;
			//DataGridViewRow row = grid.Rows[e.RowIndex];
			//DataGridViewColumn col = grid.Columns[e.ColumnIndex];
			//if (row.DataBoundItem != null && col.DataPropertyName.Contains("."))
			//{
			//	string[] props = col.DataPropertyName.Split('.');
			//	PropertyInfo propInfo = row.DataBoundItem.GetType().GetProperty(props[0]);
			//	object val = propInfo.GetValue(row.DataBoundItem, null);
			//	for (int i = 1; i < props.Length; i++)
			//	{
			//		propInfo = val.GetType().GetProperty(props[i]);
			//		val = propInfo.GetValue(val, null);
			//	}
			//	e.Value = val;
			//}
		}
	}
}
