using System;

namespace namegenerator
{
	public class AcceptingValidator : IValidator
	{
		#region IValidator implementation

		public bool IsValid (string name)
		{
			return true;
		}

		#endregion
	}
}

