using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAFtest
{
	class Program
	{
		static void Main(string[] args)
		{
			db_manager dbm = new db_manager();
			Parse p = new Parse();
			RAF_Read r = new RAF_Read();
			//List<datasets.vendors> rawData =r.rafRead("path");
			//dbm.load_Into_SQL(rawData);
			dbm.update_vendor();

			//p.parser(rawData);
			
		}
	}
}
