using System;

namespace namegenerator
{
	public class GenerateResult
	{
		public GenerateResult ()
		{
			this.EntriesGenerated = 0;
			this.ValidEntries = 0;
			this.TimeUsed = TimeSpan.MinValue;
		}

		public int EntriesGenerated { get; set; }
		public int ValidEntries { get; set; }
		public TimeSpan TimeUsed { get; set; }
	}
}

