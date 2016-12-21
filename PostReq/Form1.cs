using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PostReq.Controller;
using PostReq.Model;
using PostReq.Util;
using DataGrid = System.Web.UI.WebControls.DataGrid;

namespace PostReq
{
	public partial class AddRequestForm : Form
	{
		SearchModel searchModel;
		NomLoader nomLoader;
		List<RequestRow> requestRowList;
		BindingSource bsSource;
		public AddRequestForm()
		{
			InitializeComponent();
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
			nomLoader = NomLoader.Create();
			searchModel = new SearchModel();
			requestRowList = new List<RequestRow>();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			nomLoader.UpdateLocalNom();
			searchModel.NomList = nomLoader.NomList;
			nomLoader.LoadNomListToTreeView(treeView1);

			//backgroundWorker1.RunWorkerAsync();
			Form1_Resize(sender, e);
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			treeView1.Width = (int)Math.Round(Width * 0.4 - treeView1.Left);
			dataGridView1.Left = (int)Math.Round(Width * 0.6);
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
			if (e.Node.Parent != null) categoryLabel.Text = ((Nom)e.Node.Parent.Tag).Name;
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
					var changeAmountForm = new ChangeAmountForm(nom.Name,nom.EdIzm);
					if (changeAmountForm.ShowDialog() == DialogResult.OK)
						requestRowBindingSource.Add(new RequestRow() { Amount = changeAmountForm.Value, EdIzm = nom.EdIzm, GoodsId = nom.Id, Name = nom.Name });
					treeView1.Focus();
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
		}

		private void changePositionAmount_Click(object sender, EventArgs e)
		{
			RequestRow currentRequestRow= (RequestRow) requestRowBindingSource.Current;
			var changeAmountForm = new ChangeAmountForm(currentRequestRow.Name,currentRequestRow.EdIzm,currentRequestRow.Amount);
			if (changeAmountForm.ShowDialog() == DialogResult.OK)
				currentRequestRow.Amount = changeAmountForm.Value;
			dataGridView1.Focus();
		}

		private void saveAndSendButton_Click(object sender, EventArgs e)
		{

		}
	}
}
