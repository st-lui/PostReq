using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace PostReq.Model
{
	[Table(Name = "states")]
	[Serializable]
	public class State
	{
		[Column(Name = "id", DbType = "int IDENTITY (1,1)", IsPrimaryKey = true,IsDbGenerated = true,AutoSync = AutoSync.OnInsert)]
		public int Id { get; set; }
		[Column(Name = "name", DbType = "varchar(32)")]
		public string Name { get; set; }
	}
}
