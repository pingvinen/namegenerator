using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace namegenerator
{
	public class BufferedDbStorage : DbStorage
	{
		protected IList<string> buffer;

		public BufferedDbStorage ()
		{
		}

		public override void Init ()
		{
			this.buffer = new List<string> ();
			base.Init ();
		}

		public override void Save(string name)
		{
			this.buffer.Add (name);

			if (this.buffer.Count == 1000)
			{
				this.WriteToDb ();
			}
		}

		public override void Done()
		{
			this.WriteToDb ();
		}

		private void WriteToDb()
		{
			var transaction = this.db.BeginTransaction ();

			try
			{
				MySqlCommand cmd;

				foreach (string name in this.buffer)
				{
					cmd = this.db.CreateCommand ();
					cmd.CommandText = String.Format ("replace into `names` set `name`=@name, `length`=@length");
					cmd.Parameters.AddWithValue ("@name", name);
					cmd.Parameters.AddWithValue ("@length", name.Length);

					cmd.ExecuteNonQuery ();
				}

				transaction.Commit();
				this.buffer.Clear();
			}

			catch (Exception)
			{
				transaction.Rollback ();
			}
		}
	}
}

