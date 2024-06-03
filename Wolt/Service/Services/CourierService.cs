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
    public class CourierService : IService<CourierDto>
    {
        private readonly IRepository<Courier> _repository;
        private readonly IMapper mapper;
        public CourierService(IRepository<Courier> repository, IMapper map)
        {
            this._repository = repository;
            this.mapper = map;
        }

        public async Task Delete(int id)
        {
          await this._repository.Delete(id);
        }

        public async Task<CourierDto> Get(int id)
        {
            return mapper.Map<CourierDto>(await _repository.Get(id));

        }

        public async Task< List<CourierDto>>GetAll()
        {
            return mapper.Map<List<CourierDto>>(await _repository.GetAll());

        }

        public async Task<CourierDto> Post(CourierDto item)
        {
            return mapper.Map<CourierDto>(await this._repository.Post(mapper.Map <Courier>(item)));
        }

        public async Task<CourierDto> Put(int id, CourierDto item)
        {
            return mapper.Map<CourierDto>(await  _repository.Put(id, mapper.Map<Courier>(item)));
        }
    }
}