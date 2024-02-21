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
            return await _context.Users.FirstOrDefaultAsync(x => x.IdUser == id.ToString());
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Post(User item)
        {
            await _context.Users.AddAsync(item);
            await _context.save();
        }

        public async Task Put(int id, User item)
        {
            User user = await Get(id);
            if(item.IdUser!="string")
            user.IdUser= item.IdUser;
            if(item.Name!="string")
            user.Name = item.Name;
            if(item.Email!="string") 
            user.Email = item.Email;
            if(item.XCoordinate!=0)
            user.XCoordinate= item.XCoordinate; 
            if(item.YCoordinate!=0)
            user.YCoordinate= item.YCoordinate; 
            await _context.save();
        }
    }
}
