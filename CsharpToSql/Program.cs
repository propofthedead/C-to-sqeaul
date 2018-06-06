using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpToSql
{
	class Program
	{
		static void Main(string[] args)
		{
			string connStr = @"server=DESKTOP-7KOO68T\SQLEXPRESS;database=prs;Trusted_connection=true";
			SqlConnection conn = new SqlConnection(connStr);
			conn.Open();
			if (conn.State != System.Data.ConnectionState.Open) {
				throw new ApplicationException("connection did not open");
			}
			string sql = "select * from [User]";
			SqlCommand cmd = new SqlCommand(sql, conn);
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read()) {
				System.Diagnostics.Debug.WriteLine("Read another row");
			}

			conn.Close();
		}
	}
}
