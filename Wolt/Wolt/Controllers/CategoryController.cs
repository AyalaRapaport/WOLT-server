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
    public class CategoryController : ControllerBase
    {

        private readonly IService<CategoryDto> service;
        public CategoryController(IService<CategoryDto> service)
        {
            this.service = service;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<CategoryDto>> Get()
        {
            var categories = await service.GetAll();
            foreach (var c in categories)
            {
                c.UrlImage = GetImage(c.UrlImage);
            }
            return categories;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<CategoryDto> Get(int id)
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
        public async Task<ActionResult> Post([FromForm] CategoryDto categoryDto)
        {
            var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/" + categoryDto.Image.FileName);
            Console.WriteLine("myPath: " + myPath);

            using (FileStream fs = new FileStream(myPath, FileMode.Create))
            {
                categoryDto.Image.CopyTo(fs);
                fs.Close();
            }
            categoryDto.UrlImage = categoryDto.Image.FileName;
            return Ok(await service.Post(categoryDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] CategoryDto categoryDto)
        {
            var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/" + categoryDto.Image.FileName);
            Console.WriteLine("myPath: " + myPath);

            using (FileStream fs = new FileStream(myPath, FileMode.Create))
            {
                categoryDto.Image.CopyTo(fs);
                fs.Close();
            }
            categoryDto.UrlImage = categoryDto.Image.FileName;
           return Ok (await service.Put(id, categoryDto));
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
          await  service.Delete(id);
        }
    }
}
