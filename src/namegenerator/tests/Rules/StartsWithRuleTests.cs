using System;
using NUnit.Framework;
using namegenerator;

namespace tests
{
	[TestFixture]
	public class StartsWithRuleTests
	{
		private IRule rule;

		[SetUp]
		public void Setup()
		{
			this.rule = new StartsWithRule ("abba");
		}

		[Test]
		public void ItDoes()
		{
			Assert.AreEqual (false, this.rule.Complies ("abbadance"));
		}

		[Test]
		public void ItDoesNot()
		{
			Assert.AreEqual (true, this.rule.Complies ("notinthebeginningabbadance"));
		}
	}
}

