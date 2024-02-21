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
    public class OrderService : IService<OrderDto>
    {
        private readonly IRepository<Order> _repository;
        private readonly IMapper mapper;
        public OrderService(IRepository<Order> repository, IMapper map)
        {
            this._repository = repository;
            this.mapper = map;
        }

        public async Task Delete(int id)
        {
            await this._repository.Delete(id);
        }

        public async Task<OrderDto> Get(int id)
        {
            return mapper.Map<OrderDto>(await _repository.Get(id));

        }

        public async Task<List<OrderDto>> GetAll()
        {
            return mapper.Map<List<OrderDto>>(await _repository.GetAll());

        }

        public async Task Post(OrderDto item)
        {
           await this._repository.Post(mapper.Map<Order>(item));
           
        }

        public async Task Put(int id, OrderDto item)
        {
            await _repository.Put(id, mapper.Map<Order>(item));
        }
    }
}

