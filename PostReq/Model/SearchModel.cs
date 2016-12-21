using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostReq.Model
{
	public class SearchModel
	{
		public bool SearchResult { get; set; }
		public string SearchPattern { get; set; }
		public List<Nom> NomList { get; set; }
		public string PreviousResult { get; set; }
		public string CurrentResult { get; set; }
	}
}
