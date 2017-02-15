using PipeDriveApi.Enums;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeDriveApi.EntityServices
{
    public class OrganizationEntityService<TOrganization> : PagingEntityService<TOrganization>
        where TOrganization : Organization, new()
    {
        public OrganizationEntityService(IPipeDriveClient client) : base(client, "organizations")
        {
        }

		public async Task<ListResult<TOrganization>> FindAsync(string name, int start = 0, int limit = 100)
		{
            var request = new RestRequest($"{_Resource}/find", Method.GET);
			request.AddParameter("term", name);

			return await GetAsync(request, start, limit);
		}

		public async Task<TOrganization> AddAsync(string name, int? ownerId = null, Visibility visibleTo = Visibility.Shared, DateTime? addTime = null)
		{
            var request = new RestRequest(_Resource, Method.POST);

			var parameters = new { Name = name, VisibleTo = visibleTo, OwnerId = ownerId, AddTime = addTime };
            return await _client.ExecuteRequestAsync<TOrganization>(request, parameters);
		}
    }
}
