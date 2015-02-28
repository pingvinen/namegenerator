using System;
using System.Collections.Generic;
using System.Linq;

namespace daslib
{
	public class Paginator
	{
		private int rangeCount = 4;

		public int TotalPages { get; set; }
		public int CurrentPage { get; set; }

		public bool IsFirstPage
		{
			get
			{
				return this.CurrentPage == this.FirstPage;
			}
		}

		public bool IsLastPage
		{
			get
			{
				return this.CurrentPage == this.LastPage;
			}
		}

		public int FirstPage
		{
			get
			{
				return 0;
			}
		}

		public int LastPage
		{
			get
			{
				return this.TotalPages - 1;
			}
		}

		public int PrevPage
		{
			get
			{
				return Math.Max (0, this.CurrentPage - 1);
			}
		}

		public int NextPage
		{
			get
			{
				return Math.Min (this.LastPage, this.CurrentPage + 1);
			}
		}

		public IList<int> PagesBefore
		{
			get
			{
				if (this.IsFirstPage)
				{
					return new List<int> ();
				}

				int start = Math.Max(0, this.CurrentPage - this.rangeCount);
				int count = this.rangeCount;
				if (this.CurrentPage < count)
				{
					count = Math.Min(this.rangeCount, Math.Abs(this.CurrentPage-1 - this.rangeCount));
				}

				return Enumerable.Range (start, count).ToList();
			}
		}

		public IList<int> PagesAfter
		{
			get
			{
				if (this.IsLastPage)
				{
					return new List<int> ();
				}

				int start = this.NextPage;
				int count = Math.Min(this.rangeCount, this.TotalPages - this.NextPage);

				return Enumerable.Range (start, count).ToList();
			}
		}
	}
}

