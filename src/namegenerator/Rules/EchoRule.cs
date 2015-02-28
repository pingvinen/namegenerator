using System;
using System.Text.RegularExpressions;

namespace namegenerator
{
	public class EchoRule : IRule
	{
		private Regex regex = new Regex("([a-z]{2})\\1", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		#region IRule implementation

		public bool Complies (string str)
		{
			return !this.regex.IsMatch (str);
		}

		public string Title {
			get {
				return "No echo rule";
			}
		}

		#endregion
	}
}

