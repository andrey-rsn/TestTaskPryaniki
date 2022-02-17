using TestTaskPryaniki.Models;

namespace TestTaskPryaniki.Data
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task<bool> AddProduct(Product product);

        Task<bool> AddProductInOrder(Guid productId, int quantity);
        Task<bool> DeleteProductFromOrder(string productId);
        Task<IEnumerable<Order>> GetOrderList();
        Task<bool> DeleteProduct(string productId);


    }
}
