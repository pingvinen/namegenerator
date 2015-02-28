using System;
using ServiceStack.ServiceHost;
using viewer.WebStuff.Models.Types;

namespace viewer
{
	[Route("/default/{page}", "GET")]
	[Route("/default", "GET")]
	public class GetDefault : IReturn<DefaultData>
	{
		public int Page { get; set; }
	}
}

