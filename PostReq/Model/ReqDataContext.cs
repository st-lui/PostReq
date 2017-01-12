using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using PostReq.Util;

namespace PostReq.Model
{
	public class ReqDataContext:DataContext
	{
		private static ReqDataContext db;
		public Table<Request> Requests;
		public Table<RequestRow> RequestRows;
		public Table<State> States;
		public Table<User> Users;
		public Table<Post> Posts;

		public ReqDataContext():base(Cfg.Read(SettingsKey.connection))
		{
		}

		public ReqDataContext(string connectionString) : base(connectionString)
		{
		}

		public static ReqDataContext GetInstance()
		{
			if (db == null)
			{
				db = new ReqDataContext();
				
				//db.LoadOptions.AssociateWith<Request>(r => r.State);
				db.DeferredLoadingEnabled = false;
				db.ObjectTrackingEnabled = true;
				db.LoadOptions.LoadWith<Request>(r => r.State);
			}
			return db;
		}
	}
}
