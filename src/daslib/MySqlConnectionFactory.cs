using System;
using MySql.Data.MySqlClient;

namespace daslib
{
	public class MySqlConnectionFactory
	{
		public MySqlConnection GetConnection()
		{
			return new MySqlConnection ("Server=127.0.0.1;Uid=namegen;Pwd=123456;Database=ada;");
		}
	}
}

