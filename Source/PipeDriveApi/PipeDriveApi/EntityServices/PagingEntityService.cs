using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipeDriveApi;
using PipeDriveApi.Requests;

namespace PipeDriveApi.EntityServices
{
    public abstract class PagingEntityService<TEntity> : EntityServiceBase
        where TEntity : BaseEntity, new()
    {
        protected string _Resource;
        public PagingEntityService(IPipeDriveClient client, string resource) : base(client)
        {
            _Resource = resource;
        }

		#region Create
		public async Task<TEntity> AddAsync(IAddRequestBody body)
		{
			var request = new RestRequest(_Resource, Method.POST);

			return await _client.ExecuteRequestAsync<TEntity>(request, body);
		}
		#endregion Create


		#region Read
		public async Task<ListResult<TEntity>> GetAsync(int start = 0, int limit = 100, Sort sort = null)
		{
			return await GetAsync<TEntity>(start, limit, sort);
		}
        public async Task<ListResult<T>> GetAsync<T>(int start = 0, int limit = 100, Sort sort = null)
        {
            var request = new RestRequest(_Resource, Method.GET);
            return await GetAsync<T>(request, start, limit, sort);
        }

		public async Task<ListResult<TEntity>> GetAsync(IRestRequest request, int start = 0, int limit = 100, Sort sort = null)
		{
			return await GetAsync<TEntity>(request, start, limit, sort);
		}
        public async Task<ListResult<T>> GetAsync<T>(IRestRequest request, int start = 0, int limit = 100, Sort sort = null)
        {
            request.SetParameter("start", start.ToString());
            request.SetParameter("limit", limit.ToString());
            if (sort != null)
                request.SetParameter("sort", sort.ToString());

            var response = await _client.ExecuteRequestWithCustomResponseAsync<PaginatedPipeDriveResponse<T>, List<T>>(request);
            return new ListResult<T>(response.Data, response.AdditionalData.Pagination);
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(Sort sort = null)
        {
            var request = new RestRequest(_Resource, Method.GET);
            return await GetAllAsync(request, sort);
        }
        public async Task<IReadOnlyList<TEntity>> GetAllAsync(IRestRequest request, Sort sort = null)
        {
            var combinedList = new List<TEntity>();
            int start = 0, limit = 1000;
            while (true)
            {
                var response = await GetAsync(request, start, limit, sort);
                combinedList.AddRange(response);
                start = response.Pagination.NextStart;
                if(!response.Pagination.MoreItemsInCollection) break;
            }
            return combinedList;
        }
		#endregion Read

		#region Delete
		public virtual async Task<BaseEntity> DeleteAsync(int id)
		{
			var request = new RestRequest(_Resource + "/{id}", Method.DELETE);
			request.AddUrlSegment("id", id.ToString());

			return await _client.ExecuteRequestAsync<BaseEntity>(request);
		}
		#endregion Delete
	}
}
