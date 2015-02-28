using System;
using NUnit.Framework;
using daslib;
using daslib.Rules;

namespace tests
{
	[TestFixture]
	public class LetterNotFollowedByRuleTests
	{
		private IRule rule;

		[SetUp]
		public void Setup()
		{
			this.rule = new LetterNotFollowedByRule ("v", "fgh");
		}

		[Test]
		public void Beginning()
		{
			Assert.AreEqual (false, this.rule.Complies ("vhamen"));
		}

		[Test]
		public void Middle()
		{
			Assert.AreEqual (false, this.rule.Complies ("ovhamen"));
		}

		[Test]
		public void End()
		{
			Assert.AreEqual (false, this.rule.Complies ("somevg"));
		}

		[Test]
		public void Complies()
		{
			Assert.AreEqual (true, this.rule.Complies ("yeahwithavandstuff"));
		}

		[Test]
		public void MustBeFollowedByVowel_Complies()
		{
			this.rule = new LetterNotFollowedByRule ("v", "^aeiouy");
			Assert.AreEqual (true, this.rule.Complies ("medieval"));
		}

		[Test]
		public void MustBeFollowedByVowel_ISaidNoConsonants()
		{
			this.rule = new LetterNotFollowedByRule ("v", "^aeiouy");
			Assert.AreEqual (false, this.rule.Complies ("medievgal"));
		}
	}
}

