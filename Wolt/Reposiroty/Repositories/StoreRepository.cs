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
    public class StoreRepository : IRepository<Store>
    {
        private readonly IContext _context;
        public StoreRepository(IContext context)
        {
            this._context = context;
        }
        public async Task Delete(int id)
        {
            this._context.Stores.Remove(await Get(id));
            _context.save();
        }

        public async Task<Store> Get(int id)
        {
            return await this._context.Stores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Store>> GetAll()
        {
            return await this._context.Stores.ToListAsync();
        }

        public async Task Post(Store item)
        {
            await this._context.Stores.AddAsync(item);
            await this._context.save();
        }

        public async Task Put(int id, Store item)
        {
            var store =await Get(id);
            store.Name = item.Name;
            store.XCoordinate = item.XCoordinate;
            store.YCoordinate = item.YCoordinate;
            store.Password = item.Password;
            this._context.save();

        }
    }
}
