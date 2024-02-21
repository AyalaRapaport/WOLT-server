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
    public class OrderController : ControllerBase
    {
        private readonly IService<OrderDto> service;
        public OrderController(IService<OrderDto> service)
        {
            this.service = service;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task< List<OrderDto>> Get()
        {
            return await service.GetAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task< OrderDto> Get(int id)
        {
            return await service.Get(id);
        }

        [HttpPost]
        public async Task Post([FromBody] OrderDto orderDto)
        {
           await service.Post(orderDto);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] OrderDto value)
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
