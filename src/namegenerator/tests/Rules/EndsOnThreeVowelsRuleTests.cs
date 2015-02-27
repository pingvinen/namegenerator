using System;
using NUnit.Framework;
using namegenerator;

namespace tests
{
	[TestFixture]
	public class EndsOnThreeVowelsRuleTests
	{
		private IRule rule;

		[SetUp]
		public void Setup()
		{
			this.rule = new EndsOnThreeVowelsRule ();
		}

		[Test]
		public void Yup()
		{
			Assert.AreEqual (false, this.rule.Complies ("awwyie"));
		}

		[Test]
		public void Nope()
		{
			Assert.AreEqual (true, this.rule.Complies ("leslie"));
		}
	}
}

