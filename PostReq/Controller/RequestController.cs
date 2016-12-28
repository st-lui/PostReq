﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using PostReq.Model;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;

namespace PostReq.Controller
{
	public class RequestController
	{
		public static void GeneratePrintForm()
		{

		}

		public static string GeneratePrintForm(Request request, List<RequestRow> requestRows)
		{
			if (!Directory.Exists("files"))
				Directory.CreateDirectory("files");
			string filename = null;
			string templateFilename = "template.xls";

			if (File.Exists(templateFilename))
			{
				using (Stream templateStream = new FileStream(templateFilename, FileMode.Open))
				{
					HSSFWorkbook wb = new HSSFWorkbook(templateStream);
					HSSFSheet sheet = (HSSFSheet)wb.GetSheetAt(0);
					int firstRowNum = sheet.FirstRowNum;
					if (request == null)
					{
						sheet.GetRow(firstRowNum + 10).Cells[0].SetCellValue("Почтамт");
						sheet.GetRow(firstRowNum + 11).Cells[0].SetCellValue("Заявка №");
						sheet.GetRow(firstRowNum + 12).Cells[0].SetCellValue($"Дата составления: {DateTime.Today:dd.MM.yyyy} г.");
					}
					else
					{
						sheet.GetRow(firstRowNum + 10).Cells[0].SetCellValue(request.User.Post.Name);
						sheet.GetRow(firstRowNum + 11).Cells[0].SetCellValue("Заявка №"+(request.Id==0?"":request.Id.ToString()));
						sheet.GetRow(firstRowNum + 12).Cells[0].SetCellValue($"Дата составления: {request.Date:dd.MM.yyyy} г.");
					}
					if (requestRows.Count() > 0)
					{
						var row = sheet.GetRow(firstRowNum + 13);
						row.Cells[0].SetCellValue(1);
						row.Cells[1].SetCellValue(requestRows[0].Code);
						row.Cells[4].SetCellValue(requestRows[0].Name);
						row.Cells[8].SetCellValue(requestRows[0].Amount);
						row.Cells[9].SetCellValue(requestRows[0].Price);
					}
					for (int i = 1; i < requestRows.Count; i++)
					{
						var row = sheet.CopyRow(firstRowNum+13,firstRowNum+13+i);
						row.Cells[0].SetCellValue(i + 1);
						row.Cells[1].SetCellValue(requestRows[i].Code);
						row.Cells[4].SetCellValue(requestRows[i].Name);
						row.Cells[8].SetCellValue(requestRows[i].Amount);
						row.Cells[9].SetCellValue(requestRows[i].Price);
					}
					//for (int i = 0; i < 11; i++)
					//{
					//	sheet.AutoSizeColumn(i);
					//}
					filename = $"files\\{Guid.NewGuid().ToString()}.xls";
					using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
						wb.Write(fs);
					wb.Close();
				}
			}
			return filename;
		}

		public static void SendEmail()
		{
			SmtpClient smtpClient = new SmtpClient();
			
		}

		public static IEnumerable<Request> GetRequests(FilterModel filterModel)
		{
			var requests = filterModel.UnitOfWork.Requests.GetAll().ToList();
			return requests;
		}
	}
}
