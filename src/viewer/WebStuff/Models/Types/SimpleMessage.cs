using System;

namespace viewer.WebStuff.Models.Types
{
	public class SimpleMessage
	{
		public SimpleMessage(string message)
		{
			this.Message = message;
		}

		public string Message { get; set; }
	}
}

