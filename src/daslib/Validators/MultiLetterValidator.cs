using System;
using System.Collections.Generic;
using daslib.Rules;

namespace daslib.Validators
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

				, new RegexRule("[^jfw]$") // does not end with any of these

				, new RegexRule("^a[^xgjq][^bcefghjmnpqvwxz]", "^a[xgjq]")
				, new RegexRule("^aco[^csy]", "^aco")
				, new RegexRule("^az[^iuyo]r", "^az.r")
				, new RegexRule("^aw[^yu]", "^aw")
				, new DoesNotStartWithRule("abao")
				, new DoesNotStartWithRule("ahy")
				, new DoesNotStartWithRule("ababs")
				, new DoesNotStartWithRule("atit")

				, new RegexRule("[^zwrfcj]$")
				, new DoesNotEndWithRule("deq")
				, new DoesNotEndWithRule("eos")
				, new DoesNotEndWithRule("eov")
				, new DoesNotEndWithRule("gyv")

				, new RegexRule("h[^bcdefgjklmnpqstvwxz]y$", "h.y$")

				, new RegexRule("jy[^hotu]$", "jy.$")
				, new DoesNotEndWithRule("jeo")

				, new DoesNotEndWithRule("qu")
				, new DoesNotEndWithRule("tz")
				, new DoesNotEndWithRule("ueq")
				, new DoesNotEndWithRule("uqi")
				, new DoesNotEndWithRule("uyl")
				, new DoesNotEndWithRule("viu")
				, new DoesNotEndWithRule("xut")
				, new DoesNotEndWithRule("yeg")
				, new RegexRule("y[^bj]$", "y.$")
			};
		}

		public bool IsValid(string name)
		{
			return String.IsNullOrEmpty (this.IsValidWithMessage (name));
		}

		public string IsValidWithMessage (string name)
		{
			foreach (IRule rule in this.rules) {
				if (!rule.Complies (name)) {
					return rule.Title;
				}
			}

			return String.Empty;
		}
	}
}

