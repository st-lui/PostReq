using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using PostReq.Model;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace PostReq.Controller
{
	public class RequestController
	{
		public static void GeneratePrintForm()
		{

		}

		public static string GeneratePrintForm(Request request, IEnumerable<RequestRow> requestRows)
		{
			string filename = null;
			using (MemoryStream ms = new MemoryStream())
			{
				HSSFWorkbook wb = new HSSFWorkbook();
				HSSFSheet sheet = new HSSFSheet(wb);
				int i = 0;
				var flo = wb.CreateCellStyle();
				var df = wb.CreateDataFormat();
				flo.DataFormat=df.GetFormat("#,###");
				foreach (RequestRow requestRow in requestRows)
				{
					var row=sheet.CreateRow(i+2);
					row.CreateCell(0).SetCellValue(i + 1);
					row.CreateCell(1).SetCellValue(requestRow.Name);
					row.CreateCell(2).SetCellValue(requestRow.Amount);
					row.Cells[1].CellStyle = flo;
					i++;
				}
				sheet.AutoSizeColumn(2);
				sheet.AutoSizeColumn(1);
				sheet.AutoSizeColumn(0);
				wb.Add(sheet);
				filename = Guid.NewGuid().ToString() + ".xls";
				using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
					wb.Write(fs);
				wb.Close();
			}
			return filename;
		}

		public static IEnumerable<Request> GetRequests(FilterModel filterModel)
		{
			var requests = filterModel.UnitOfWork.Requests.GetAll().ToList();
			return requests;
		}
	}
}
