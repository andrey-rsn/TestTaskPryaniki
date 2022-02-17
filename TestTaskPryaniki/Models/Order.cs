namespace TestTaskPryaniki.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Product product { get; set; }

        public int quantity { get; set; }

        public decimal amount { get; set; } 
    }
}
