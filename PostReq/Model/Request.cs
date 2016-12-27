using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace PostReq.Model
{
	[Table(Name = "requests")]
	[Serializable]
	public class Request : INotifyPropertyChanged
	{
		private readonly EntitySet<RequestRow> requestRows = new EntitySet<RequestRow>();
		private EntityRef<State> state;
		private EntityRef<User> user;
		private int id;
		private DateTime date;
		private string username;
		private int stateId;
		private int userId;

		public Request()
		{
			date=DateTime.Today;
			username = $"{Environment.UserDomainName}\\{Environment.UserName}";
			requestRows =new EntitySet<RequestRow>();
		}

		public Request(Request o)
		{
			date = DateTime.Today;
			username = $"{Environment.UserDomainName}\\{Environment.UserName}";
			requestRows=new EntitySet<RequestRow>();
			foreach (var requestRow in o.requestRows)
			{
				requestRows.Add(new RequestRow(requestRow) {Request = this});
			}
		}

		[Column(Name = "id", IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, IsDbGenerated = true,DbType = "INT IDENTITY(1,1)")]
		[DisplayName("Номер заявки")]
		public int Id
		{
			get { return id; }
			set
			{
				id = value;
				Change("Id");
			}
		}

		[Column(Name = "date", DbType = "DateTime", CanBeNull = false)]
		[DisplayName("Дата заявки")]
		public DateTime Date
		{
			get { return date; }
			set
			{
				date = value;
				Change("Date");
			}
		}

		[Column(Name = "username", DbType = "VARCHAR(50)", CanBeNull = false)]
		[DisplayName("Автор")]
		public string Username
		{
			get { return username; }
			set
			{
				username= value;
				Change("Username");
			}
		}


		[Association(Storage = "requestRows", OtherKey = "RequestId", ThisKey = "Id")]
		public EntitySet<RequestRow> RequestRows
		{
			get { return requestRows; }
			set { requestRows.Assign(value); }
		}

		[Association(Storage = "state", OtherKey = "Id", ThisKey = "StateId",IsForeignKey = true)]
		public State State
		{
			get { return state.Entity; }
			set { state.Entity=value; }
		}

		[Column(Name="state_id",DbType = "int", CanBeNull = false)]
		public int StateId
		{
			get { return stateId; }
			set { stateId = value; Change("StateId");}
		}

		[Column(Name = "user_id", DbType = "int", CanBeNull = false)]
		public int UserId
		{
			get { return userId; }
			set { userId = value; Change("UserId"); }
		}

		[Association(Storage = "user",ThisKey = "UserId",OtherKey = "Id",IsForeignKey = true)]
		public User User
		{
			get { return user.Entity; }
			set { user.Entity=value; }
		}

		public event PropertyChangedEventHandler PropertyChanged;

		//public override string ToString()
		//{
		//	return string.Format("{0} {1} {2}", Family, Name, Father);
		//}

		private void Change(string prop)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}


	}
}
