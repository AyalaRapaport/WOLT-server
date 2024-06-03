using Microsoft.EntityFrameworkCore;
using Reposiroty.Entity;
using Reposiroty.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiroty.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly IContext _context;
        public ProductRepository(IContext context)
        {
            this._context = context;
        }
        public async Task Delete(int id)
        {
            _context.Products.Remove(await Get(id));
            await _context.save();
        }

        public async Task<Product> Get(int id)
        {
            return await this._context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Product>> GetAll()
        {
            return await this._context.Products.ToListAsync();
        }

        public async Task<Product> Post(Product item)
        {
            await this._context.Products.AddAsync(item);
            await this._context.save();
            return item;
        }

        public async Task<Product> Put(int id, Product item)
        {
            var product = await Get(id);
            product.Name = item.Name;
            product.Price = item.Price;
            product.CategoryId = item.CategoryId;
            product.StoreId = item.StoreId;
            product.Description = item.Description;
            product.UrlImage = item.UrlImage;
            await this._context.save();
            return product; 
        }
    }
}
