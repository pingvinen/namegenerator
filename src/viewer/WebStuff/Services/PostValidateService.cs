using System;
using ServiceStack.ServiceInterface;
using daslib;
using viewer.WebStuff.Models.Types;
using viewer.WebStuff.Models;

namespace viewer.WebStuff.Services
{
	public class PostValidateService : Service
	{
		private readonly ValidatorFactory factory;

		public PostValidateService (ValidatorFactory factory)
		{
			this.factory = factory;
		}

		public SimpleMessage Post(PostValidate request)
		{
			string msg = this.factory.Get (request.Name.Length).IsValidWithMessage (request.Name);

			if (String.IsNullOrEmpty(msg))
			{
				return new SimpleMessage ("Valid");
			}

			return new SimpleMessage (String.Format("Does not comply with: {0}", msg));
		}
	}
}

