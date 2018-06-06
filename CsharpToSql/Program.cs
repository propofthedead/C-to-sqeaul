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
		static List<User> users = new List<User>();
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
				int? id = reader.GetInt32(reader.GetOrdinal("Id"));
				string username = reader.GetString(reader.GetOrdinal("Username"));
				string password = reader.GetString(reader.GetOrdinal("Password"));
				string first = reader.GetString(reader.GetOrdinal("Firstname"));
				string last = reader.GetString(reader.GetOrdinal("Lastname"));
				string phone = reader.GetString(reader.GetOrdinal("phone"));
				string email = reader.GetString(reader.GetOrdinal("email"));
				bool reviewer = reader.GetBoolean(reader.GetOrdinal("IsReviewer"));
				bool admin = reader.GetBoolean(reader.GetOrdinal("IsAdmin"));
				bool active = reader.GetBoolean(reader.GetOrdinal("Active"));
				User user = new User();
				user.Id = id;
				user.Username = username;
				user.Password = password;
				user.Firstname = first;
				user.Lastname = last;
				user.Phone = phone;
				user.Email = email;
				user.IsReviewer = reviewer;
				user.IsAdmin = admin;
				user.Active = active;
				users.Add(user);
				System.Diagnostics.Debug.WriteLine($"{id},{username},{password},{first},{last},{phone},{email},{reviewer},{admin},{active}");
			}

			conn.Close();
		}
	}
}
