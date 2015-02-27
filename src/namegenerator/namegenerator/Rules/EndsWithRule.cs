using System;

namespace namegenerator
{
	public class EndsWithRule : IRule
	{
		string notAllowed;

		public EndsWithRule (string notAllowed)
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
				return String.Format ("May not end with {0}", this.notAllowed);
			}
		}

		#endregion
	}
}

