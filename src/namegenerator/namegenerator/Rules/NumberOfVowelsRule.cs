using System;
using System.Text.RegularExpressions;

namespace namegenerator.Rules
{
	public class NumberOfVowelsRule : IRule
	{
		private Regex wovels = new Regex ("[aeiouy]", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		int min;
		int max;

		public NumberOfVowelsRule (int min, int max)
		{
			this.max = max;
			this.min = min;
		}

		#region IRule implementation

		public bool Complies (string str)
		{
			int numberOfVowels = this.wovels.Matches (str).Count;

			return !(numberOfVowels < this.min || numberOfVowels > this.max);
		}

		public string Title {
			get {
				return String.Format ("Number of vowels between {0} and {1}", this.min, this.max);
			}
		}

		#endregion
	}
}

