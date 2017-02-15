using PipeDriveApi.Enums;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeDriveApi.EntityServices
{
    public class PersonEntityService<TPerson> : PagingEntityService<TPerson>
        where TPerson : Person, new()
    {
        public PersonEntityService(IPipeDriveClient client) : base(client, "persons")
        {
        }

		public async Task<ListResult<FoundPerson>> FindAsync(
			string email,
			int? orgId = null,
			int start = 0,
			int limit = 100)
		{
			var request = new RestRequest($"{_Resource}/find", Method.GET);
			request.AddParameter("term", email);
			if (orgId.HasValue)
			{
				request.AddParameter("org_id", orgId);
			}
			request.AddParameter("search_by_email", true);

			return await GetAsync<FoundPerson>(request, start, limit);
		}
	}
}
