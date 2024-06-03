using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.EntityDto;
using Newtonsoft.Json.Serialization;
using Reposiroty.Entity;
using Reposiroty.Interfaces;
using Service.Interfaces;
namespace Service.Services
{
    public class OrderService : IService<OrderDto>
    {
        private readonly IRepository<Order> _repository;
        private readonly IRepository<Product> repository1;
        private readonly IMapper mapper;
        public OrderService(IRepository<Order> repository,IRepository<Product> repP, IMapper map)
        {
            this._repository = repository;
            this.repository1 = repP;
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

        public async Task<OrderDto> Post(OrderDto item)
        {
            Order o=new Order();
            //o.OrderDate = item.OrderDate;
            o.YCoordinate= item.YCoordinate;    
            o.XCoordinate= item.XCoordinate;
            o.StoreId= item.StoreId;    
            o.IsDone= item.IsDone;
            o.UserId=item.UserId;
            o.Products=new List<Product>();
            foreach (var item1 in item.ProductsIds)
            {
                Product p = await repository1.Get(item1);
                o.Products.Add(p);
            }
            return mapper.Map<OrderDto>(await _repository.Post(o));
        }

        public async Task<OrderDto> Put(int id, OrderDto item)
        {
            return mapper.Map<OrderDto>(await _repository.Put(id, mapper.Map<Order>(item)));
        }
    }
}

