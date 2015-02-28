using System;
using NUnit.Framework;
using daslib;
using daslib.Rules;

namespace tests
{
	[TestFixture]
	public class DoubleVowelsRuleTests
	{
		private IRule rule;

		[SetUp]
		public void Setup()
		{
			this.rule = new DoubleVowelsRule ();
		}


		[Test]
		public void Beginning()
		{
			Assert.AreEqual (false, this.rule.Complies ("yy2k"));
		}

		[Test]
		public void Middle()
		{
			Assert.AreEqual (false, this.rule.Complies ("baab"));
		}

		[Test]
		public void End()
		{
			Assert.AreEqual (false, this.rule.Complies ("babyy"));
		}

		[Test]
		public void Complies()
		{
			Assert.AreEqual (true, this.rule.Complies ("abba"));
		}
	}
}

