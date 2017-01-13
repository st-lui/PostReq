using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using PostReq.Util;

namespace PostReq
{
	public partial class UpdateForm : Form
	{
		//Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None); // открываем конфигурационный файл рабочего приложения
		public UpdateForm()
		{
			InitializeComponent();
			ShowDialog();
		}

		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}
		//Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None); // открываем конфигурационный файл рабочего приложения

		public string UpdateLocation
		{
			get
			{
				string url = Cfg.Read(Key.UpdateUrl);
				if (Cfg.Read(Key.UpdateUrl) == String.Empty)
					url = "ftp://post:885544@10.56.0.150/pub/pfo/postreq_updates/";
				return url;
			}
		}
		string ver = "";
		public void Setup()
		{

			if (CheckUpdate(ref ver))
			{
				label1.Text = "Найдена новая [" + ver + "] версия!";
				Pause();
				DownloadUpdate();
			}
			else
			{
				label1.Text = "Ваша версия актуальна!";
				Pause();
				Dispose();
			}
		}

		public bool CheckUpdate(ref string info)
		{

			WebClient client = new WebClient();
			client.Proxy = null;
			client.DownloadFile(UpdateLocation + "update.ini", Application.StartupPath + "\\update.ini");
			String version = System.IO.File.ReadAllText(Application.StartupPath + "\\update.ini").Trim();
			info = version;
			return version.CompareTo(AssemblyVersion) != 0;
		}
		public void DownloadUpdate()
		{
			WebClient client = new WebClient();
			client.Proxy = null;
			client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
			client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
			client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
			progressBar1.Style = ProgressBarStyle.Continuous;
			client.DownloadFileAsync(new Uri(UpdateLocation + "update.exe"), Application.StartupPath + "\\update.exe");
		}

		void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			label1.Text = String.Format("Загрузка обновления [" + ver + "]: {0} из {1} байт", e.TotalBytesToReceive, e.TotalBytesToReceive);
			progressBar1.Value = e.ProgressPercentage;

		}
		public void InstallUpdate()
		{
			label1.Text = String.Format("Установка обновления [" + ver + "]...");
			progressBar1.Style = ProgressBarStyle.Marquee;
			Pause();
			System.Diagnostics.ProcessStartInfo ps = new System.Diagnostics.ProcessStartInfo(Application.StartupPath + "\\update.exe");
			ps.UseShellExecute = true;
			ps.WindowStyle = ProcessWindowStyle.Hidden;
			ps.CreateNoWindow = true;
			Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
			Process p = Process.Start(ps);
			p.PriorityClass = ProcessPriorityClass.Idle;
			System.Environment.Exit(0);
		}
		void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			Pause();
			InstallUpdate();

		}
		public void Pause()
		{
			Application.DoEvents();
			Thread.Sleep(TimeSpan.FromSeconds(1));
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			Show();
			label1.Text = "Проверка новой версии...";
			progressBar1.Style = ProgressBarStyle.Marquee;
			Pause();
			Setup();
		}
	}
}