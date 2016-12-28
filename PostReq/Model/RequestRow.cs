using System;
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
		EntityRef<Request> request;
		private string code;
		private double price;
		private double factAmount;

		public RequestRow()
		{
		}

		public RequestRow(RequestRow o)
		{
			amount = o.amount;
			name = o.name;
			edIzm = o.edIzm;
			goodsId = o.goodsId;
			code = o.code;
			price = o.price;
		}

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

		[Column(Name="amount",DbType = "decimal(10,3)", CanBeNull = false)]
		public double Amount
		{
			get { return amount; }
			set
			{
				amount = value;
				Change("Amount");
			}
		}

		[Column(Name = "name", DbType = "VARCHAR(256)", CanBeNull = false)]
		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				Change("Name");
			}
		}

		[Column(Name = "ed_izm", DbType = "VARCHAR(32)", CanBeNull = false)]
		public string EdIzm
		{
			get { return edIzm; }
			set
			{
				edIzm = value;
				Change("EdIzm");
			}
		}

		[Column(Name = "goods_id", DbType = "VARCHAR(32)", CanBeNull = false)]
		public string GoodsId
		{
			get { return goodsId; }
			set
			{
				goodsId = value;
				Change("GoodsId");
			}
		}

		[Column(Name = "request_id", DbType = "int", CanBeNull = false)]
		public int RequestId
		{
			get { return requestId; }
			set
			{
				requestId = value;
				Change("RequestId");
			}
		}

		[Column(Name = "price", DbType = "decimal(10,2)", CanBeNull = false)]
		public double Price
		{
			get { return price; }
			set
			{
				price= value;
				Change("Price");
			}
		}

		[Association(Storage = "request", IsForeignKey = true, ThisKey = "RequestId", OtherKey = "Id",DeleteOnNull = false)]
		public Request Request
		{
			get { return request.Entity; }
			set { request.Entity = value; Change("Request"); }
		}

		public string StringRep
		{
			get { return $"{Name} {Amount:f3} {EdIzm}"; }
		}
		[DisplayName("Количество")]
		public string AmountString
		{
			get { return $"{Amount:f3} {EdIzm}"; }
		}

		[DisplayName("Стоимость")]
		public double Cost
		{
			get { return Amount*Price; }
		}

		[Column(Name = "code",DbType = "varchar(30)")]
		public string Code
		{
			get { return code; }
			set { code = value; Change("Code");}
		}

		[Column(Name="fact_amount",DbType="decimal(10,3)")]
		[DisplayName("Факт")]
		public double FactAmount
		{
			get { return factAmount; }
			set { factAmount = value; Change("FactAmount"); }
		}

		[DisplayName("Процент")]
		public double Percent
		{
			get
			{
				if (Amount == 0)
					return 0;
				else
					return Math.Round(FactAmount/Amount*100,2);
			}
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
