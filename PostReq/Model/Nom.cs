using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PostReq.Model
{
	public class Nom
	{
		public string Id { get; set; }
		public string ParentId { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public Byte[] EdIzmId { get; set; }
		public string EdIzm { get; set; }
		public double Price { get; set; }

		public override string ToString()
		{
			string stringRep = "";
			stringRep += Id;
			stringRep += "$";
			stringRep += ParentId;
			stringRep += "$";
			stringRep += Name;
			stringRep += "$";
			stringRep += Code;
			stringRep += "$";
			if (EdIzm == null)
				stringRep += "null";
			else
				stringRep+=EdIzm;
			stringRep += "$";
			stringRep += Price.ToString("F2", CultureInfo.InvariantCulture);
			stringRep = stringRep.Replace("\n", "");
			return stringRep;
		}

		public static Nom Parse(string s)
		{
			var nom = new Nom();
			var split = s.Split('$');
			nom.Id = split[0];
			nom.ParentId= split[1];
			nom.Name = split[2];
			nom.Code = split[3];
			if (split[4] == "null")
				nom.EdIzm = null;
			else
				nom.EdIzm = split[4];
			double d = 0;
			if (double.TryParse(split[5], NumberStyles.Any,CultureInfo.InvariantCulture,out d))
				nom.Price = d;
			else
				nom.Price = 0.0;
			return nom;
		}
	}
}
