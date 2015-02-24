using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using namegenerator.Rules;

namespace namegenerator
{
	public class MultiLetterValidator : IValidator
	{
		private List<IRule> rules;

		public MultiLetterValidator()
		{
			this.rules = new List<IRule> () {
				  new RepeatedCharactersRule(3)
				, new NumberOfVowelsRule(2, 4)
				, new ConsonantsInARowRule(3)
				, new LetterCountRule("h", 2)
				, new LetterCountRule("q", 2)
				, new LetterCountRule("z", 2)
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

