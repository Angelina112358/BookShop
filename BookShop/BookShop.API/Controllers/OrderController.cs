using BookShop.Domain.Models;
using BookShop.Infrastructure.Interfaces;
using BookShop.Infrastructure.Requests.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            var userId = 4;
            Console.WriteLine(request.ToString());
            //int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            await _orderService.CreateOrderAsync(userId, request);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _orderService.GetAllOrdersAsync());
        }
        //[HttpGet("/products")]
        //public async Task<IActionResult> GetAllProductOrders()
        //{
        //    return Ok(await _orderService.GetAll());
        //}
        //[HttpPost("create")]
        //public async Task<IActionResult> CreateProduct(ProductOrderRequest request)
        //{
        //    await _orderService.CreateProductOrder(request);
        //    return NoContent();
        //}
    }
}
