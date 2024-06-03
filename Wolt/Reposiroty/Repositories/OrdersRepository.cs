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
    class OrdersRepository : IRepository<Order>
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

        public async Task<List<Order>> GetAll()
        {
            return await this._context.Orders
                .Include(order => order.Store)
                .Include(order => order.User)
                .ToListAsync();
        }

        public async Task<Order> Get(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Order> Post(Order item)
        {
            await this._context.Orders.AddAsync(item);
            await this._context.save();
            return item;
        }

        public async Task<Order> Put(int id, Order entity)
        {
            var order = await Get(id);
            order.UserId = entity.UserId;
            order.XCoordinate = entity.XCoordinate;
            order.YCoordinate = entity.YCoordinate;
            order.StoreId = entity.StoreId;
            order.IsTaken = entity.IsTaken;   
            order.OrderDate = entity.OrderDate; 
            order.IsDone=entity.IsDone; 
            this._context.save();
            return entity;
        }
    }
}
