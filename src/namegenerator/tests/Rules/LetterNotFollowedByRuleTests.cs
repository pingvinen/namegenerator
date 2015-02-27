using System;
using NUnit.Framework;
using namegenerator;

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
	}
}

