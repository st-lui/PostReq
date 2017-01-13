using System;
using System.Collections;
using System.Configuration;

namespace PostReq.Util
{
	/// <summary>
	/// перечисления, совпадают с названиями 
	/// ключей в конфигурационном файле
	/// </summary>
	public enum Key
	{
		DateFrom, DateTo, PostId, connection,
		UpdateUrl
	}

	public static class ConfigUtil
	{
		public static Hashtable ReadAll()
		{
			Hashtable lst = new Hashtable();
			lst.Clear();
			foreach (Key key in (Key[])Enum.GetValues(typeof(Key)))
				lst[key] = Cfg.Read(key);
			return lst;
		}
	}
	/// <summary>
	/// Простой класс для чтения/записи
	/// значений в конфигурационный файл
	/// </summary>
	public static class Cfg
	{

		/// <summary>
		/// проверка наличия exe.config
		/// </summary>
		/// <returns></returns>
		public static bool ExistConfig()
		{
			return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).HasFile;
		}
		public static string PathConfig()
		{
			return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
		}
		/// <summary>
		/// чтение произвольного ключа из .config
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static String ReadAny(string key)
		{
			Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			return cfg.AppSettings.Settings[key] == null ? String.Empty : cfg.AppSettings.Settings[key].Value;
		}
		/// <summary>
		/// чтение определенного ключа emun(Key) из .config
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static String Read(Key key)
		{
			return ReadAny(key.ToString());
		}
		/// <summary>
		/// запись произвольного ключа в .config
		/// </summary>
		/// <param name="key"></param>
		/// <param name="val"></param>
		public static void UpdateAny(string key, string val)
		{
			Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			if (cfg.AppSettings.Settings[key] == null)
				cfg.AppSettings.Settings.Add(key, val);
			else
				cfg.AppSettings.Settings[key].Value = val;
			cfg.Save();
		}
		/// <summary>
		/// запись определенного ключа emun(Key) в .config
		/// </summary>
		/// <param name="key"></param>
		/// <param name="val"></param>
		public static void Update(Key key, string val)
		{
			UpdateAny(key.ToString(), val);
		}
	}
}
