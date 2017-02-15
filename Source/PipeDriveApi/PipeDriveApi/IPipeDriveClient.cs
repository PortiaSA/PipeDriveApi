using System.Threading.Tasks;
using RestSharp;

namespace PipeDriveApi
{
    public interface IPipeDriveClient
    {
        Task<T> ExecuteRequestAsync<T>(IRestRequest request) where T : new();
        Task ExecuteRequestAsync(IRestRequest request);
        Task<TResponse> ExecuteRequestWithCustomResponseAsync<TResponse, T>(IRestRequest request)
            where TResponse : PipeDriveResponse<T>, new();
        Task<T> ExecuteRequestAsync<T>(IRestRequest request, object body) where T : new();
        Task ExecuteRequestAsync(IRestRequest request, object body);
        Task<TResponse> ExecuteRequestWithCustomResponseAsync<TResponse, T>(IRestRequest request, object body)
            where TResponse : PipeDriveResponse<T>, new();

    }
}