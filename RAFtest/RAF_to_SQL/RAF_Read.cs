using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using static RAFtest.datasets;

namespace RAFtest
{
	class RAF_Read
	{
		dataSwitches _switch = new dataSwitches();
		SqlConnection sql = new SqlConnection();
		dbConfig _db_config = new dbConfig();
		public List<vendors> rafRead(string path)
		{
			path = @"C:\INVEN\NVEND.DAT";
			vendors a_vendor = new vendors();
			List<vendors> returnData = new List<vendors>();
			List<string> data = new List<string>();
			List<int> fields = new List<int> { 6, 35, 24, 24, 30, 20, 4, 30, 45, 45, 20, 30, 45, 20, 30, 45, 20, 30, 45, 20 };
			using (FileStream _fs = File.Open(path, FileMode.Open))
			{
				byte[] b = new byte[574];
				int position = 0;
				UTF8Encoding t = new UTF8Encoding(true);
				while (_fs.Read(b, 0, b.Length) > 0)
				{
					int ii = 0;
					position = 0;
					a_vendor = new vendors();
					string xRaw = b[0].ToString();
					string x = t.GetString(b.Skip(4).ToArray().Take(570).ToArray());

					a_vendor.id = int.Parse(xRaw);
					for (int i = 0; i < 20; i++)
					{
						if (i == 20)
						{
							a_vendor = _switch.vendorSwitch(ii + 1, x.Substring(position, (x.Length - position)).Trim(), a_vendor);
							//	values.Add(x.Substring(position, (x.Length - position)).Trim());
						}
						else
						{
							a_vendor = _switch.vendorSwitch(ii + 1, x.TrimStart().Substring(position, fields[i]).Trim(), a_vendor);
							//	values.Add(x.TrimStart().Substring(position, i).Trim());
						}
						position += fields[i];
						ii++;
					}

					returnData.Add(a_vendor);
				}
			}
			return returnData;
		}
	}
}
