using System;
using System.Text.RegularExpressions;

namespace namegenerator
{
	public class EndsOnThreeVowelsRule : IRule
	{
		private Regex regex = new Regex("[aeiouy]{3,}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		#region IRule implementation

		public bool Complies (string str)
		{
			return !regex.IsMatch (str);
		}

		public string Title {
			get {
				return "Ends on three vowels";
			}
		}

		#endregion
	}
}

