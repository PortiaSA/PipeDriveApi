using RestSharp;
namespace PipeDriveApi.EntityServices
{
    public class ProductEntityService<TProduct> : PagingEntityService<TProduct>
        where TProduct : Product, new()
    {
        public ProductEntityService(IPipeDriveClient client) : base(client, "products")
        {
        }
    }
}
