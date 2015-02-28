using System;
using NUnit.Framework;
using daslib;
using daslib.Rules;

namespace tests.Rules
{
	[TestFixture]
	public class LetterCountRuleTests
	{
		private IRule rule;

		[SetUp]
		public void Setup()
		{
			this.rule = new LetterCountRule ("x", 2);
		}

		[Test]
		public void Less()
		{
			Assert.AreEqual (true, this.rule.Complies ("hexagon"));
		}

		[Test]
		public void Limit()
		{
			Assert.AreEqual (true, this.rule.Complies ("extremex"));
		}

		[Test]
		public void TooMany()
		{
			Assert.AreEqual (false, this.rule.Complies ("xwhatxwhox"));
		}
	}
}

