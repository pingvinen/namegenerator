using System;
using MySql.Data.MySqlClient;

namespace namegenerator
{
	public class ConfiguredMySqlConnection : MySqlConnection
	{
		public ConfiguredMySqlConnection () : base("Server=127.0.0.1;Uid=namegen;Pwd=123456;Database=ada;")
		{
		}
	}
}

