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
		UnitOfWork unitOfWork;
		public MainForm()
		{
			unitOfWork = new UnitOfWork();
			filterModel = new FilterModel();
			filterModel.UnitOfWork = unitOfWork;
			InitializeComponent();
			Text += $" {Assembly.GetExecutingAssembly().GetName().Version}";
			bindingSource1.DataSource = RequestController.GetRequests(filterModel);
			ToolStripControlHost tsHostFrom = new ToolStripControlHost(fromDateTimePicker);
			ToolStripControlHost tsHostTo = new ToolStripControlHost(toDateTimePicker);
			tsHostFrom.Height = 40;
			tsHostTo.Height = 40;
			toolStrip1.Items.Insert(6, tsHostTo);
			toolStrip1.Items.Insert(5, tsHostFrom);
			toolStrip1.Height = 40;
			//dataGridView1.DataSource = requestBindingSource;
			//for (int i = 0; i < dataGridView1.ColumnCount; i++)
			//{
			//	dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
			//}
			nomLoader = NomLoader.Create();
			nomLoader.UpdateLocalNom();
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
			unitOfWork.Dispose();
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
			unitOfWork.Dispose();
			AddRequestForm addRequestForm = new AddRequestForm(Utils.FormMode.New, nomLoader);
			addRequestForm.ShowDialog(this);
			unitOfWork = new UnitOfWork();
			filterModel.UnitOfWork = unitOfWork;
			if (addRequestForm.Result > 0)
			{
				bindingSource1.DataSource = RequestController.GetRequests(filterModel);
				setGridSelectedItem(addRequestForm.Result);
				//Refresh(dataGridView1);
			}
		}

		void EditCurrentRequest()
		{
			if (bindingSource1.Current == null) return;
			unitOfWork.Dispose();
			AddRequestForm addRequestForm = new AddRequestForm(Utils.FormMode.Edit, nomLoader, ((Request)bindingSource1.Current).Id);
			unitOfWork=new UnitOfWork();
			filterModel.UnitOfWork = unitOfWork;
			addRequestForm.ShowDialog(this);
			if (addRequestForm.Result > 0)
				bindingSource1.DataSource = RequestController.GetRequests(filterModel);
		}

		void CreateCopyRequest()
		{
			if (bindingSource1.Current == null) return;
			unitOfWork.Dispose();
			AddRequestForm addRequestForm = new AddRequestForm(Utils.FormMode.Copy, nomLoader, ((Request)bindingSource1.Current).Id);
			addRequestForm.ShowDialog(this);
			unitOfWork = new UnitOfWork();
			filterModel.UnitOfWork = unitOfWork;
			if (addRequestForm.Result > 0)
			{
				bindingSource1.DataSource = RequestController.GetRequests(filterModel);
			}
			
		}

		private void LoadData()
		{
			if (bindingSource1.Current == null) return;
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Таблицы Excel (*.xls)|*.xls";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				RequestController.LoadData(new  UploadDataModel() {FileName = openFileDialog.FileName,Request = (Request)bindingSource1.Current,UnitOfWork = unitOfWork});
			}
		}

		private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				EditCurrentRequest();
			}
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			CreateCopyRequest();
		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			DataGridView grid = (DataGridView)sender;
			DataGridViewRow row = grid.Rows[e.RowIndex];
			DataGridViewColumn col = grid.Columns[e.ColumnIndex];
			if (row.DataBoundItem != null && col.DataPropertyName.Contains("."))
			{
				string[] props = col.DataPropertyName.Split('.');
				PropertyInfo propInfo = row.DataBoundItem.GetType().GetProperty(props[0]);
				object val = propInfo.GetValue(row.DataBoundItem, null);
				for (int i = 1; i < props.Length; i++)
				{
					propInfo = val.GetType().GetProperty(props[i]);
					val = propInfo.GetValue(val, null);
				}
				e.Value = val;
			}
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			EditCurrentRequest();
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
		{
			if (MouseButtons == MouseButtons.Right)
				bindingSource1.Position = e.RowIndex;
			contextMenuStrip1.Show();
		}

		private void открытьЗаявкуToolStripMenuItem_Click(object sender, EventArgs e)
		{
			EditCurrentRequest();
		}

		private void создатьКопиюToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CreateCopyRequest();
		}

		private void загрузитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoadData();
		}
	}
}
