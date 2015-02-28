using System;
using System.Text.RegularExpressions;

namespace daslib.Rules
{
	public class RegexRule : IRule
	{
		private Regex regex;
		private Regex regexCondition;

		string pattern;
		string conditionedOn;

		public RegexRule (string pattern) : this(pattern, null)
		{
		}

		public RegexRule (string pattern, string conditionedOn)
		{
			this.pattern = pattern;
			this.conditionedOn = conditionedOn;

			this.regex = new Regex (pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

			if (!String.IsNullOrEmpty(conditionedOn))
			{
				this.regexCondition = new Regex (conditionedOn, RegexOptions.Compiled | RegexOptions.IgnoreCase);
			}
		}

		#region IRule implementation

		public bool Complies (string str)
		{
			if (this.regexCondition != null && !this.regexCondition.IsMatch(str))
			{
				// if there is a condition and it is not met, do not apply this rule
				return true;
			}

			return this.regex.IsMatch (str);
		}

		public string Title {
			get {
				if (this.regexCondition != null)
				{
					return String.Format ("Matches {0} if {1}", this.pattern, this.conditionedOn);
				}

				return String.Format ("Matches {0}", this.pattern);
			}
		}

		#endregion
	}
}

