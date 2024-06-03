using Common.EntityDto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
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
            var stores = await service.GetAll();
            foreach (var s in stores)
            {
                s.UrlImage = GetImage(s.UrlImage);
                foreach (var p in s.ProductList)
                {
                    p.UrlImage = GetImage(p.UrlImage);
                }

            }
            return stores;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<StoreDto> Get(int id)
        {
            return await service.Get(id);
        }

        [HttpGet("getImage/{ImageUrl}")]
        public string GetImage(string ImageUrl)
        {
            var path = Path.Combine(Environment.CurrentDirectory + "/Images/", ImageUrl);
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            string imageBase64 = Convert.ToBase64String(bytes);
            string image = string.Format("data:image/jpeg;base64,{0}", imageBase64);
            return image;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] StoreDto storeDto)
        {
            var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/" + storeDto.Image.FileName);

            using (FileStream fs = new FileStream(myPath, FileMode.Create))
            {
                storeDto.Image.CopyTo(fs);
                fs.Close();
            }
            storeDto.UrlImage = storeDto.Image.FileName;
           return Ok( await service.Post(storeDto));
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromForm] StoreDto value)
        {
             var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/" + value.Image.FileName);
            Console.WriteLine("myPath: " + myPath);

            using (FileStream fs = new FileStream(myPath, FileMode.Create))
            {
                value.Image.CopyTo(fs);
                fs.Close();
            }
            value.UrlImage = value.Image.FileName;
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
