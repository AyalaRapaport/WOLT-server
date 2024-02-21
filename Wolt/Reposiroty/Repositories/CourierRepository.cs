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
    public class CourierRepository : IRepository<Courier>
    {
        private readonly IContext _context;
        public CourierRepository(IContext context)
        {
            this._context = context;
        }
        public async Task Delete(int id)
        {
            _context.Couriers.Remove(await Get(id));
            await _context.save();
        }

        public async Task<Courier> Get(int id)
        {
            return await _context.Couriers.FirstOrDefaultAsync(x => x.IdCourier == id.ToString());
        }

        public async Task<List<Courier>> GetAll()
        {
            return await this._context.Couriers.ToListAsync();
        }

        public async Task Post(Courier item)
        {
            await this._context.Couriers.AddAsync(item);
            await this._context.save();
        }

        public async Task Put(int id, Courier item)
        {
            var courier = await Get(id);
            courier.IdCourier = item.IdCourier;
            courier.Name = item.Name;
            courier.XCoordinate = item.XCoordinate;
            courier.YCoordinate = item.YCoordinate;
            courier.IsActive = item.IsActive;
            courier.Email = item.Email;
            courier.Phone = item.Phone;
            await _context.save();
        }
    }
}
