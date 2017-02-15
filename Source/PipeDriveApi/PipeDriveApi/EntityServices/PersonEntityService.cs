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

		public async Task<TPerson> AddAsync(
			string name,
			int? ownerId = null,
			int? orgId = null,
			IEnumerable<string> email = null,
			IEnumerable<string> phone = null,
			Visibility visibleTo = Visibility.Shared,
			DateTime? addTime = null
			)
		{
			var request = new RestRequest(_Resource, Method.POST);

			var body = new
			{
				Name = name,
				OwnerId = ownerId,
				OrgId = orgId,
				Email = email,
				Phone = phone,
				VisibleTo = visibleTo, 
				AddTime = addTime
			};
			return await _client.ExecuteRequestAsync<TPerson>(request, body);
		}
	}
}
