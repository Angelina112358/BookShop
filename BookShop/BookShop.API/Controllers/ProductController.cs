using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookShop.Infrastructure.Interfaces;
using BookShop.Infrastructure.Responses;
using BookShop.Infrastructure.Requests.Product;

namespace BookShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("CreateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateProductAsync(CreateProductRequest product)
        {
            await _productService.CreateProductAsync(product);
            return NoContent();
        }

        [HttpPost("UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateProductAsync(int id, UpdateProductRequest request)
        {
            await _productService.UpdateProductAsync(id, request);
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("name/{name}", Name = "GetProductByName")]
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var product = await _productService.GetProductByNameAsync(name);
            return Ok(product);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        [ProducesResponseType(typeof(ProductViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var products = await _productService.GetProductsByCategoryAsync(categoryId);
            return Ok(products);
        }

        [HttpDelete("DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
