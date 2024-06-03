using AutoMapper;
using Common.EntityDto;
using Reposiroty.Entity;
using Reposiroty.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService:IService<UserDto>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper mapper;
        public UserService(IRepository<User> repository, IMapper map)
        {
            this._repository = repository;
            this.mapper = map;
        }

        public async Task Delete(int id)
        {
           await this._repository.Delete(id);
        }

        public async Task<UserDto> Get(int id)
        {
            return mapper.Map<UserDto>(await _repository.Get(id));

        }
 

        public async Task<List<UserDto>> GetAll()
        {
            return mapper.Map<List<UserDto>>(await _repository.GetAll());

        }

        public async Task<UserDto> Post(UserDto item)
        {
            return mapper.Map<UserDto>(await this._repository.Post(mapper.Map<User>(item)));
        }

        public async Task<UserDto> Put(int id, UserDto item)
        {
            return mapper.Map<UserDto>(await _repository.Put(id, mapper.Map<User>(item)));
        }
    }
}
