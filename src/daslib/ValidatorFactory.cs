using System;
using daslib.Validators;

namespace daslib
{
	public class ValidatorFactory
	{
		private IValidator accept;
		private IValidator three;
		private IValidator multi;

		public IValidator Get(int forLength)
		{
			if (forLength == 3)
			{
				return this.ThreeLetter ();
			}

			return this.MultiLetter ();
		}

		public IValidator Accepting()
		{
			if (this.accept == default(AcceptingValidator))
			{
				this.accept = new AcceptingValidator ();
			}

			return this.accept;
		}

		public IValidator ThreeLetter()
		{
			if (this.three == default(ThreeLetterValidator))
			{
				this.three = new ThreeLetterValidator ();
			}

			return this.three;
		}

		public IValidator MultiLetter()
		{
			if (this.multi == default(MultiLetterValidator))
			{
				this.multi = new MultiLetterValidator ();
			}

			return this.multi;
		}
	}
}

