using System;
using NUnit.Framework;
using daslib;
using daslib.Rules;

namespace tests.Rules
{
	[TestFixture]
	public class ConsonantsInARowRuleTests
	{
		private IRule rule;

		[SetUp]
		public void Setup()
		{
			this.rule = new ConsonantsInARowRule (3);
		}

		[Test]
		public void Beginning()
		{
			Assert.AreEqual (false, this.rule.Complies ("bcdafk"));
		}

		[Test]
		public void Middle()
		{
			Assert.AreEqual (false, this.rule.Complies ("abfkoi"));
		}

		[Test]
		public void End()
		{
			Assert.AreEqual (false, this.rule.Complies ("abekatth"));
		}

		[Test]
		public void Complies()
		{
			Assert.AreEqual (true, this.rule.Complies ("sonice"));
		}
	}
}

