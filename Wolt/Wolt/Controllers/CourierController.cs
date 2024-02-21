using Common.EntityDto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wolt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourierController : ControllerBase
    {
        private readonly IService<CourierDto> service;
        public CourierController(IService<CourierDto> service)
        {
            this.service = service;
        }
        // GET: api/<CourierController>
        [HttpGet]
        public async Task< List<CourierDto>> Get()
        {
            return await service.GetAll();
        }

        // GET api/<CourierController>/5
        [HttpGet("{id}")]
        public async Task< CourierDto> Get(int id)
        {
            return await service.Get(id);
        }

        // POST api/<CourierController>
        [HttpPost]
        public async Task Post([FromBody] CourierDto courierDto)
        {
           await service.Post(courierDto);
        }

        // PUT api/<CourierController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] CourierDto courierDto)
        {
           await service.Put(id, courierDto);
        }

        // DELETE api/<CourierController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await service.Delete(id);
        }
    }
}
