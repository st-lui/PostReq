using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PostReq.Util;

namespace PostReq
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			new UpdateForm();
			Application.Run(new MainForm());
		}
	}
}
