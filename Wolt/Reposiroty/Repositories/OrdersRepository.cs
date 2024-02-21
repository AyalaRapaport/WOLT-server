using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reposiroty.Interfaces;
using Reposiroty.Entity;
using Microsoft.EntityFrameworkCore;

namespace Reposiroty.Repositories
{
    class OrdersRepository:IRepository<Order>
    {
        private readonly IContext _context;
        public OrdersRepository(IContext context)
        {
            this._context = context;    
        }
        

        public async Task Delete(int id)
        {
            this._context.Orders.Remove(await Get(id));
            await _context.save();
        }

        public async Task<List<Order>>GetAll()
        {
            return await this._context.Orders.ToListAsync();
        }

        public async Task<Order> Get(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);    
        }

        public async Task Post(Order item)
        {
          await  this._context.Orders.AddAsync(item);
           await this._context.save();
        }

        public async Task Put(int id, Order entity)
        {
            var order=await Get(id);
            order.OrderingName = entity.OrderingName;
            order.XCoordinate= entity.XCoordinate;
            order.YCoordinate= entity.YCoordinate;
            order.StoreId = entity.StoreId;
            this._context.save();
        }
    }
}
