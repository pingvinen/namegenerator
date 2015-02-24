using System;
using MySql.Data.MySqlClient;

namespace namegenerator
{
	public class DbStorage : IStorage
	{
		private MySqlConnection db;

		public DbStorage ()
		{
		}

		public void Init()
		{
			this.db = new MySqlConnection ("Server=127.0.0.1;Uid=root;Pwd=mrkuhupa;Database=ada;");
			this.db.Open ();
		}

		public void Clear()
		{
			var cmd = this.db.CreateCommand ();
			cmd.CommandText = String.Format ("truncate `names`");

			cmd.ExecuteNonQuery ();
		}

		#region IStorage implementation

		public void Save (string name)
		{
			var cmd = this.db.CreateCommand ();
			cmd.CommandText = String.Format ("replace into `names` set `name`=@name, `length`=@length");
			cmd.Parameters.AddWithValue ("@name", name);
			cmd.Parameters.AddWithValue ("@length", name.Length);

			cmd.ExecuteNonQuery ();
		}

		#endregion
	}
}

