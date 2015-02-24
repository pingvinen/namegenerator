using System;
using NUnit.Framework;
using namegenerator.Rules;

namespace tests.Rules
{
	[TestFixture]
	public class NumberOfVowelsRuleTests
	{
		private NumberOfVowelsRule rule;

		[SetUp]
		public void Setup()
		{
			this.rule = new NumberOfVowelsRule (2, 4);
		}

		[Test]
		public void TooFew()
		{
			Assert.AreEqual (false, this.rule.Complies ("abcd"));
		}

		[Test]
		public void Minimum()
		{
			Assert.AreEqual (true, this.rule.Complies ("abcda"));
		}

		[Test]
		public void InBetween()
		{
			Assert.AreEqual (true, this.rule.Complies ("abacda"));
		}

		[Test]
		public void Maximum()
		{
			Assert.AreEqual (true, this.rule.Complies ("abecdio"));
		}

		[Test]
		public void TooMany()
		{
			Assert.AreEqual (false, this.rule.Complies ("abecdiouy"));
		}
	}
}

