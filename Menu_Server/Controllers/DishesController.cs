using Menu_Repository;
using Menu_Server.BLL;
using Menu_Server.BLL.Contracts;
using Menu_Server.BLL.DTO;
using Menu_Server.Domain;
using Menu_Server.Domain.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Menu_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly DishSender _sender;

        private readonly IMemoryCache _cache;
        public DishesController(DishSender dishSender, IMemoryCache memoryCache)
        {
                _sender = dishSender; 
            _cache = memoryCache;
        }

        //[HttpGet]
        //[Route("get")]
        //public async Task<List<DishModel>> GetDishes()
        //{
            
        //}
        [HttpGet("request")]
        public async Task<List<DishModel>> GetAllDishes([FromQuery]DishRequest request) 
        {
            var result= await _sender.GetMenu(request);

            return result;
        }
        

        [HttpPost("post")]
       
        public IActionResult PostOrder( [FromBody] OrderDTO dto)
        {
            var list= new List<OrderDTO>();
            list.Add(dto);
            _cache.Set("all", list, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
            return Ok();
        }
    }
}
