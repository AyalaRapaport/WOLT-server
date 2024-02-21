using Microsoft.Extensions.DependencyInjection;
using Reposiroty.Entity;
using Reposiroty.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiroty.Repositories
{
    public static class RepositoryExtention
    {
        public static IServiceCollection AddRepository( this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<Order>),typeof(OrdersRepository)); 
            services.AddScoped(typeof(IRepository<Category>),typeof(CategoryRepository)); 
            services.AddScoped(typeof(IRepository<Courier>),typeof(CourierRepository)); 
            services.AddScoped(typeof(IRepository<Store>),typeof(StoreRepository)); 
            services.AddScoped(typeof(IRepository<Product>),typeof(ProductRepository));
            services.AddScoped(typeof(IRepository<User>), typeof(UserRepository));

            return services;
        }
    }
}
