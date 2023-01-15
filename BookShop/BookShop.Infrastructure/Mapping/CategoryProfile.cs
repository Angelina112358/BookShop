using AutoMapper;
using BookShop.Infrastructure.Requests.Category;
using BookShop.Infrastructure.Responses;
using BookShop.Domain.Models;

namespace BookShop.Infrastructure.Mapping
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();
            CreateMap<CategoryRequest, Category>();

            CreateMap<Category, CategoryViewModel>();
        }
    }
}
