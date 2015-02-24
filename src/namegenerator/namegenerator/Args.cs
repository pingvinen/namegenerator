using System;
using System.Collections.Generic;

namespace namegenerator
{
	public class Args
	{
		private IList<string> args;

		public Args (string[] args)
		{
			this.args = new List<string> (args);
		}

		public bool Contains(string value)
		{
			return this.args.Contains (value);
		}

		public void Print()
		{
			Console.WriteLine (String.Join (", ", this.args));
		}
	}
}

