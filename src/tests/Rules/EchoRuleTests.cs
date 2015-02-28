using System;
using NUnit.Framework;
using daslib;
using daslib.Rules;

namespace tests
{
	[TestFixture]
	public class EchoRuleTests
	{
		private IRule rule;

		[SetUp]
		public void Setup()
		{
			this.rule = new EchoRule ();
		}

		[Test]
		public void Beginning()
		{
			Assert.AreEqual (false, this.rule.Complies ("ababman"));
		}

		[Test]
		public void Middle()
		{
			Assert.AreEqual (false, this.rule.Complies ("womantotoman"));
		}

		[Test]
		public void End()
		{
			Assert.AreEqual (false, this.rule.Complies ("manwomanabab"));
		}

		[Test]
		public void NoEcho()
		{
			Assert.AreEqual (true, this.rule.Complies ("echoecho"));
		}
	}
}

