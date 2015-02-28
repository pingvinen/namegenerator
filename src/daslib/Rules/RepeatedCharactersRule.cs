using System;
using System.Text.RegularExpressions;

namespace daslib.Rules
{
	public class RepeatedCharactersRule : IRule
	{
		private Regex repeatedChars;

		private int repetition;

		public RepeatedCharactersRule(int repeated)
		{
			this.repetition = repeated;

			// any characters repeated X or more times in a row
			this.repeatedChars = new Regex ("([a-z])\\1{"+(repeated-1)+"}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		}

		#region IRule implementation
		public bool Complies (string str)
		{
			return !this.repeatedChars.IsMatch (str);
		}
		public string Title {
			get {
				return String.Format("{0} repeated characters", this.repetition);
			}
		}
		#endregion
	}
}

