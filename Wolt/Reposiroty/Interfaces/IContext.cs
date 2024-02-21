using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Reposiroty.Entity;
using Microsoft.EntityFrameworkCore;

namespace Reposiroty.Interfaces
{
    public interface IContext
    {
        public DbSet<Courier>Couriers { get; set; }
        public DbSet<Store>Stores { get; set; }
        public DbSet<Product>Products { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<User>Users { get; set; }

        public Task save();
    }
}
