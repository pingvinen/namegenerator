using System;

namespace namegenerator
{
	public class StartsWithRule : IRule
	{
		string notAllowed;

		public StartsWithRule (string notAllowed)
		{
			this.notAllowed = notAllowed;
		}

		#region IRule implementation

		public bool Complies (string str)
		{
			return !str.StartsWith (this.notAllowed);
		}

		public string Title {
			get {
				return String.Format ("Does not start with {0}", this.notAllowed);
			}
		}

		#endregion
	}
}

