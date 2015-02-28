using System;
using ServiceStack.ServiceInterface;
using daslib;
using viewer.WebStuff.Models.Types;

namespace viewer
{
	public class GetDefaultService : Service
	{
		private readonly NameRepository repository;

		public GetDefaultService(NameRepository repository)
		{
			this.repository = repository;
		}

		public DefaultData Get(GetDefault request)
		{
			int namesPerPage = 102;
			int offset = request.Page * namesPerPage;

			var data = new DefaultData ();
			data.NumberOfNames = this.repository.CountNames ();
			data.Names = this.repository.GetList (offset, namesPerPage);
			data.Paginator = new Paginator () {
				  TotalPages = data.NumberOfNames / namesPerPage
				, CurrentPage = request.Page
			};

			return data;
		}
	}
}
	