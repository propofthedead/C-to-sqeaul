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
			System.Diagnostics.Debug.WriteLine("Connection Opened");
		}
	}
}
