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
    public class CategoryRepository : IRepository<Category>
    {
        private readonly IContext _context;
        public CategoryRepository(IContext context)
        {
            this._context = context;
        }

        public async Task Delete(int id)
        {
         _context.Categories.Remove(await Get(id));
            await _context.save();
        }

        public async Task<Category> Get(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task Post(Category item)
        {
            await _context.Categories.AddAsync(item);
            await _context.save();
        }

        public async Task Put(int id, Category item)
        {
           Category category = await Get(id);
            category.Name = item.Name;
            category.UrlImage = item.UrlImage;
            await _context.save();
        }
    }
}
