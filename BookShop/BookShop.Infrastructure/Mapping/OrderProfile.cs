using AutoMapper;
using BookShop.Domain.Models;
using BookShop.Infrastructure.Requests.Order;
using BookShop.Infrastructure.Responses;

namespace BookShop.Infrastructure.Mapping
{
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(d => d.TotalPrice,
                    o => o.MapFrom(order =>
                        order.ProductOrders.Select(productOrder => productOrder.Product.Price).Sum()))
                .ForMember(d => d.Products,
                    o => o.MapFrom(order =>
                        order.ProductOrders.Select(productOrder => new ProductViewModel
                        {
                            Id = productOrder.ProductId,
                            Name = productOrder.Product.Name,
                            Author = productOrder.Product.Author,
                            Description = productOrder.Product.Description,
                            Price = productOrder.Product.Price,
                            CreationDate = productOrder.Product.CreationDate,
                            Categories = productOrder.Product.Categories.Select(c => new CategoryViewModel
                            {
                                Id = c.Id,
                                Name = c.Name,
                            }).ToList(),
                        })))
                .ForMember(d => d.User, 
                    o => o.MapFrom(order =>
                        order.User));
            CreateMap<User, OrderViewModel.UserViewModel>();

            CreateMap<CreateOrderRequest, Order>();
            CreateMap<ProductOrderRequest, ProductOrder>();
        }
    }
}
