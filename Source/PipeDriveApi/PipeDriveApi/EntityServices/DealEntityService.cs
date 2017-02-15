using PipeDriveApi.Enums;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeDriveApi.EntityServices
{
    public class DealEntityService<TDeal> : PagingEntityService<TDeal>
        where TDeal : Deal, new()
    {
        public DealEntityService(IPipeDriveClient client) : base(client, "deals")
        {
        }

        public async Task<IReadOnlyCollection<DealProduct>> ListsProductsAttachedToDeal(int dealId)
        {
            var request = new RestRequest(_Resource + "/{dealId}/products", Method.GET);
            request.AddUrlSegment("dealId", dealId.ToString());

            var response = await _client.ExecuteRequestAsync<List<DealProduct>>(request);
            return response.AsReadOnly();
        }

		public async Task<TDeal> AddAsync(
			string title,
			int personId,
			int orgId,
			string value = null,
			string currency = null,
			int? userId = null,
			int? stageId = null,
			DealStatus? status = null,
			string lostReason = null,
			DateTime? addTime = null,
			Visibility visibleTo = Visibility.Shared)
		{
			var request = new RestRequest($"{_Resource}", Method.POST);

			var body = new
			{
				Title = title,
				PersonId = personId,
				OrgId = orgId,
				Value = value,
				Currency = currency,
				UserId = userId,
				StageId = stageId,
				Status = status?.ToString(),
				LostReason = lostReason,
				AddTime = addTime,
				VisibleTo = visibleTo
			};
			return await _client.ExecuteRequestAsync<TDeal>(request, body);
		}
    }
}
