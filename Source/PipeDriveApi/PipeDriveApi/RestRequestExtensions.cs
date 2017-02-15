using RestSharp;
using System.Linq;

namespace PipeDriveApi
{
    public static class RestRequestExtensions
    {
        public static void SetParameter(this IRestRequest request, string name, string value)
        {
            var p = request.Parameters.FirstOrDefault(_ => _.Name == name);
			if (p != null)
			{
				p.Value = value;
			}
			else
			{
				request.AddParameter(name, value);
			}
        }
    }
}
