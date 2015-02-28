using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace daslib
{
	public class NameRepository
	{
		private readonly MySqlConnectionFactory dbFactory;
		private readonly ValidatorFactory validatorFactory;

		public NameRepository (MySqlConnectionFactory dbFactory, ValidatorFactory validatorFactory)
		{
			this.validatorFactory = validatorFactory;
			this.dbFactory = dbFactory;
		}

		#region Db helpers
		private MySqlConnection GetOpenConnection()
		{
			var db = this.dbFactory.GetConnection ();
			db.Open ();

			return db;
		}

		private MySqlCommand GetCommand()
		{
			return this.GetOpenConnection ().CreateCommand ();
		}
		#endregion

		#region Get
		public NameEntry Get(string name)
		{
			var cmd = this.GetCommand ();
			MySqlDataReader reader = null;
			try
			{
				cmd.CommandText = "select * from `names` where `name`=@name";
				cmd.Parameters.AddWithValue("@name", name);

				reader = cmd.ExecuteReader (System.Data.CommandBehavior.SingleRow);

				if (reader.Read())
				{
					return this.Populate(reader);
				}

				return default(NameEntry);
			}
			finally
			{
				if (reader != default(MySqlDataReader))
				{
					reader.Close ();
				}
				cmd.Connection.Close ();
			}
		}
		#endregion

		#region Count
		public int CountNames()
		{
			var cmd = this.GetCommand ();
			MySqlDataReader reader = null;
			try
			{
				cmd.CommandText = "select count(*) from `names`";

				reader = cmd.ExecuteReader (System.Data.CommandBehavior.SingleRow);

				if (reader.Read())
				{
					return reader.GetInt32 (0);
				}

				return 0;
			}
			finally
			{
				if (reader != default(MySqlDataReader))
				{
					reader.Close ();
				}
				cmd.Connection.Close ();
			}
		}
		#endregion

		#region Get list
		public IList<NameEntry> GetList(int offset, int limit)
		{
			IList<NameEntry> list = new List<NameEntry>();

			var cmd = this.GetCommand ();
			MySqlDataReader reader = null;
			try
			{
				cmd.CommandText = "select * from `names` order by `id` limit @offset, @limit";
				cmd.Parameters.AddWithValue ("@offset", offset);
				cmd.Parameters.AddWithValue ("@limit", limit);

				reader = cmd.ExecuteReader ();

				while (reader.Read())
				{
					list.Add (this.Populate (reader));
				}

				return list;
			}
			finally
			{
				if (reader != default(MySqlDataReader))
				{
					reader.Close ();
				}
				cmd.Connection.Close ();
			}
		}
		#endregion

		#region Populate
		private NameEntry Populate(MySqlDataReader reader)
		{
			var res = new NameEntry ();

			res.Id = reader.GetInt32 ("id");
			res.Name = reader.GetString ("name");
			res.Length = reader.GetInt32 ("length");
			res.IsValid = this.validatorFactory.Get (res.Length).IsValid(res.Name);

			return res;
		}
		#endregion
	}
}

