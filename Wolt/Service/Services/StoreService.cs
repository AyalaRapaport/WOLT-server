using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.EntityDto;
using Reposiroty.Entity;
using Reposiroty.Interfaces;
using Service.Interfaces;
namespace Service.Services
{
    class StoreService:IService<StoreDto>
    {
        private readonly IRepository<Store> _repository;
        private readonly IMapper mapper;
        public StoreService(IRepository<Store> repository, IMapper map)
        {
            this._repository = repository;
            this.mapper = map;
        }

        public async Task Delete(int id)
        {
           await this._repository.Delete(id);
        }

        public async Task< StoreDto> Get(int id)
        {
            return mapper.Map<StoreDto>(await _repository.Get(id));

        }
        
        public async Task< List<StoreDto>> GetAll()
        {
            return mapper.Map<List<StoreDto>>(await _repository.GetAll());

        }

        public async Task Post(StoreDto item)
        {
           await this._repository.Post(mapper.Map<Store>(item));
        }

        public async Task Put(int id, StoreDto item)
        {
           await _repository.Put(id, mapper.Map<Store>(item));
        }
    }
}
    

