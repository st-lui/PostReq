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
		private ReqDataContext db;
		private bool disposed = false;

		public UnitOfWork()
		{
			db = new ReqDataContext();
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
