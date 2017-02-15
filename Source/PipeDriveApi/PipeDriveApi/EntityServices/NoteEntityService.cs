using RestSharp;
using System.Threading.Tasks;

namespace PipeDriveApi.EntityServices
{
    public class NoteEntityService : PagingEntityService<Note>
    {
        public NoteEntityService(IPipeDriveClient client) : base(client, "notes")
        {
        }

		public new async Task<bool> DeleteAsync(int id)
		{
			var request = new RestRequest(_Resource + "/{id}", Method.DELETE);
			request.AddUrlSegment("id", id.ToString());

			return await _client.ExecuteRequestAsync<bool>(request);
		}
	}
}
