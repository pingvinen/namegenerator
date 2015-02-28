using System;
using NUnit.Framework;
using daslib;

namespace tests
{
	[TestFixture]
	public class PaginatorTests
	{
		private Paginator paginator;

		[SetUp]
		public void Setup()
		{
			this.paginator = new Paginator () {
				  TotalPages = 10
				, CurrentPage = 3
			};
		}

		[Test]
		public void PagesBefore_FirstPage()
		{
			this.paginator = new Paginator () {
				  TotalPages = 10
				, CurrentPage = 0
			};

			var range = this.paginator.PagesBefore;

			Assert.AreEqual (0, range.Count, "Number of elements is wrong");
		}

		[Test]
		public void PagesBefore_WithinFirstFive()
		{
			this.paginator = new Paginator () {
				  TotalPages = 10
				, CurrentPage = 3
			};

			var range = this.paginator.PagesBefore;

			Assert.AreEqual (3, range.Count, "Number of elements is wrong");
			Assert.AreEqual (0, range [0]);
			Assert.AreEqual (1, range [1]);
			Assert.AreEqual (2, range [2]);
		}

		[Test]
		public void PagesBefore_AfterFirstFive()
		{
			this.paginator = new Paginator () {
				  TotalPages = 10
				, CurrentPage = 9
			};

			var range = this.paginator.PagesBefore;

			Assert.AreEqual (5, range.Count, "Number of elements is wrong");
			Assert.AreEqual (4, range [0]);
			Assert.AreEqual (5, range [1]);
			Assert.AreEqual (6, range [2]);
			Assert.AreEqual (7, range [3]);
			Assert.AreEqual (8, range [4]);
		}

		[Test]
		public void PagesAfter_BeforeLastFive()
		{
			this.paginator = new Paginator () {
				  TotalPages = 10
				, CurrentPage = 3
			};

			var range = this.paginator.PagesAfter;

			Assert.AreEqual (5, range.Count, "Number of elements is wrong");
			Assert.AreEqual (4, range [0]);
			Assert.AreEqual (5, range [1]);
			Assert.AreEqual (6, range [2]);
			Assert.AreEqual (7, range [3]);
			Assert.AreEqual (8, range [4]);
		}

		[Test]
		public void PagesAfter_WithinLastFive()
		{
			this.paginator = new Paginator () {
				  TotalPages = 10
				, CurrentPage = 7
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
			};

			var range = this.paginator.PagesAfter;

			Assert.AreEqual (0, range.Count, "Number of elements is wrong");
		}
	}
}

