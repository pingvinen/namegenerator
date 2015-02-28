using System;
using ServiceStack.ServiceInterface;

namespace viewer
{
	public class GetDefaultService : Service
	{
		public Stats Get(GetDefault request)
		{
			return new Stats () { NumberOfNames = 666 };
		}
	}
}
	