using Microsoft.AspNetCore.Mvc;
using TestTaskPryaniki.Data;
using TestTaskPryaniki.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTaskPryaniki.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        public ProductController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productsRepository.GetAllProducts();
            return Json(products);
        }

        [HttpGet("order")]
        public async Task<IActionResult> GetOrderList()
        {
            var orderList = await _productsRepository.GetOrderList();
            return Json(orderList);
        }

        [HttpPost("products")]
        public async Task<IActionResult> AddProduct( Product product)
        {
            if(product!=null)
            {
                var result=await _productsRepository.AddProduct(product);
                if(result)
                {
                    return StatusCode(201);
                }
                return StatusCode(400);

            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpPost("order")]
        public async Task<IActionResult> AddProductInOrder(OrderViewModel order)
        {
            if (!string.IsNullOrEmpty(order.productId.ToString()))
            {
                var result =await _productsRepository.AddProductInOrder(order.productId,order.quantity);
                if(result)
                {
                    return StatusCode(201);
                }
                return StatusCode(400);
            }
            else
            {
                return StatusCode(400);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("order")]
        public async Task<IActionResult> DeleteProductFromOrder(string productId)
        {
            if (!string.IsNullOrEmpty(productId))
            {
                var result=await _productsRepository.DeleteProductFromOrder(productId);
                if(result)
                {
                    return StatusCode(201);
                }
                return StatusCode(400);
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpDelete("product")]
        public async Task<IActionResult> DeleteProduct(string productId)
        {
            if (!string.IsNullOrEmpty(productId))
            {
                var result = await _productsRepository.DeleteProduct(productId);
                if (result)
                {
                    return StatusCode(201);
                }
                return StatusCode(400);
            }
            else
            {
                return StatusCode(400);
            }
        }
    }
}
