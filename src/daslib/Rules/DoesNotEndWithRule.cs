using System;

namespace daslib.Rules
{
	public class DoesNotEndWithRule : IRule
	{
		string notAllowed;

		public DoesNotEndWithRule (string notAllowed)
		{
			this.notAllowed = notAllowed;
		}

		#region IRule implementation

		public bool Complies (string str)
		{
			return !str.EndsWith (this.notAllowed);
		}

		public string Title {
			get {
				return String.Format ("Does not end with {0}", this.notAllowed);
			}
		}

		#endregion
	}
}

