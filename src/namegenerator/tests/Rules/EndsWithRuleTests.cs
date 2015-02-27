using System;
using NUnit.Framework;
using namegenerator;

namespace tests
{
	[TestFixture]
	public class EndsWithRuleTests
	{
		private IRule rule;

		[SetUp]
		public void Setup()
		{
			this.rule = new EndsWithRule ("z");
		}

		[Test]
		public void Beginning()
		{
			Assert.AreEqual (true, this.rule.Complies ("zomething"));
		}

		[Test]
		public void Middle()
		{
			Assert.AreEqual (true, this.rule.Complies ("aze"));
		}

		[Test]
		public void End()
		{
			Assert.AreEqual (false, this.rule.Complies ("rulez"));
		}
	}
}

