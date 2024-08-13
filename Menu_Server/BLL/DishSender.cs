using Menu_Server.Domain;
using Menu_Server.Domain.Migrations;

namespace Menu_Server.BLL
{
    public class DishSender
    {
        private readonly DishDirector _director;

        

        public DishSender(DishDirector director)
        {
                _director=director;
        }
        public List<DishModel> GetDishModelsWihoutExtras(List<Recipe> recipes)
        {
            return  recipes.Where(r => r.CheckRequred().Equals(true))
                .Where(x=>x.Ingredients.Any(i=>i.IsRequred.Equals(false).Equals(false)))
                .Select(x =>
            {
                _director.SetRecipe(x);
                return _director.BuildWihoutExtras();
            }).ToList();
        }
        public List<DishModel> GetDishModelsWihotExtras(List<Recipe> recipes)
        {
            return recipes.Where(r => r.CheckRequred().Equals(true))
                .Where(x => x.Ingredients.Any(i => i.IsRequred.Equals(false).Equals(true)))
                .Select(x =>
                {
                    _director.SetRecipe(x);
                    return _director.BuildWithExtras();
                }).ToList();
        }
        public List<DishModel> GetNotAvailable(List<Recipe> recipes)
        {
            return recipes.Where(r=>r.CheckRequred().Equals(false))
                .Select(x =>
                {
                    _director.SetRecipe(x);
                    return _director.BuildNotAvailable();
                }).ToList() ;
        }
    }
}
