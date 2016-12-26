using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;

namespace PostReq.Model
{
	public class UnitOfWork:IDisposable
	{
		private RequestRepository requestRepository;
		private RequestRowRepository requestRowRepository;
		private StatesRepository stateRepository;
		private ReqDataContext db;
		private bool disposed = false;

		public UnitOfWork()
		{
			db = new ReqDataContext();
			db.DeleteDatabase();
			db.CreateDatabase();
		}

		public UnitOfWork(string connectionString)
		{
			db = new ReqDataContext(connectionString);
		}

		public RequestRepository Requests
		{
			get
			{
				if (requestRepository == null)
					requestRepository=new RequestRepository(db);
				return requestRepository;
			}
		}

		public RequestRowRepository RequestRows
		{
			get
			{
				if (requestRowRepository == null)
					requestRowRepository = new RequestRowRepository(db);
				return requestRowRepository;
			}
		}

		public StatesRepository States
		{
			get
			{
				if (stateRepository==null)
					stateRepository=new StatesRepository(db);
				return stateRepository;
			}
		}

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					db.Dispose();
				}
				this.disposed = true;
			}
		}

		public void SaveChanges()
		{
			db.SubmitChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
