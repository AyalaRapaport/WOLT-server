using Common.EntityDto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using MimeKit;
using MailKit.Security;
using MailKit.Net.Smtp;
using System.Net;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Reposiroty.Entity;
using Microsoft.EntityFrameworkCore;
using Reposiroty.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wolt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IService<OrderDto> service;
        private readonly IService<ProductDto> serviceP;

        public OrderController(IService<OrderDto> service, IService<ProductDto> sP)
        {
            this.service = service;
            this.serviceP = sP;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<OrderDto>> Get()
        {
            return await service.GetAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<OrderDto> Get(int id)
        {
            return await service.Get(id);
        }

        [HttpPost]
        public async Task Post([FromBody] OrderDto orderDto)
        {
            
            await SendEmailToUser(orderDto);
            await service.Post(orderDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrderDto value)
        {
          return Ok( await service.Put(id, value));
            
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.Delete(id);
        }
        private async Task SendEmailToUser(OrderDto order)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync("moveappdriver@gmail.com", "wnxl xcik hptq xusj");
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Wolt", "moveappdriver@gmail.com"));
                    message.To.Add(MailboxAddress.Parse(order.User.Email));
                    message.Subject = "פרטי הזמנה wolt ";

                    StringBuilder bodyBuilder = new StringBuilder();
                    bodyBuilder.AppendLine("Products:");

                    foreach (var product in order.ProductsIds)
                    {
                        ProductDto p = await serviceP.Get(product);
                        bodyBuilder.AppendLine($"{p.Name}: {p.Price + "₪"}");

                        //var imageSource = await GetEmbeddedImageSource(p.UrlImage);
                        //var image = $@"<img src='{imageSource}' alt='Product Image' />";
                        //bodyBuilder.AppendLine(image);
                    }

                    message.Body = new TextPart("html")
                    {
                        Text = bodyBuilder.ToString()
                    };

                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);

                    Console.WriteLine("Mail Sent Successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
        }

        private async Task<string> GetEmbeddedImageSource(string url)
        {
            //using (var httpClient = new HttpClient())
            //{
            //    byte[] bytes = await httpClient.GetByteArrayAsync(url);
            //    string imageBase64 = Convert.ToBase64String(bytes);
            //    string image = string.Format("data:image/jpeg;base64,{0}", imageBase64);
            //    return image;
            //}
            var path = Path.Combine(Environment.CurrentDirectory + "/Images/", url);
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            string imageBase64 = Convert.ToBase64String(bytes);
            string image = string.Format("data:image/jpeg;base64,{0}", imageBase64);
            return image;
        }
    }
}
