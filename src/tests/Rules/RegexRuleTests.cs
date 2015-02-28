using System;
using NUnit.Framework;
using namegenerator;

namespace tests
{
	[TestFixture]
	public class RegexRuleTests
	{
		private IRule rule;
		private IRule conditionedRule;

		[SetUp]
		public void Setup()
		{
			this.rule = new RegexRule ("^b.*c$");
			this.conditionedRule = new RegexRule ("^b.*c$", "^b");
		}

		[Test]
		public void Matches()
		{
			Assert.AreEqual (true, this.rule.Complies ("bananacattac"));
		}

		[Test]
		public void DoesNotMatch()
		{
			Assert.AreEqual (false, this.rule.Complies ("nomatch"));
		}

		[Test]
		public void ReturnTrue_IfConditionIsNotMet()
		{
			Assert.AreEqual (true, this.conditionedRule.Complies ("a"));
		}

		[Test]
		public void ReturnsFalse_IfConditionIsMet_ButInputDoesNotComply()
		{
			Assert.AreEqual (false, this.conditionedRule.Complies ("bobba"));
		}

		[Test]
		public void FirstThreeLetters()
		{
			this.rule = new RegexRule ("^a[^xgj][^bcefghjmnpqvwxz]");
			Assert.AreEqual (false, this.rule.Complies ("axo"));
			Assert.AreEqual (true, this.rule.Complies ("abo"));
		}

		[Test]
		public void ACO()
		{
			this.rule = new RegexRule("^aco[^csy]", "^aco");
			Assert.AreEqual (true, this.rule.Complies ("abo")); // since condition is not met
			Assert.AreEqual (true, this.rule.Complies ("acoo"));
			Assert.AreEqual (false, this.rule.Complies ("acoc"));
		}
	}
}
