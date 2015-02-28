using System;
using ServiceStack.ServiceHost;
using viewer.WebStuff.Models.Types;

namespace viewer.WebStuff.Models
{
	[Route("/check/contains", "POST")]
	public class PostContains : IReturn<SimpleMessage>
	{
		public string Name { get; set; }
	}
}

