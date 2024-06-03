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
    public class UserRepository:IRepository<User>
    {
        private readonly IContext _context;
        public UserRepository(IContext context)
        {
            this._context = context;
        }

        public async Task Delete(int id)
        {
            _context.Users.Remove(await Get(id));
            await _context.save();
        }

        public async Task<User> Get(int id)
        {
            //return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return await _context.Users.FirstOrDefaultAsync(x => x.IdUser == id.ToString()||x.IdUser== ("0" + id.ToString()));
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Post(User item)
        {
            await _context.Users.AddAsync(item);
            await _context.save();
            return item;
        }

        public async Task<User> Put(int id, User item)
        {
            User user = await Get(id);
            user.IdUser= item.IdUser;
            user.Name = item.Name;
            user.Email = item.Email;
            user.XCoordinate= item.XCoordinate; 
            user.YCoordinate= item.YCoordinate;
            user.Password = item.Password;
            await _context.save();
            return user;    
        }
    }
}
