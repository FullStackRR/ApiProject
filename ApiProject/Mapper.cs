using AutoMapper;
using DataLayer;
using DTO;

namespace ApiProject
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Product, ProductDTO>().ForMember(dest => dest.CategoryName, src => src.MapFrom(p=>p.Category.Name));
            CreateMap<User, UserDTO>();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Category , CategoryDTO>().ForMember(dest => dest.Amount, src => src.MapFrom(c=>c.Products.Count));
        }
    }
}
