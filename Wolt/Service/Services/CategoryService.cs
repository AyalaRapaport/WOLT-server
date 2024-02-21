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
   public class CategoryService:IService<CategoryDto>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper mapper;
        public CategoryService(IRepository<Category> repository, IMapper map)
        {
            this._repository = repository;
            this.mapper = map;
        }

        public async Task Delete(int id)
        {
            await this._repository.Delete(id);
        }

        public async Task <CategoryDto> Get(int id)
        {
            return mapper.Map<CategoryDto>(await _repository.Get(id));

        }

        public async Task< List<CategoryDto>> GetAll()
        {
            return mapper.Map<List<CategoryDto>>(await _repository.GetAll());

        }

        public async Task Post(CategoryDto item)
        {
           await this._repository.Post(mapper.Map<Category>(item));
        }

        public async Task Put(int id, CategoryDto item)
        {
          await  _repository.Put(id, mapper.Map<Category>(item));
        }
    }
}
    

