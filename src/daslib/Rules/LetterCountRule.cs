using System;
using System.Text.RegularExpressions;

namespace daslib.Rules
{
	public class LetterCountRule : IRule
	{
		private Regex regex;
		string letter;
		int max;

		public LetterCountRule (string letter, int max)
		{
			this.max = max;
			this.letter = letter;
			this.regex = new Regex (letter, RegexOptions.Compiled | RegexOptions.IgnoreCase);
		}

		#region IRule implementation

		public bool Complies (string str)
		{
			return this.regex.Matches (str).Count <= this.max;
		}

		public string Title {
			get {
				return String.Format ("Number of {0} a maximum of {1} times", this.letter, this.max);
			}
		}

		#endregion
	}
}

