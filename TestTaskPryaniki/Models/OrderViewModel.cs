using System.ComponentModel.DataAnnotations;

namespace TestTaskPryaniki.Models
{
    public class OrderViewModel
    {

        public Guid productId { get; set; }


        public int quantity { get; set; } 

    }
}
