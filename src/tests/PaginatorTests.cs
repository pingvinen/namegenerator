using System;
using NUnit.Framework;
using daslib;

namespace tests
{
	[TestFixture]
	public class PaginatorTests
	{
		private Paginator paginator;

		[Test]
		public void PagesBefore_FirstPage()
		{
			this.paginator = new Paginator () {
				  TotalPages = 10
				, CurrentPage = 0
				, RangeCount = 4
			};

			var range = this.paginator.PagesBefore;

			Assert.AreEqual (0, range.Count, "Number of elements is wrong");
		}

		[Test]
		public void PagesBefore_SecondPage()
		{
			this.paginator = new Paginator () {
				TotalPages = 10
				, CurrentPage = 1
				, RangeCount = 4
			};

			var range = this.paginator.PagesBefore;

			Assert.AreEqual (1, range.Count, "Number of elements is wrong");
			Assert.AreEqual (0, range [0]);
		}

		[Test]
		public void PagesBefore_WithinFirstRange()
		{
			this.paginator = new Paginator () {
				  TotalPages = 10
				, CurrentPage = 3
				, RangeCount = 4
			};

			var range = this.paginator.PagesBefore;

			Assert.AreEqual (3, range.Count, "Number of elements is wrong");
			Assert.AreEqual (0, range [0]);
			Assert.AreEqual (1, range [1]);
			Assert.AreEqual (2, range [2]);
		}

		[Test]
		public void PagesBefore_AfterFirstRange()
		{
			this.paginator = new Paginator () {
				  TotalPages = 10
				, CurrentPage = 9
				, RangeCount = 4
			};

			var range = this.paginator.PagesBefore;

			Assert.AreEqual (4, range.Count, "Number of elements is wrong");
			Assert.AreEqual (5, range [0]);
			Assert.AreEqual (6, range [1]);
			Assert.AreEqual (7, range [2]);
			Assert.AreEqual (8, range [3]);
		}

		[Test]
		public void PagesAfter_BeforeLastRange()
		{
			this.paginator = new Paginator () {
				  TotalPages = 10
				, CurrentPage = 3
				, RangeCount = 4
			};

			var range = this.paginator.PagesAfter;

			Assert.AreEqual (4, range.Count, "Number of elements is wrong");
			Assert.AreEqual (4, range [0]);
			Assert.AreEqual (5, range [1]);
			Assert.AreEqual (6, range [2]);
			Assert.AreEqual (7, range [3]);
		}

		[Test]
		public void PagesAfter_WithinLastRange()
		{
			this.paginator = new Paginator () {
				  TotalPages = 10
				, CurrentPage = 7
				, RangeCount = 4
			};

			var range = this.paginator.PagesAfter;

			Assert.AreEqual (2, range.Count, "Number of elements is wrong");
			Assert.AreEqual (8, range [0]);
			Assert.AreEqual (9, range [1]);
		}

		[Test]
		public void PagesAfter_LastPage()
		{
			this.paginator = new Paginator () {
				  TotalPages = 10
				, CurrentPage = 9
				, RangeCount = 4
			};

			var range = this.paginator.PagesAfter;

			Assert.AreEqual (0, range.Count, "Number of elements is wrong");
		}
	}
}

