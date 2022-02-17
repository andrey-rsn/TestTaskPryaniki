using TestTaskPryaniki.Models;

namespace TestTaskPryaniki.Data
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductsContext _productsContext;
        public ProductsRepository(ProductsContext productsContext)
        {
            _productsContext = productsContext;
        }
        public async Task<bool> AddProduct(Product product)
        {
            return await Task.Run(() =>
            {
                if(product == null)
                {
                    return false;
                }
                _productsContext.products.Add(product);
                return true;
            });
        }

        public async Task<bool> AddProductInOrder(Guid productId, int quantity)
        {
            return await Task.Run(() =>
            {
                var product = _productsContext.products.Where(x=>x.Id==productId).FirstOrDefault();
                if(product==null)
                {
                    return false;
                }
                var order= new Order() { 
                    product = product,
                    amount=quantity*product.Price,
                    quantity=quantity
                };
                _productsContext.orders.Add(order);
                return true;
            });
        }

        public async Task<bool> DeleteProductFromOrder(string productId)
        {
            return await Task.Run(() =>
            {
                var id=new Guid(productId);
                var order = _productsContext.orders.Where(x=>x.product.Id==id).FirstOrDefault();
                if(order!=null)
                {
                    _productsContext.orders.Remove(order);
                    return true;
                }
                return false;
                    
            });
        }

        public async Task<bool> DeleteProduct(string productId)
        {
            return await Task.Run(() =>
            {
                var id = new Guid(productId);
                var order = _productsContext.products.Where(x => x.Id == id).FirstOrDefault();
                if (order != null)
                {
                    _productsContext.products.Remove(order);
                    return true;
                }
                return false;

            });
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await Task.Run(() =>
            {
                return _productsContext.products;
            });
            
        }

        public async Task<IEnumerable<Order>> GetOrderList()
        {
            return await Task.Run(() =>
            {
                return _productsContext.orders;
            });
        }
    }
}
