using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using daslib.Rules;

namespace daslib.Validators
{
	public class ThreeLetterRuleBasedValidator : RuleBasedValidatorBase
	{
		public ThreeLetterRuleBasedValidator()
		{
			base.rules = new List<IRule> () {
				new RepeatedCharactersRule(2)
			};
		}
	}
}

