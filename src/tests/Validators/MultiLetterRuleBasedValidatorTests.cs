using System;
using NUnit.Framework;
using daslib;
using daslib.Validators;

namespace tests.Validators
{
	[TestFixture]
	public class MultiLetterRuleBasedValidatorTests
	{
		private IValidator validator;

		[SetUp]
		public void Setup()
		{
			this.validator = new MultiLetterRuleBasedValidator ();
		}

		[Test]
		public void abatyc()
		{
			Assert.AreEqual(false, this.validator.IsValid ("abatyc"));
		}
	}
}

