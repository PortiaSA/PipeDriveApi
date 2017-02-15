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
    }
}
