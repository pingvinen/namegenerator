using System;
using System.Text.RegularExpressions;

namespace daslib.Rules
{
	public class EndsOnTwoConsonantsRule : IRule
	{
		private Regex regex = new Regex("[bcdfghjklmnpqrstvwxz]{2,}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		#region IRule implementation

		public bool Complies (string str)
		{
			return !regex.IsMatch (str);
		}

		public string Title {
			get {
				return "Ends on two consonants";
			}
		}

		#endregion
	}
}

