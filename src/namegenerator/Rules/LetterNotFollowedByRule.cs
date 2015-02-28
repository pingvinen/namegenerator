using System;
using System.Text.RegularExpressions;

namespace namegenerator
{
	public class LetterNotFollowedByRule : IRule
	{
		private Regex regex;

		private string letter;
		private string notAllowedToFollow;

		public LetterNotFollowedByRule (string letter, string notAllowedToFollow)
		{
			this.notAllowedToFollow = notAllowedToFollow;
			this.letter = letter;

			this.regex = new Regex (String.Format("{0}[{1}]", this.letter, this.notAllowedToFollow), RegexOptions.Compiled | RegexOptions.IgnoreCase);
		}

		#region IRule implementation

		public bool Complies (string str)
		{
			return !this.regex.IsMatch (str);
		}

		public string Title {
			get {
				return String.Format ("{0} not followed by {1}", this.letter, this.notAllowedToFollow);
			}
		}

		#endregion
	}
}

