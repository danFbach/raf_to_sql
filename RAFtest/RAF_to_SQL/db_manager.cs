using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using static RAFtest.datasets;

namespace RAFtest
{
	
	class db_manager
	{
		public db_manager()
		{

		}
		SqlConnection sql_conn = new SqlConnection();
		dbConfig _db_config = new dbConfig();
		dataSwitches _switch = new dataSwitches();
		public void load_Into_SQL(List<vendors> vendors)
		{
			int added = 0;
			List<SqlCommand> sqlCommands = new List<SqlCommand>();
			SqlCommandBuilder scb = new SqlCommandBuilder();
			SqlDataAdapter sda;
			DataSet vendorDataSet = new DataSet();
			sql_conn.ConnectionString = _db_config.inven_general_conn;
			sql_conn.Open();
			sda = new SqlDataAdapter("select * from vendor", sql_conn);
			sda.Fill(vendorDataSet, "vendor");
			scb = new SqlCommandBuilder(sda);
			SqlCommand insert = scb.GetInsertCommand();
			SqlCommand holder = new SqlCommand();
			//Console.WriteLine("Delete Command" + Environment.NewLine + scb.GetDeleteCommand().CommandText + Environment.NewLine);
			//Console.WriteLine("Insert Command" + Environment.NewLine + scb.GetInsertCommand().CommandText + Environment.NewLine);
			//Console.WriteLine("Update command" + Environment.NewLine + scb.GetUpdateCommand().CommandText + Environment.NewLine);
			//sda.InsertCommand.CommandText = "";
			foreach (vendors _v in vendors)
			{
				holder = insert.Clone();
				foreach (SqlParameter param in holder.Parameters)
				{
					if (param.SourceColumn == "id")
					{
						param.Value = _v.id;
					}
					else
					{
						param.Value = _switch.vendorSqlSwitch(param.SourceColumn, _v);
					}
				}
				holder.Connection = sql_conn;
				holder.CommandType = System.Data.CommandType.Text;

				sqlCommands.Add(holder);
			}

			foreach (SqlCommand s in sqlCommands)
			{
				DataSet ds = new DataSet();
				SqlDataAdapter sda1 = new SqlDataAdapter("SELECT * FROM vendor WHERE id = " + s.Parameters[0].Value.ToString(), sql_conn);
				sda1.Fill(ds, "vendor");
				if (ds.Tables["vendor"].Rows.Count == 0)
				{
					s.ExecuteNonQuery();
					added++;
				}
			}
			sql_conn.Close();
			Console.WriteLine(added + " vendors added to database.");
			Console.ReadKey();
		}

		public void create_vendor(vendors vendor)
		{

		}

		public void update_vendor(/*vendors vendor*/)
		{
			SqlCommandBuilder scb = new SqlCommandBuilder();
			sample_data sampledata = new sample_data();
			vendors vendor = sampledata.get_sample_vendor();
			//select the vendor being used
			sql_conn.ConnectionString = _db_config.inven_general_conn;
			DataSet ds = new DataSet();
			sql_conn.Open();
			SqlDataAdapter sda1 = new SqlDataAdapter("SELECT TOP(1) * FROM vendor WHERE id = " + vendor.id, sql_conn);
			sda1.Fill(ds, "vendor");
			scb = new SqlCommandBuilder(sda1);
			//((System.Data.DataTable)(new System.Collections.ArrayList.ArrayListDebugView(ds.Tables.List).Items[0])).Columns.List
			if (ds.Tables["vendor"].Rows.Count == 1)
			{
				object[] drd = ds.Tables["vendor"].Rows[0].ItemArray;
				for(int i = 1; i <= drd.Count(); i++)
				{
					vendor = _switch.vendorSwitch(i, drd[i].ToString(), vendor);
				}
				SqlCommand update = scb.GetUpdateCommand(true);
				foreach (SqlParameter param in update.Parameters)
				{
					if (param.SourceColumn.ToString() == "id")
					{
						continue;
					}
					else
					{
						param.Value = _switch.vendorSqlSwitch(param.SourceColumn, vendor);
					}
				}
				update.ExecuteNonQuery();
			}
			sql_conn.Close();
		}

		public void delete_vendor(vendors vendor)
		{

		}

		public void query_vendor(vendors vendor)
		{

		}
	}
}
