using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace PostReq.Model
{
	public class ReqDataContext:DataContext
	{
		private static ReqDataContext db;
		public Table<Request> Requests;
		public Table<RequestRow> RequestRows;
		public Table<State> States;

		public ReqDataContext():base(ConfigurationManager.AppSettings["connection"])
		{
		}

		public ReqDataContext(string connectionString) : base(connectionString)
		{
		}

		public static ReqDataContext GetInstance()
		{
			if (db == null)
				db=new ReqDataContext();
			return db;
		}
	}
}
