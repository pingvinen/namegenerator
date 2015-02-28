using System;
using System.Text.RegularExpressions;

namespace daslib.Rules
{
	public class DoubleVowelsRule : IRule
	{
		private Regex regex = new Regex("([aeiouy])\\1", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		#region IRule implementation

		public bool Complies (string str)
		{
			return !regex.IsMatch (str);
		}

		public string Title {
			get {
				return "No double vowels";
			}
		}

		#endregion
	}
}

