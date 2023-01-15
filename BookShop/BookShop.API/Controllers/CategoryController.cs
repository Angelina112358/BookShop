using BookShop.Infrastructure.Interfaces;
using BookShop.Infrastructure.Requests.Category;
using BookShop.Infrastructure.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost("CreateCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
        {
            await _service.CreateCategoryAsync(request);
            return NoContent();
        }

        [HttpPost("UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryRequest request)
        {
            await _service.UpdateCategoryAsync(id, request);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _service.GetAllCategoriesAsync();
            return Ok(result);
        }
        [HttpGet("name/{name}", Name = "GetCategoryByName")]
        [ProducesResponseType(typeof(CategoryViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var product = await _service.GetCategoryByNameAsync(name);
            return Ok(product);
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        [ProducesResponseType(typeof(CategoryViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var product = await _service.GetCategoryByIdAsync(id);
            return Ok(product);
        }

        [HttpDelete("DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _service.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
