using System;
using MySql.Data.MySqlClient;
using daslib;

namespace namegenerator
{
	public class DbStorage : IStorage
	{
		protected MySqlConnection db;

		public DbStorage ()
		{
		}

		public virtual void Init()
		{
			this.db = (new MySqlConnectionFactory ()).GetConnection ();
			this.db.Open ();
		}

		public virtual void Clear()
		{
			var cmd = this.db.CreateCommand ();
			cmd.CommandText = String.Format ("truncate `names`");

			cmd.ExecuteNonQuery ();
		}

		public virtual void Save (string name)
		{
			var cmd = this.db.CreateCommand ();
			cmd.CommandText = String.Format ("replace into `names` set `name`=@name, `length`=@length");
			cmd.Parameters.AddWithValue ("@name", name);
			cmd.Parameters.AddWithValue ("@length", name.Length);

			cmd.ExecuteNonQuery ();
		}

		public virtual void Done ()
		{
			// nothing to do
		}
	}
}

