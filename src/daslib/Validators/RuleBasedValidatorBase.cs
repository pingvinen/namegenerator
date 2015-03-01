using System;
using System.Collections.Generic;

namespace daslib.Validators
{
	public abstract class RuleBasedValidatorBase : IValidator
	{
		protected IList<IRule> rules;


		protected IRule GetBlockingRule(string name)
		{
			foreach (IRule rule in this.rules)
			{
				if (!rule.Complies (name))
				{
					return rule;
				}
			}

			return null;
		}

		#region IValidator implementation

		public bool IsValid(string name)
		{
			return this.GetBlockingRule (name) == null;
		}

		public string IsValidWithMessage (string name)
		{
			IRule rule = this.GetBlockingRule (name);

			if (rule != null)
			{
				return rule.Title;
			}

			return String.Empty;
		}

		#endregion
	}
}

