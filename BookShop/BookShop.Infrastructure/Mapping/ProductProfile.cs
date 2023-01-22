using AutoMapper;
using BookShop.Infrastructure.Requests.Product;
using BookShop.Infrastructure.Responses;
using BookShop.Domain.Models;

namespace BookShop.Infrastructure.Mapping
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();

            CreateMap<Product, ProductViewModel>();
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
