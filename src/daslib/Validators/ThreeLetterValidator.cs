using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using daslib.Rules;

namespace daslib.Validators
{
	public class ThreeLetterValidator : IValidator
	{
		private List<IRule> rules;

		public ThreeLetterValidator()
		{
			this.rules = new List<IRule> () {
				new RepeatedCharactersRule(2)
			};
		}

		public bool IsValid(string name)
		{
			foreach (IRule rule in this.rules) {
				if (!rule.Complies (name)) {
					return false;
				}
			}

			return true;
		}
	}
}

