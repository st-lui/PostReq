using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using PostReq.Controller;
using PostReq.Model;
using PostReq.Util;

namespace PostReq
{
	public partial class AddRequestForm : Form
	{
		private Utils.FormMode formMode;
		SearchModel searchModel;
		NomLoader nomLoader;
		Request request;
		List<RequestRow> requestRowList;
		BindingSource bsSource;
		UnitOfWork unitOfWork;
		bool changed = false;
		public int Result { get; private set; }

		public AddRequestForm(EditRequestModel editRequestModel)
		{
			InitializeComponent();
			this.formMode = editRequestModel.FormMode;
			Text = editRequestModel.FormText;
			Stack<Control> controlsStack = new Stack<Control>();
			controlsStack.Push(this);
			while (controlsStack.Count > 0)
			{
				var control = controlsStack.Pop();
				control.KeyUp += AllControlsKeyUpHandler;
				foreach (Control o in control.Controls)
				{
					controlsStack.Push(o);
				}
			}
			this.nomLoader = editRequestModel.NomLoader;
			searchModel = new SearchModel();
			this.unitOfWork = new UnitOfWork();
			if (formMode == Utils.FormMode.New)
			{
				request = new Request();
				request.User = UserController.GetUserInfo(request.Username, unitOfWork);
				requestRowBindingSource.DataSource = request.RequestRows;
				dataGridView1.DataSource = requestRowBindingSource;
			}
			else
			if (formMode == Utils.FormMode.Copy)
			{
				request = new Request(unitOfWork.Requests.Get(editRequestModel.EditId));
				request.User = UserController.GetUserInfo(request.Username, unitOfWork);
				requestRowBindingSource.DataSource = request.RequestRows;
				dataGridView1.DataSource = requestRowBindingSource;
			}
			else
			if (formMode == Utils.FormMode.Edit)
			{
				request = unitOfWork.Requests.Get(editRequestModel.EditId);
				requestRowBindingSource.DataSource = request.RequestRows;
				dataGridView1.DataSource = requestRowBindingSource;
			}
			nomLoader.LoadNomListToTreeView(treeView1);
			Result = 0;
			CancelButton = cancelButton;
			cancelButton.DialogResult=DialogResult.None;
			//bsSource = new BindingSource();
			//bsSource.DataSource = ReqDataContext.GetInstance().Requests;
			//Request r = (Request) bsSource.AddNew();
			//r.Date=DateTime.Now;
			//r.Username = $"{Environment.UserDomainName}\\{Environment.UserName}";
			//requestRowBindingSource.DataSource = r.RequestRows;
			//dataGridView1.DataSource = requestRowBindingSource;
			//dataGridView1.Columns.Clear();
			//dataGridView1.Columns.Add(new DataGridViewButtonColumn()
			//{
			//	DataPropertyName = "StringRep",
			//	HeaderText = "",
			//	AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
			//});
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			searchModel.NomList = nomLoader.NomList;
			//backgroundWorker1.RunWorkerAsync();
			Form1_Resize(sender, e);
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			treeView1.Width = (int)Math.Round(Width * 0.4 - treeView1.Left);
			dataGridView1.Left = (int)Math.Round(Width * 0.55);
			int w = 30;
			dataGridView1.Width = Width - dataGridView1.Left - w;
			label2.Left = dataGridView1.Left;
			int widthAdd = 20;
			searchPatternTextBox.Left = treeView1.Right + widthAdd;
			findButton.Left = treeView1.Right + widthAdd;
			addPositionButton.Left = treeView1.Right + widthAdd;
			deletePositionButton.Left = treeView1.Right + widthAdd;
			changePositionAmount.Left = treeView1.Right + widthAdd;
			saveAndSendButton.Left = treeView1.Right + widthAdd;
			saveButton.Left = treeView1.Right + widthAdd;
			cancelButton.Left = treeView1.Right + widthAdd;
			printRequestButton.Left = treeView1.Right + widthAdd;
		}

		private void findButton_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(searchPatternTextBox.Text))
			{
				if (searchModel.SearchPattern != searchPatternTextBox.Text)
				{
					searchModel.PreviousResult = null;
					searchModel.CurrentResult = null;
				}
				searchModel.SearchPattern = searchPatternTextBox.Text;
				searchModel = SearchController.PerformSearch(searchModel);
				if (searchModel.SearchResult)
				{
					treeView1.SelectedNode = treeView1.Nodes.Find(searchModel.CurrentResult, true)[0];
					treeView1.Focus();
				}
				else
				{
					MessageBox.Show($"Не удается найти \"{searchModel.SearchPattern}\"", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
					searchModel.PreviousResult = null;
					searchModel.CurrentResult = null;
				}
			}
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Parent != null) categoryStatusBarLabel.Text = ((Nom)e.Node.Parent.Tag).Name;
		}

		private void addPositionButton_Click(object sender, EventArgs e)
		{
			TreeNode currentNode = treeView1.SelectedNode;
			if (currentNode.Nodes.Count == 0)
			{
				Nom nom = (Nom)currentNode.Tag;
				bool nomFound = false;
				foreach (var o in requestRowBindingSource.List)
				{
					RequestRow requestRow = (RequestRow)o;
					if (requestRow.GoodsId == nom.Id)
						nomFound = true;
				}
				if (!nomFound)
				{
					if (formMode == Utils.FormMode.New || formMode == Utils.FormMode.Copy)
					{
						var changeAmountForm = new ChangeAmountForm(nom.Name, nom.EdIzm);
						if (changeAmountForm.ShowDialog(this) == DialogResult.OK)
						{
							requestRowBindingSource.Add(new RequestRow()
							{
								Amount = changeAmountForm.Value,
								EdIzm = nom.EdIzm,
								GoodsId = nom.Id,
								Name = nom.Name,
								Code = nom.Code,
								Request = request,
								Price = nom.Price

							});
							treeView1.Focus();
							Change(true);
						}
					}
					else
					{
						var changeAmountForm = new ChangeAmountForm(nom.Name, nom.EdIzm);
						if (changeAmountForm.ShowDialog(this) == DialogResult.OK)
						{
							var requestRow = new RequestRow()
							{
								Amount = changeAmountForm.Value,
								EdIzm = nom.EdIzm,
								GoodsId = nom.Id,
								Name = nom.Name,
								RequestId = request.Id,
								Price = nom.Price,
								Code = nom.Code
							};
							unitOfWork.RequestRows.Add(requestRow);
							requestRowBindingSource.Add(requestRow);
							treeView1.Focus();
							Change(true);
						}

					}
				}

			}
			else
			{
				MessageBox.Show("Нельзя добавлять категорию");
			}
		}
		private void Refresh(DataGridView gridView)
		{
			CurrencyManager cm = (CurrencyManager)gridView.BindingContext[gridView.DataSource];
			cm.Refresh();
		}

		private void requestRowBindingSource_CurrentChanged(object sender, EventArgs e)
		{

		}

		private void searchPatternTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
				findButton_Click(sender, e);
		}

		private void AllControlsKeyUpHandler(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F3)
				findButton_Click(sender, e);
			if (e.KeyCode == Keys.F && e.Control)
				searchPatternTextBox.Focus();
		}

		private void changePositionAmount_Click(object sender, EventArgs e)
		{
			RequestRow currentRequestRow = (RequestRow)requestRowBindingSource.Current;
			var changeAmountForm = new ChangeAmountForm(currentRequestRow.Name, currentRequestRow.EdIzm, currentRequestRow.Amount);
			if (changeAmountForm.ShowDialog(this) == DialogResult.OK)
			{
				currentRequestRow.Amount = changeAmountForm.Value;
				Refresh(dataGridView1);
				dataGridView1.Focus();
				Change(true);
			}
		}

		private void saveAndSendButton_Click(object sender, EventArgs e)
		{
			SaveRequest();
			SendRequest();
			Result = request.Id;
			Close();
		}

		private void SaveRequest()
		{
			if (formMode == Utils.FormMode.New || formMode == Utils.FormMode.Copy)
			{
				request.State = unitOfWork.States.Get(Properties.Resources.requestStateSaved);
				unitOfWork.Requests.Add(request);
				unitOfWork.SaveChanges();
				formMode = Utils.FormMode.Edit;
				//requestRowBindingSource.DataSource = request.RequestRows;
				//dataGridView1.DataSource = requestRowBindingSource;
				Change(false);
			}
			else
			{
				unitOfWork.SaveChanges();
				Change(false);
			}
		}

		void SendRequest()
		{
			request.State = unitOfWork.States.Get(Properties.Resources.requestStateSent);
			unitOfWork.SaveChanges();
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			SaveRequest();
			Result = request.Id;
		}

		private void deletePositionButton_Click(object sender, EventArgs e)
		{
			if (formMode == Utils.FormMode.New || formMode == Utils.FormMode.Copy)
			{
				if (requestRowBindingSource.Current != null)
					requestRowBindingSource.RemoveCurrent();
			}
			else if (requestRowBindingSource.Current != null)
			{
				((RequestRow) requestRowBindingSource.Current).Request = null;
				unitOfWork.RequestRows.Delete((RequestRow) requestRowBindingSource.Current);
				requestRowBindingSource.RemoveCurrent();
			}
			dataGridView1.Focus();
			Change(true);
		}

		void Change(bool change)
		{
			if (change)
			{
				changed = true;
				infoStatusBarLabel.Text = "Заявка изменена";
			}
			else
			{
				changed = false;
				infoStatusBarLabel.Text = "Заявка сохранена";
			}
		}

		private void AddRequestForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			unitOfWork.Dispose();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void printRequestButton_Click(object sender, EventArgs e)
		{
			string fileName = null;
			if (formMode == Utils.FormMode.New)
				fileName = RequestController.GeneratePrintForm(request, ((IEnumerable<RequestRow>)requestRowBindingSource.DataSource).ToList());
			else
				fileName = RequestController.GeneratePrintForm(request, request.RequestRows.ToList());
			if (fileName != null)
				Process.Start(fileName);
		}

		private void AddRequestForm_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				cancelButton_Click(sender, e);
		}

		private void AddRequestForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (changed)
			{
				DialogResult closeResult = MessageBox.Show("В заявке есть несохраненные изменения. Вы хотите сохранить заявку?",
					"Заявки на поставку товаров", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
				if (closeResult == DialogResult.Yes)
				{
					SaveRequest();
					Result = request.Id;
				}
				else if (closeResult == DialogResult.No)
					e.Cancel = false;
				else if (closeResult == DialogResult.Cancel)
					e.Cancel = true;
			}
			else
				e.Cancel = false;
		}
	}
}
