//using AutoMapper;
using Common.EntityDto;
using Microsoft.Extensions.DependencyInjection;
using Reposiroty.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public static class ServiceExtention
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepository();
            services.AddScoped(typeof(IService<CourierDto>), typeof(CourierService));
            services.AddScoped(typeof(IService<CategoryDto>), typeof(CategoryService));
            services.AddScoped(typeof(IService<OrderDto>), typeof(OrderService));
            services.AddScoped(typeof(IService<StoreDto>), typeof(StoreService));
            services.AddScoped(typeof(IService<ProductDto>), typeof(ProductService));
            services.AddScoped(typeof(IService<UserDto>), typeof(UserService));
            services.AddAutoMapper(typeof(MapperProfile));
            return services;
        }
    }
}
