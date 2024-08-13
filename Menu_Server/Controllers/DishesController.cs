using Menu_Repository;
using Menu_Server.BLL;
using Menu_Server.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Menu_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly DishSender _sender;
        private readonly IRepository<Recipe> _repository;

        public DishesController(DishSender dishSender, IRepository<Recipe> repository)
        {
                _sender = dishSender;
            _repository = repository;
        }

        [HttpGet]
        [Route("get")]
        public async Task<List<DishModel>> GetDishes()
        {
            var recipes= await _repository.GetAll();
            var dishes = _sender.GetDishModelsWihoutExtras(recipes);
            dishes.AddRange(_sender.GetDishModelsWihotExtras(recipes));
            return dishes;
        }
        [HttpGet]
        [Route("getall")]
        public async Task<List<DishModel>> GetAllDishes() 
        {
            var recipes = await _repository.GetAll();
            var dishes = _sender.GetDishModelsWihoutExtras(recipes);
            dishes.AddRange(_sender.GetDishModelsWihotExtras(recipes));
            dishes.AddRange(_sender.GetNotAvailable(recipes));
            return dishes;
        }

        [HttpPost]
       
        public IActionResult PostOrder( [FromBody]List<DishModel> dishModels)
        {
            return Ok(dishModels);
        }
    }
}
