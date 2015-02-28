using System;
using ServiceStack.ServiceInterface;
using daslib;
using viewer.WebStuff.Models;
using viewer.WebStuff.Models.Types;

namespace viewer.WebStuff.Services
{
	public class PostContainsService : Service
	{
		private readonly NameRepository repository;

		public PostContainsService (NameRepository repository)
		{
			this.repository = repository;
		}

		public SimpleMessage Post(PostContains request)
		{
			var entry = this.repository.Get (request.Name);

			if (entry != default(NameEntry))
			{
				string isValid = entry.IsValid ? "valid" : "invalid";
				return new SimpleMessage(String.Format ("{0} exists and has ID {1} and is {2}", entry.Name, entry.Id, isValid));
			}

			return new SimpleMessage("Nope");
		}
	}
}

