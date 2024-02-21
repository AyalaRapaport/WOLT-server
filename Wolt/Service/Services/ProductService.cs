using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.EntityDto;
using System.IO;
using Reposiroty.Entity;
using Reposiroty.Interfaces;
using Service.Interfaces;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;
namespace Service.Services

{
    class ProductService : IService<ProductDto>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper mapper;
        public ProductService(IRepository<Product> repository, IMapper map)
        {
            this._repository = repository;
            this.mapper = map;
        }

        public async Task Delete(int id)
        {
            await this._repository.Delete(id);
        }

        public async Task<ProductDto> Get(int id)
        {
            return mapper.Map<ProductDto>(await _repository.Get(id));

        }

        public async Task<List<ProductDto>> GetAll()
        {
            return mapper.Map<List<ProductDto>>(await _repository.GetAll());

        }

        public async Task Post(ProductDto item)
        {
            await _repository.Post(mapper.Map<Product>(item));

        }

        public async Task Put(int id, ProductDto item)
        {
            await _repository.Put(id, mapper.Map<Product>(item));
        }
    }
}


