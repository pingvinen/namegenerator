using System;
using ServiceStack.ServiceHost;
using viewer.WebStuff.Models.Types;

namespace viewer.WebStuff.Models
{
	[Route("/check/validate", "POST")]
	public class PostValidate : IReturn<SimpleMessage>
	{
		public string Name { get; set; }
	}
}

