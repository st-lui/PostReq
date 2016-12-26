using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PostReq.Model
{
	[Table(Name = "posts")]
	[Serializable]
	public class Post : INotifyPropertyChanged
	{
		private int id;
		private int name;
		private EntitySet<User> users;
		private int privilegies;

		[Column(Name = "privilegies", DbType = "int",CanBeNull = false)]
		public int Privilegies
		{
			get { return privilegies; }
			set { privilegies = value; Change("Privilegies"); }
		}

		[Column(Name = "id", IsDbGenerated = true, IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, DbType = "int identity(1,1)")]
		public int Id
		{
			get { return id; }
			set { id = value; Change("Id"); }
		}
		[Column(Name = "name", DbType = "varchar(64)", CanBeNull = false)]
		public int Name
		{
			get { return name; }
			set { name = value; Change("Name"); }
		}
		[Association(Storage = "users", ThisKey = "Id", OtherKey = "PostId")]
		public EntitySet<User> Users
		{
			get { return users; }
			set { users.Assign(value); }
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void Change(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}