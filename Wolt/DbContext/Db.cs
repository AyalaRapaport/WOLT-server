using Microsoft.EntityFrameworkCore;
using Reposiroty.Entity;
using Reposiroty.Interfaces;

namespace DataContext
{
    public class Db : DbContext,IContext
    {
        public DbSet<Courier> Couriers  { get ; set ; }
        public DbSet<Store> Stores  { get ; set ; } 
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders{ get; set; } 
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get ; set; }

        public async Task save()
        {
          await SaveChangesAsync();  
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=wolt3;Integrated Security=True");

            //optionsBuilder.UseSqlServer("Server=WIN-ADMIN1\\MSSQLSERVEROK;Database=wolt1;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("Server=WIN-ADMIN1\\MSSQLSERVEROK;Database=wolt2;Trusted_Connection=True;");

        }
    }
}