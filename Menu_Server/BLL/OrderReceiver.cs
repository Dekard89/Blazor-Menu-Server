using Menu_Repository;
using Menu_Server.BLL.DTO;
using Menu_Server.Domain;

namespace Menu_Server.BLL
{
    public class OrderReceiver
    {
        private readonly IRepository<Recipe> _repository;


        public OrderReceiver(IRepository<Recipe> repository)
        {
            _repository = repository;

        }

     
        public async Task WriteOfIngredients(OrderDTO order,List<Recipe> recipes )
        {
            foreach(var recipe in recipes)
            {
                WriteOf(recipe, order);
            }
            await _repository.UpdateRangeAsync(recipes);
        }
        private void WriteOf(Recipe recipe, OrderDTO order)
        {
            var dish = order.DishDtos.FirstOrDefault(d => d.Id == recipe.Id);

            foreach ( var item in recipe.Ingredients)
            {
                if(item.IsRequred || dish.IngredientIds.Any(x=>x==item.Id))
                {
                    item.Qty = -dish.Count;
                }
            }
        }
        public List<Recipe> GetOrderedRecipe(OrderDTO order, List<Recipe> recipes)
        {
            var orderedRecipes = recipes.Where(x => order.DishDtos.Any(d => d.Id == x.Id)).ToList();
            
            var result= orderedRecipes.Select(x =>
            {
               var y= x.Clone() as Recipe;

                y.Name = order.DishDtos.FirstOrDefault(d => d.Id == y.Id).Name;

                return y;
            }).ToList();

            return result;
            
        }

    }
}
