using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostReq.Model
{
	public class FilterModel
	{
		public UnitOfWork UnitOfWork { get; set;}
		public DateTime DateFrom { get; set; }
		public DateTime DateTo { get; set; }
		public Post Post { get; set; }
		public List<State> States { get; set; }

		public FilterModel()
		{
			States = new List<State>();
		}
		
	}
}
