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

		public string IsValidWithMessage (string name)
		{
			return String.Empty;
		}
		#endregion
	}
}

