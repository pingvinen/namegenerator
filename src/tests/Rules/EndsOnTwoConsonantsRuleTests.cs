using System;
using NUnit.Framework;
using namegenerator;

namespace tests
{
	[TestFixture]
	public class EndsOnTwoConsonantsRuleTests
	{
		private IRule rule;

		[SetUp]
		public void Setup()
		{
			this.rule = new EndsOnTwoConsonantsRule ();
		}

		[Test]
		public void Yup()
		{
			Assert.AreEqual (false, this.rule.Complies ("abacr"));
		}

		[Test]
		public void BeginsWithTwoConsonantsIsAllowed()
		{
			Assert.AreEqual (true, this.rule.Complies ("croatia"));
		}

		[Test]
		public void Nope()
		{
			Assert.AreEqual (true, this.rule.Complies ("abba"));
		}
	}
}

