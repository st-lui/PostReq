﻿using System;
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
		private int id;
		private DateTime date;
		private string username;
		private int stateId;
		
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

		[Column(Name = "date", DbType = "DateTime")]
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

		[Column(Name = "username", DbType = "VARCHAR(50)")]
		[DisplayName("Имя пользователя")]
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

		public string StateName
		{
			get { return State.Name; }
		}

		[Column(Name="state_id",DbType = "int")]
		public int StateId
		{
			get { return stateId; }
			set { stateId = value; }
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
