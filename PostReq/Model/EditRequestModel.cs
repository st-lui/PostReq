using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostReq.Util;

namespace PostReq.Model
{
	public class EditRequestModel
	{
		public string FormText;
		public User CurrentUser;
		public Util.Utils.FormMode FormMode;
		public NomLoader NomLoader;
		public int EditId=0;
	}
}
