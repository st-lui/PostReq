﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using PostReq.Model;

namespace PostReq.Controller
{
	public class RequestController
	{
		public static void GeneratePrintForm()
		{
			
		}

		public static string GeneratePrintForm(Request request, IEnumerable<RequestRow> requestRows)
		{
			throw new NotImplementedException();
		}

		public static IEnumerable<Request> GetRequests(FilterModel filterModel)
		{
			UnitOfWork uof=new UnitOfWork();
			var requests = uof.Requests.GetAll().ToList();
			uof.Dispose();
			return requests;
		}
	}
}
