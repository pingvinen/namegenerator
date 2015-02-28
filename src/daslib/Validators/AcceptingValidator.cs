using System;

namespace daslib.Validators
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

