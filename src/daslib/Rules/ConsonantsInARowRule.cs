using System;
using System.Text.RegularExpressions;

namespace daslib.Rules
{
	public class ConsonantsInARowRule : IRule
	{
		private Regex noMoreThan3ConsonantsInARow;

		int max;

		public ConsonantsInARowRule (int max)
		{
			this.max = max;

			this.noMoreThan3ConsonantsInARow = new Regex ("([bcdfghjklmnpqrstvwxz]{"+max+",})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		}

		#region IRule implementationreg

		public bool Complies (string str)
		{
			return !this.noMoreThan3ConsonantsInARow.IsMatch (str);
		}

		public string Title {
			get {
				return String.Format ("Max {0} consonants in a row", this.max);
			}
		}

		#endregion
	}
}

