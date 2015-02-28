using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace daslib
{
	public class NameRepository
	{
		private readonly MySqlConnectionFactory dbFactory;

		public NameRepository (MySqlConnectionFactory dbFactory)
		{
			this.dbFactory = dbFactory;
		}

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

		public int CountNames()
		{
			var cmd = this.GetCommand ();
			cmd.CommandText = "select count(*) from `names`";

			var reader = cmd.ExecuteReader (System.Data.CommandBehavior.SingleRow);

			if (reader.Read())
			{
				return reader.GetInt32 (0);
			}

			return 0;
		}

		public IList<NameEntry> GetList(int offset, int limit)
		{
			IList<NameEntry> list = new List<NameEntry>();

			var cmd = this.GetCommand ();
			cmd.CommandText = "select * from `names` order by `id` limit @offset, @limit";
			cmd.Parameters.AddWithValue ("@offset", offset);
			cmd.Parameters.AddWithValue ("@limit", limit);

			var reader = cmd.ExecuteReader (System.Data.CommandBehavior.CloseConnection);

			while (reader.Read())
			{
				list.Add (this.Populate (reader));
			}

			return list;
		}

		private NameEntry Populate(MySqlDataReader reader)
		{
			var res = new NameEntry ();

			res.Id = reader.GetInt32 ("id");
			res.Name = reader.GetString ("name");
			res.Length = reader.GetInt32 ("length");

			return res;
		}
	}
}

