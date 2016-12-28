using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using PostReq.Model;

namespace PostReq.Util
{
	public class NomLoader
	{
		string connectionString;
		string filename;
		FileInfo fileInfo;
		string nomTableName = "_Reference112";
		string edIzmTableName = "_Reference80";
		string priceTableName = "_InfoRg11000";
		public List<Nom> NomList { get; set; }
		private NomLoader() { }
		
		public static NomLoader Create()
		{
			var nomLoader = new NomLoader();
			nomLoader.connectionString = "data source=r22aufsql02;initial catalog=asku-tmp;user=nom_reader;password=6LRZ{w.Y!LHXtY.";
			nomLoader.filename = "nom.txt";
			if (!File.Exists(nomLoader.filename))
			{
				using (File.Create(nomLoader.filename)) ;

			}
			nomLoader.fileInfo = new FileInfo(nomLoader.filename);
			return nomLoader;
		}

		public bool CheckNomUpdate()
		{
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				try
				{
					conn.Open();
					using (SqlCommand comm = new SqlCommand($@"with tree (_IDRRef,_ParentIDRRef,_Code,_level) as 
(select _IDRRef, _ParentIDRRef, _Code, 0 from[{nomTableName}] where _code = '00000000085'
union all select[{nomTableName}]._IDRRef,[{nomTableName}]._ParentIDRRef,[{nomTableName}]._Code, tree._level + 1 from [{nomTableName}], tree 
where tree._IDRRef =[{nomTableName}]._ParentIDRRef and [{nomTableName}]._Code<>'С1-00001709' and [{nomTableName}]._Code<>'С1-00001897')
select count(_IDRRef)from tree; ", conn))
					{
						SqlDataReader dataReader = comm.ExecuteReader();
						dataReader.Read();
						int serverNomCount = dataReader.GetInt32(0);
						int localNomCount = GetLocalNomCount();
						if (serverNomCount != localNomCount)
							return true;
						else
							return false;
					}
					conn.Close();
				}
				catch (Exception e)
				{
					return false;
				}
			}
		}

		public void UpdateLocalNom()
		{
			if (CheckNomUpdate())
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					try
					{
						conn.Open();
						Dictionary<SqlBinary, string> edIzmDictionary = new Dictionary<SqlBinary, string>();
						using (SqlCommand comm = new SqlCommand($"select _IDRRef,_Description from {edIzmTableName};", conn))
						{
							var dataReader = comm.ExecuteReader();
							while (dataReader.Read())
								edIzmDictionary.Add(dataReader.GetSqlBinary(0), dataReader.GetString(1));
							dataReader.Close();
						}
						Dictionary<SqlBinary, double> priceDictionary = new Dictionary<SqlBinary, double>();
						using (SqlCommand comm = new SqlCommand($@"select _Fld11001RRef,_Fld11004 from {priceTableName} s,(
select _Fld11001RRef nomid, max(_Period) period
from {priceTableName}
where _Fld11002RRef = 0xA4AEF4CE46FB566011E3DC100178205B
group by _Fld11001RRef) p
where s._Fld11001RRef = p.nomid and s._Period = p.period", conn))
						{
							var dataReader = comm.ExecuteReader();
							while (dataReader.Read())
							{
								var id = dataReader.GetSqlBinary(0);
								var price = (double) dataReader.GetDecimal(1);
								if (!priceDictionary.ContainsKey(id))
									priceDictionary.Add(id, price);
							}
							dataReader.Close();
						}
						using (SqlCommand comm = new SqlCommand($@"with tree (_IDRRef,_ParentIDRRef,_Description,_Code,_Fld2258RRef,_level) as 
(select _IDRRef,_ParentIDRRef,_Description,_Code,_Fld2258RRef,0 from [{nomTableName}] where _code='00000000085'
union all select [{nomTableName}]._IDRRef,[{nomTableName}]._ParentIDRRef,[{nomTableName}]._Description,[{nomTableName}]._Code,[{nomTableName}]._Fld2258RRef,tree._level+1 from [{nomTableName}],tree
where tree._IDRRef=[{nomTableName}]._ParentIDRRef and [{nomTableName}]._Code<>'С1-00001709' and [{nomTableName}]._Code<>'С1-00001897')
select _IDRRef,_ParentIDRRef,_Description,_Code,_Fld2258RRef from tree;", conn))
						{
							SqlDataReader dataReader = comm.ExecuteReader();
							StreamWriter writer = new StreamWriter(new FileStream(filename, FileMode.Create), Encoding.GetEncoding(1251));

							while (dataReader.Read())
							{
								Nom nom = new Nom();
								string stringRep = "";
								var binaryId = dataReader.GetSqlBinary(0);
								var byteArray = binaryId.Value;
								Array.ForEach(byteArray, b => stringRep += b.ToString("X2"));
								nom.Id = stringRep;
								byteArray = dataReader.GetSqlBinary(1).Value;
								stringRep = "";
								Array.ForEach(byteArray, b => stringRep += b.ToString("X2"));
								nom.ParentId = stringRep;
								nom.Name = dataReader.GetString(2);
								nom.Code = dataReader.GetString(3);
								if (dataReader.IsDBNull(4))
								{
									nom.EdIzmId = null;
								}
								else
								{
									var EdIzmId = dataReader.GetSqlBinary(4);
									nom.EdIzm = edIzmDictionary[EdIzmId];
								}
								if (priceDictionary.ContainsKey(binaryId))
									nom.Price = priceDictionary[binaryId];
								else
									nom.Price = 0;
								writer.WriteLine(nom.ToString());
								writer.Flush();
							}
							writer.Close();
							dataReader.Close();
						}
						conn.Close();
					}
					catch (Exception e)
					{
						return;
					}

				}
			NomList = GetLocalNom();
		}

		public List<Nom> GetLocalNom()
		{
			try
			{
				var nomLines = File.ReadAllLines(fileInfo.FullName, Encoding.GetEncoding(1251));
				var nomList=new List<Nom>();
				foreach (var nomLine in nomLines)
					nomList.Add(Nom.Parse(nomLine));
				return nomList;
			}
			catch (Exception e)
			{
				return null;
			}

		}

		public int GetLocalNomCount()
		{
			try
			{
				int count = File.ReadAllLines(filename).Length;
				return count;
			}
			catch (IOException ioException)
			{
				return 0;
			}
		}

		public void LoadNomListToTreeView(TreeView treeView)
		{
			if (NomList == null)
				NomList = GetLocalNom();
			LoadNomListToTreeView(treeView,NomList);
		}

		public void LoadNomListToTreeView(TreeView treeView, List<Nom> nomList)
		{
			treeView.Nodes.Clear();
			TreeNode rootNode=treeView.Nodes.Add(nomList[0].Id, $"{nomList[0].Name} {nomList[0].Code} {nomList[0].Price:f2}");
			rootNode.Tag = nomList[0];
			for (int i = 1; i < nomList.Count; i++)
			{
				var pnode = FindParentNode(nomList[i], rootNode);
				TreeNode cnode = pnode.Nodes.Add(nomList[i].Id, $"{nomList[i].Name} {nomList[i].Code} {nomList[i].Price:f2}");
				cnode.Tag = nomList[i];
			}
		}

		private TreeNode FindParentNode(Nom nom, TreeNode rootNode)
		{
			if (rootNode.Name == nom.ParentId)
				return rootNode;
			if (rootNode.Nodes != null)
			{
				foreach (var node in rootNode.Nodes)
				{
					var child = FindParentNode(nom, (TreeNode) node);
					if (child != null)
						return child;
				}
			}
			return null;
		}
	}
}
