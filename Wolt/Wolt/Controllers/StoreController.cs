using Common.EntityDto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wolt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {

        private readonly IService<StoreDto> service;
        public StoreController(IService<StoreDto> service)
        {
            this.service = service;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<StoreDto>> Get()
        {
            return await service.GetAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<StoreDto> Get(int id)
        {
            return await service.Get(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task Post([FromBody] StoreDto storeDto)
        {
            await service.Post(storeDto);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] StoreDto value)
        {
            await service.Put(id, value);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.Delete(id);
        }
    }
}
