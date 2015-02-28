using System;
using ServiceStack.ServiceHost;

namespace viewer
{
	[Route("/default", "GET")]
	public class GetDefault : IReturn<Stats>
	{
	}
}

