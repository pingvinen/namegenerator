using System;
using NUnit.Framework;
using daslib;
using daslib.Validators;
using System.Collections.Generic;
using daslib.Rules;

namespace tests.Validators
{
	[TestFixture]
	public class RuleBasedValidatorTests
	{
		private IValidator validator;

		[SetUp]
		public void Setup()
		{
			this.validator = new TestValidator ();
		}

		[Test]
		public void IsValid_Invalid_ByFirstRule()
		{
			Assert.AreEqual (false, this.validator.IsValid ("b invalid"));
		}

		[Test]
		public void IsValid_Invalid_BySecondRule()
		{
			Assert.AreEqual (false, this.validator.IsValid ("c invalid"));
		}

		[Test]
		public void IsValid_Valid()
		{
			Assert.AreEqual (true, this.validator.IsValid ("valid"));
		}
	}



	public class TestValidator : RuleBasedValidatorBase
	{
		public TestValidator()
		{
			base.rules = new List<IRule> () {
				  new DoesNotStartWithRule("b")
				, new DoesNotStartWithRule("c")
			};
		}
	}
}

