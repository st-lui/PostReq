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
	public class StatesRepository : IRepository<State>
	{
		private ReqDataContext db;

		public StatesRepository(ReqDataContext db)
		{
			this.db = db;
		}

		public IEnumerable<State> GetAll()
		{
			return db.States;
		}

		public void Add(State item)
		{
			db.States.InsertOnSubmit(item);
		}

		public void Change(State item)
		{

		}

		public void Delete(State item)
		{
			db.States.DeleteOnSubmit(item);
		}

		public State Get(int id)
		{
			return db.States.SingleOrDefault(x => x.Id == id);
		}

		public State Get(string name)
		{
			return db.States.SingleOrDefault(x => x.Name== name);
		}
	}

	public class UsersRepository : IRepository<User>
	{
		private ReqDataContext db;

		public UsersRepository(ReqDataContext db)
		{
			this.db = db;
		}

		public IEnumerable<User> GetAll()
		{
			return db.Users;
		}

		public void Add(User item)
		{
			db.Users.InsertOnSubmit(item);
		}

		public void Change(User item)
		{

		}

		public void Delete(User item)
		{
			db.Users.DeleteOnSubmit(item);
		}

		public User Get(int id)
		{
			return db.Users.SingleOrDefault(x => x.Id == id);
		}

		public User Get(string name)
		{
			return db.Users.SingleOrDefault(x => x.UserName == name);
		}
	}

	public class PostsRepository : IRepository<Post>
	{
		private ReqDataContext db;

		public PostsRepository(ReqDataContext db)
		{
			this.db = db;
		}

		public IEnumerable<Post> GetAll()
		{
			return db.Posts;
		}

		public void Add(Post item)
		{
			db.Posts.InsertOnSubmit(item);
		}

		public void Change(Post item)
		{

		}

		public void Delete(Post item)
		{
			db.Posts.DeleteOnSubmit(item);
		}

		public Post Get(int id)
		{
			return db.Posts.SingleOrDefault(x => x.Id == id);
		}

		public Post Get(string name)
		{
			if (name.ToLower().Contains("ауф"))
				return db.Posts.SingleOrDefault(x => x.Name.Contains("УФПС"));
			string postName = name.Split('.')[1].Trim();

			return db.Posts.SingleOrDefault(x => x.Name == postName);
		}
	}
}
