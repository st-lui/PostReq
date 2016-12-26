using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Net.Configuration;
using System.Text;

namespace PostReq.Model
{
	public class UnitOfWork : IDisposable
	{
		private RequestRepository requestRepository;
		private RequestRowRepository requestRowRepository;
		private StatesRepository stateRepository;
		private UsersRepository userRepository;
		private PostsRepository postRepository;
		private ReqDataContext db;
		private bool disposed = false;

		public UnitOfWork()
		{
			db = new ReqDataContext();
			if (db.DatabaseExists())
				db.DeleteDatabase();
			db.CreateDatabase();
			initializeDb();
		}

		private void initializeDb()
		{
			if (db == null)
				return;
			States.Add(new State() { Name = "Сохранена" });
			States.Add(new State() { Name = "Отправлена" });
			States.Add(new State() { Name = "Загружены данные" });
			Posts.Add(new Post() { Name = "УФПС Алтайского края", Privilegies = 1});
			Posts.Add(new Post() { Name = "Барнаульский почтамт", Privilegies = 1});
			SaveChanges();
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
					requestRepository = new RequestRepository(db);
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
				if (stateRepository == null)
					stateRepository = new StatesRepository(db);
				return stateRepository;
			}
		}

		public UsersRepository Users
		{
			get
			{
				if (userRepository == null)
					userRepository = new UsersRepository(db);
				return userRepository;
			}
		}

		public PostsRepository Posts
		{
			get
			{
				if (postRepository == null)
					postRepository = new PostsRepository(db);
				return postRepository;
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
