﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace PostReq.Model
{
	[Table(Name = "request_rows")]
	public class RequestRow : INotifyPropertyChanged
	{
		private int id;
		private double amount;
		private string name;
		private string edIzm;
		private string goodsId;
		private int requestId;

		[Column(Name = "id", IsPrimaryKey = true, AutoSync = AutoSync.OnInsert, IsDbGenerated = true, DbType = "INT IDENTITY(1,1)")]
		public int Id
		{
			get { return id; }
			set
			{
				id = value;
				Change("Id");
			}
		}

		[Column(Name="amount",DbType = "decimal(10,3)")]
		public double Amount
		{
			get { return amount; }
			set
			{
				amount = value;
				Change("Amount");
			}
		}

		[Column(Name = "name", DbType = "VARCHAR(256)")]
		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				Change("Name");
			}
		}

		[Column(Name = "ed_izm", DbType = "VARCHAR(32)")]
		public string EdIzm
		{
			get { return edIzm; }
			set
			{
				edIzm = value;
				Change("EdIzm");
			}
		}

		[Column(Name = "goods_id", DbType = "VARCHAR(32)")]
		public string GoodsId
		{
			get { return goodsId; }
			set
			{
				goodsId = value;
				Change("GoodsId");
			}
		}

		[Column(Name = "request_id", DbType = "int")]
		public int RequestId
		{
			get { return requestId; }
			set
			{
				requestId = value;
				Change("RequestId");
			}
		}

		public string StringRep
		{
			get { return $"{Name} {Amount:f3} {EdIzm}"; }
		}

		public string AmountString
		{
			get { return $"{Amount:f3} {EdIzm}"; }
		}

		public override string ToString()
		{
			return StringRep;

		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void Change(string prop)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));

		}
	}
}
