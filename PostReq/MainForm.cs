using System;
using System.Reflection;
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
		User currentUser;
		int selectedRow;
		public MainForm()
		{
			unitOfWork = new UnitOfWork();
			filterModel = new FilterModel();
			filterModel.UnitOfWork = unitOfWork;
			InitializeComponent();
			currentUser = UserController.GetUserInfo(Environment.UserDomainName, unitOfWork);
			
			if (currentUser.Post.Privilegies != 0)
				postamtComboBox.Visible = false;
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
			var editRequesModel = new EditRequestModel()
			{
				FormMode = Utils.FormMode.New,
				NomLoader = nomLoader,
				FormText = "Создание заявки"
			};
			AddRequestForm addRequestForm = new AddRequestForm(editRequesModel);
			addRequestForm.ShowDialog(this);
			unitOfWork = new UnitOfWork();
			filterModel.UnitOfWork = unitOfWork;
			bindingSource1.DataSource = RequestController.GetRequests(filterModel);
			if (addRequestForm.Result > 0)
				setGridSelectedItem(addRequestForm.Result);
		}

		void EditCurrentRequest()
		{
			if (bindingSource1.Current == null) return;
			unitOfWork.Dispose();
			var editRequestModel = new EditRequestModel()
			{
				FormMode = Utils.FormMode.Edit,
				NomLoader = nomLoader,
				FormText = "Изменение заявки",
				EditId = ((Request) bindingSource1.Current).Id
			};
			AddRequestForm addRequestForm = new AddRequestForm(editRequestModel);
			unitOfWork=new UnitOfWork();
			filterModel.UnitOfWork = unitOfWork;
			addRequestForm.ShowDialog(this);
			bindingSource1.DataSource = RequestController.GetRequests(filterModel);
		}

		void CreateCopyRequest()
		{
			if (bindingSource1.Current == null) return;
			unitOfWork.Dispose();
			EditRequestModel editRequestModel = new EditRequestModel()
			{
				FormMode = Utils.FormMode.Copy,
				NomLoader = nomLoader,
				FormText = "Создание заявки",
				EditId = ((Request) bindingSource1.Current).Id
			};
			AddRequestForm addRequestForm = new AddRequestForm(editRequestModel);
			addRequestForm.ShowDialog(this);
			unitOfWork = new UnitOfWork();
			filterModel.UnitOfWork = unitOfWork;
			bindingSource1.DataSource = RequestController.GetRequests(filterModel);
		}

		private void LoadData()
		{
			if (bindingSource1.Current == null) return;
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Таблицы Excel (*.xls)|*.xls";
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
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

		private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				try
				{
					var htInfo = dataGridView1.HitTest(e.X, e.Y);
					dataGridView1.ClearSelection();
					if (htInfo != null)
					{
						bindingSource1.Position = htInfo.RowIndex;
					}
				}
				catch
				{
				}
			}
		}
	}
}
