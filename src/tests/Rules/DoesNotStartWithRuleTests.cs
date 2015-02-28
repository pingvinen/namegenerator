using System;
using NUnit.Framework;
using daslib;
using daslib.Rules;

namespace tests
{
	[TestFixture]
	public class DoesNotStartWithRuleTests
	{
		private IRule rule;

		[SetUp]
		public void Setup()
		{
			this.rule = new DoesNotStartWithRule ("abba");
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

