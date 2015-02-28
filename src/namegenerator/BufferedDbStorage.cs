using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Text;

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

			if (this.buffer.Count == 10000)
			{
				this.WriteToDb ();
			}
		}

		public override void Done()
		{
			if (this.buffer.Count > 0)
			{
				this.WriteToDb ();
			}
		}

		private void WriteToDb()
		{
			var sb = new StringBuilder();
			sb.Append("replace into `names` (`name`, `length`) values ");

			foreach (string name in this.buffer)
			{
				sb.AppendFormat("('{0}', {1}),", name, name.Length);
			}

			MySqlCommand cmd = this.db.CreateCommand ();
			cmd.CommandText = sb.ToString().Substring(0, sb.Length - 1);

			cmd.ExecuteNonQuery ();

			this.buffer.Clear();
		}
	}
}

