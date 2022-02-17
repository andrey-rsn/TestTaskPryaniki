using TestTaskPryaniki.Models;

namespace TestTaskPryaniki.Data
{
    public class ProductsContext
    {
        public List<Product> products;
        public List<Order> orders;
        public ProductsContext()
        {
            products = new List<Product>()
            {
                new Product(){Name="Apple",Price=20},
                new Product(){Name="Juice",Price=80}
            };
            orders= new List<Order>()
            {
                new Order(){product=products[0],quantity=2,amount=40},
                new Order(){product=products[1],quantity=2,amount=160}
            };

        }

    }
}
