using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
			if (Directory.Exists("files"))
			{
				var files = Directory.GetFiles("files");
				foreach (var filePath in files)
				{
					try
					{
						File.Delete(filePath);
					}
					catch (IOException)
					{
					}
				}
			}
			unitOfWork = new UnitOfWork();
			filterModel = new FilterModel();
			filterModel.UnitOfWork = unitOfWork;
			InitializeComponent();
			currentUser = UserController.GetUserInfo(Environment.UserDomainName, unitOfWork);
			Text += $" {Assembly.GetExecutingAssembly().GetName().Version}";
			ToolStripControlHost tsHostFrom = new ToolStripControlHost(fromDateTimePicker);
			ToolStripControlHost tsHostTo = new ToolStripControlHost(toDateTimePicker);
			tsHostFrom.Height = 40;
			tsHostTo.Height = 40;
			toolStrip1.Items.Insert(8, tsHostTo);
			toolStrip1.Items.Insert(7, tsHostFrom);
			toolStrip1.Height = 40;
			if (currentUser.Post.Privilegies == 1)
				ChangeInterfacePriv1();
			else
				if (currentUser.Post.Privilegies == 0)
					ChangeInterfacePriv0();
			bindingSource1.DataSource = RequestController.GetRequests(filterModel);
			//dataGridView1.DataSource = requestBindingSource;
			//for (int i = 0; i < dataGridView1.ColumnCount; i++)
			//{
			//	dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
			//}
			nomLoader = NomLoader.Create();
			nomLoader.UpdateLocalNom();


		}

		private void ChangeInterfacePriv1()
		{
			создатьКопиюToolStripMenuItem.Visible = false;
			addRequestToolStripButton.Visible = false;
			copyRequestToolStripButton.Visible = false;
			создатьКопиюToolStripMenuItem.Dispose();
			addRequestToolStripButton.Dispose();
			copyRequestToolStripButton.Dispose();
			GC.Collect();
			GC.WaitForPendingFinalizers();
			filterModel.States.Add(unitOfWork.States.Get(Properties.Resources.requestStateLoaded));
			filterModel.States.Add(unitOfWork.States.Get(Properties.Resources.requestStateSent));
			filterModel.Post = null;
			filterModel.DateFrom = fromDateTimePicker.Value;
			filterModel.DateTo = toDateTimePicker.Value;
		}

		private void ChangeInterfacePriv0()
		{
			postamtComboBox.Visible = false;
			uploadDataToolStripButton.Visible = false;
			загрузитьДанныеToolStripMenuItem.Visible = false;
			postamtComboBox.Dispose();
			uploadDataToolStripButton.Dispose();
			загрузитьДанныеToolStripMenuItem.Dispose();
			GC.Collect();
			GC.WaitForPendingFinalizers();
			filterModel.States.Add(unitOfWork.States.Get(Properties.Resources.requestStateLoaded));
			filterModel.States.Add(unitOfWork.States.Get(Properties.Resources.requestStateSent));
			filterModel.States.Add(unitOfWork.States.Get(Properties.Resources.requestStateSaved));
			filterModel.Post = currentUser.Post;
			filterModel.DateFrom = fromDateTimePicker.Value;
			filterModel.DateTo = toDateTimePicker.Value;
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
				EditId = ((Request)bindingSource1.Current).Id
			};
			AddRequestForm addRequestForm = new AddRequestForm(editRequestModel);
			addRequestForm.ShowDialog(this);

			unitOfWork = new UnitOfWork();
			filterModel.UnitOfWork = unitOfWork;
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
				EditId = ((Request)bindingSource1.Current).Id
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
				RequestController.LoadData(new UploadDataModel() { FileName = openFileDialog.FileName, Request = (Request)bindingSource1.Current, UnitOfWork = unitOfWork });
			}
		}

		private void PrintCurrentRequest()
		{
			if (bindingSource1.Current == null)
				return;
			var fileName = RequestController.GeneratePrintForm((Request)bindingSource1.Current, ((Request)bindingSource1.Current).RequestRows.ToList());
			if (fileName != null)
				Process.Start(fileName);
		}

		private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				EditCurrentRequest();
			}
		}

		private void copyRequestToolStripButton_Click(object sender, EventArgs e)
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

		private void openRequestToolStripButton_Click(object sender, EventArgs e)
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

		private void uploadDataToolStripButton_Click(object sender, EventArgs e)
		{
			LoadData();
		}

		private void printRequestToolStripButton_Click(object sender, EventArgs e)
		{
			PrintCurrentRequest();
		}

		private void напечататьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PrintCurrentRequest();
		}

		private void toDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			filterModel.DateTo = new DateTime(toDateTimePicker.Value.Year,toDateTimePicker.Value.Month,toDateTimePicker.Value.Day);
			bindingSource1.DataSource = RequestController.GetRequests(filterModel);
		}

		private void fromDateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			filterModel.DateFrom = new DateTime(fromDateTimePicker.Value.Year, fromDateTimePicker.Value.Month, fromDateTimePicker.Value.Day);
			bindingSource1.DataSource = RequestController.GetRequests(filterModel);
		}
	}
}
