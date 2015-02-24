using System;
using NUnit.Framework;
using namegenerator.Rules;

namespace tests.Rules
{
	[TestFixture]
	public class RepeatedCharactersRuleTests
	{
		private RepeatedCharactersRule rule;

		[SetUp]
		public void Setup()
		{
			rule = new RepeatedCharactersRule (3);
		}

		[Test]
		public void Beginning()
		{
			Assert.AreEqual (false, rule.Complies ("aaabc"));
		}

		[Test]
		public void Middle()
		{
			Assert.AreEqual (false, rule.Complies ("abbbc"));
		}

		[Test]
		public void End()
		{
			Assert.AreEqual (false, rule.Complies ("abccc"));
		}

		[Test]
		public void Not()
		{
			Assert.AreEqual (true, rule.Complies ("abc"));
		}

		[Test]
		public void TwoMiddle()
		{
			rule = new RepeatedCharactersRule (2);
			Assert.AreEqual (false, rule.Complies ("abba"));
		}
	}
}

