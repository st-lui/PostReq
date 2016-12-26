using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace PostReq.Model
{
	[Table(Name="users")]
	[Serializable]
	public class User:INotifyPropertyChanged
	{
		private int id;
		private string userName;
		private string fio;
		
		private int postId;
		private EntitySet<Request> requests=new EntitySet<Request>();
		private EntityRef<Post> post;

		

		public event PropertyChangedEventHandler PropertyChanged;

		[Column(Name="id",IsPrimaryKey = true,AutoSync = AutoSync.OnInsert,IsDbGenerated = true,DbType = "int identity(1,1)")]
		public int Id
		{
			get { return id; }
			set
			{
				id = value; 
				Change("Id");
			}
		}
		[Column(Name = "username",DbType = "varchar(64)", CanBeNull = false)]
		[DisplayName("Имя пользователя")]
		public string UserName
		{
			get { return userName; }
			set { userName = value; Change("UserName");}
		}
		[Column(Name = "fio",DbType = "varchar(64)", CanBeNull = false)]
		[DisplayName("Сотрудник")]
		public string Fio
		{
			get { return fio; }
			set { fio = value; Change("Fio"); }
		}
		[Column(Name="post_id",DbType = "int", CanBeNull = false)]
		public int PostId
		{
			get { return postId; }
			set { postId = value; Change("PostId"); }
		}

		[Association(Storage= "requests",ThisKey = "Id",OtherKey = "UserId")]
		public EntitySet<Request> Requests
		{
			get { return requests; }
			set { requests.Assign(value); }
		}
		[Association(Storage = "post", ThisKey = "PostId", OtherKey = "Id",IsForeignKey = true)]
		public Post Post
		{
			get { return post.Entity; }
			set { post.Entity=value; }
		}

		private void Change(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
