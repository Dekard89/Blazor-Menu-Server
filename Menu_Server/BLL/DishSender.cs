using System.Linq;
using Menu_Repository;
using Menu_Server.BLL.Contracts;
using Menu_Server.BLL.DTO;
using Menu_Server.Domain;


namespace Menu_Server.BLL
{
    public class DishSender
    {
        private readonly IRepository<Recipe> _repository;

        public DishSender(IRepository<Recipe> repository)
        {
            _repository = repository;
        }
        public async Task<List<DishModel>> GetMenu( DishRequest dishRequest )
        {
            var recipes = await _repository.GetAll();

            var categoryRecipe=recipes.Where(x=>x.Category==dishRequest.Category).ToList();

            var result = dishRequest.Search == "all" ? categoryRecipe : categoryRecipe.Where(x=>x.Name.ToLower()
            .Contains(dishRequest.Search));

            return result.Select(x => Mapper.GetDish(x))
                .Where(x=>x.IsAvailable==true) .ToList();
            
        }
    }
}
