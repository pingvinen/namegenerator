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
				, new LetterCountRule("q", 1)
				, new LetterCountRule("v", 1)
				, new LetterCountRule("z", 1)
				, new LetterCountRule("w", 1)
				, new LetterCountRule("y", 1)
				, new LetterCountRule("x", 1)
				, new LetterCountRule("b", 1)
				, new LetterCountRule("s", 3)
				, new LetterCountRule("j", 1)
				, new LetterCountRule("f", 1)
				, new LetterCountRule("d", 2)
				, new DoubleVowelsRule()
				, new EndsOnTwoConsonantsRule()
				, new EchoRule()
				, new EndsOnThreeVowelsRule()
				, new LetterNotFollowedByRule("v", "^aeiouy") // v can be followed by vowels only
				, new LetterNotFollowedByRule("z", "^aeiouy") // z can be followed by vowels only
				, new LetterNotFollowedByRule("f", "^aeiouy") // f can be followed by vowels only
				, new LetterNotFollowedByRule("w", "^aeiouy") // w can be followed by vowels only
				, new LetterNotFollowedByRule("j", "^aeiouy") // j can be followed by vowels only
				, new LetterNotFollowedByRule("x", "^aeiouy") // x can be followed by vowels only
				, new LetterNotFollowedByRule("p", "^aeiouy") // p can be followed by vowels only
				, new LetterNotFollowedByRule("b", "zwpfxv")
				, new LetterNotFollowedByRule("c", "bzwpfxvngsq")
				, new LetterNotFollowedByRule("l", "bzwpfxv")
				, new LetterNotFollowedByRule("y", "auo")
				, new LetterNotFollowedByRule("d", "xz")
				, new StartsWithRule("abba")
				, new StartsWithRule("acca")
				, new StartsWithRule("azza")
				, new StartsWithRule("acoc")
				, new StartsWithRule("acos")
				, new StartsWithRule("acoy")
				, new StartsWithRule("abev")
				, new StartsWithRule("azir")
				, new StartsWithRule("azur")
				, new StartsWithRule("azyr")
				, new StartsWithRule("abao")
				, new StartsWithRule("ax")
				, new StartsWithRule("ag")
				, new StartsWithRule("aj")
				, new StartsWithRule("ahy")
				, new StartsWithRule("ahv")
				, new StartsWithRule("yeg")
				, new EndsWithRule("z")
				, new EndsWithRule("w")
				, new EndsWithRule("r")
				, new EndsWithRule("f")
				, new EndsWithRule("c")
				, new EndsWithRule("j")
				, new EndsWithRule("gyv")
				, new EndsWithRule("ueq")
				, new EndsWithRule("viu")
				, new EndsWithRule("deq")
				, new EndsWithRule("qu")
				, new EndsWithRule("uyl")
				, new EndsWithRule("xut")
				, new EndsWithRule("jeo")
				, new EndsWithRule("uqi")
				, new EndsWithRule("hei")
				, new EndsWithRule("tz")
				, new EndsWithRule("yb")
				, new EndsWithRule("eos")
				, new EndsWithRule("eov")
				, new EndsWithRule("jyt")
				, new EndsWithRule("jyh")
				, new EndsWithRule("jyo")
				, new EndsWithRule("jyu")
				, new EndsWithRule("hcy")
				, new EndsWithRule("hby")
				, new EndsWithRule("hdy")
				, new EndsWithRule("hfy")
				, new EndsWithRule("hgy")
				, new EndsWithRule("hjy")
				, new EndsWithRule("hky")
				, new EndsWithRule("hly")
				, new EndsWithRule("hmy")
				, new EndsWithRule("hny")
				, new EndsWithRule("hpy")
				, new EndsWithRule("hqy")
				, new EndsWithRule("hsy")
				, new EndsWithRule("hty")
				, new EndsWithRule("hvy")
				, new EndsWithRule("hwy")
				, new EndsWithRule("hxy")
				, new EndsWithRule("hzy")
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

