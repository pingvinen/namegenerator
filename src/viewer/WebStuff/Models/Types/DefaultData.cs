using System;
using System.Collections.Generic;
using daslib;

namespace viewer.WebStuff.Models.Types
{
	public class DefaultData
	{
		public int NumberOfNames { get; set; }
		public IList<NameEntry> Names { get; set; }
		public Paginator Paginator { get; set; }
	}
}

