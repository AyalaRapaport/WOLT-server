using Common.EntityDto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wolt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService<UserDto> service;
        public UserController(IService<UserDto> service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            return await service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<UserDto> Get(int id)
        {
            return await service.Get(id);
        }

        //public async Task<UserDto> GetById(int id)
        //{
        //    return await service.Get(id);
        //}

        [HttpPost]
        public async Task Post([FromBody] UserDto userDto)
        {
            await service.Post(userDto);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UserDto value)
        {
            await service.Put(id, value);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.Delete(id);
        }
    }
}
