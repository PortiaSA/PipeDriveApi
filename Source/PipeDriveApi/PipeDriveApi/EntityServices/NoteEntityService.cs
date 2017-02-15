using RestSharp;
using System.Threading.Tasks;

namespace PipeDriveApi.EntityServices
{
    public class NoteEntityService : PagingEntityService<Note>
    {
        public NoteEntityService(IPipeDriveClient client) : base(client, "notes")
        {
        }
		public async Task<Note> AddAsync(
			string content,
			int? dealId = null,
			int? personId = null,
			int? orgId = null,
			bool isPinnedToDeal = false,
			bool isPinnedToOrganization = false,
			bool isPinnedToPerson = false)
		{
			var request = new RestRequest(_Resource, Method.POST);

			var body = new
			{
				Content = content,
				DealId = dealId,
				PersonId = personId,
				OrgId = orgId,
				PinnedToDealFlag = isPinnedToDeal,
				PinnedToOrganizationFlag = isPinnedToOrganization,
				PinnedToPersonFlag = isPinnedToPerson
			};
			return await _client.ExecuteRequestAsync<Note>(request, body);
		}

		public new async Task<bool> DeleteAsync(int id)
		{
			var request = new RestRequest(_Resource + "/{id}", Method.DELETE);
			request.AddUrlSegment("id", id.ToString());

			return await _client.ExecuteRequestAsync<bool>(request);
		}
	}
}
