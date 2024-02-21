using AutoMapper;
using Common.EntityDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Reposiroty.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<Courier, CourierDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();               
            CreateMap<Store, StoreDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }

    }
}
