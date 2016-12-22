using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostReq.Model
{
	public interface IRepository<T> where T :class
	{
		IEnumerable<T> GetAll();
		void Add(T item);
		void Change(T item);
		void Delete(T item);
		T Get(int id);
	}

	public class RequestRepository : IRepository<Request>
	{
		private ReqDataContext db;

		public RequestRepository(ReqDataContext db)
		{
			this.db = db;
		}

		public IEnumerable<Request> GetAll()
		{
			return db.Requests;
		}

		public void Add(Request item)
		{
			db.Requests.InsertOnSubmit(item);
		}

		public void Change(Request item)
		{
			
		}

		public void Delete(Request item)
		{
			db.Requests.DeleteOnSubmit(item);
		}

		public Request Get(int id)
		{
			return db.Requests.SingleOrDefault(x => x.Id == id);
		}
	}

	public class RequestRowRepository : IRepository<RequestRow>
	{
		private ReqDataContext db;

		public RequestRowRepository(ReqDataContext db)
		{
			this.db = db;
		}

		public IEnumerable<RequestRow> GetAll()
		{
			return db.RequestRows;
		}

		public void Add(RequestRow item)
		{
			db.RequestRows.InsertOnSubmit(item);
		}

		public void Change(RequestRow item)
		{

		}

		public void Delete(RequestRow item)
		{
			db.RequestRows.DeleteOnSubmit(item);
		}

		public RequestRow Get(int id)
		{
			return db.RequestRows.SingleOrDefault(x => x.Id == id);
		}
	}
}
