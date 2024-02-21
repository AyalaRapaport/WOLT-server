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
    public class ProductController : ControllerBase
    {

        private readonly IService<ProductDto> service;
        public ProductController(IService<ProductDto> service)
        {
            this.service = service;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<ProductDto>> Get()
        {
            return await service.GetAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id)
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
        public async Task Post([FromForm] ProductDto productDto)
        {

            var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/" + productDto.Image.FileName);

            using (FileStream fs = new FileStream(myPath, FileMode.Create))
            {
                productDto.Image.CopyTo(fs);
                fs.Close();
            }
            productDto.UrlImage = productDto.Image.FileName;
            await service.Post(productDto);

            //return Ok(productDto);

            //catch (Exception ex)
            //{
            //    return NotFound();
            //}
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromForm] ProductDto value)
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
