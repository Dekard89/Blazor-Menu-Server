using Menu_Server.Domain;

namespace Menu_Server.BLL.DTO
{
    public static class Mapper
    {

        public static DishModel GetDish(Recipe recipe)
        {
            var model = new DishModel();

            model.Id = recipe.Id;

            model.Name = recipe.Name;

            model.Image = recipe.Image;

            model.Category= recipe.Category;

            model.IsAvailable = SetAvailable(recipe.Ingredients);

            model.AvailableQuantity = recipe.Ingredients.Where(x => x.IsRequred.Equals(true))
                .Min(i => i.Qty);

            model.ExtraIngredients=recipe.Ingredients.Where(x=>x.IsRequred.Equals(false))
                .Select(x => new IngredientDTO(x)).ToList();

            model.Price = recipe.Ingredients.Sum(x => x.Price) * 1.9;

            model.TimeToCook = recipe.TimeToCook;

            return model;
        }

        private static bool SetAvailable(List<Ingredient> ingredients)
        {
            if (ingredients.Count == 0)
                return false;
            else
                return ingredients.Where(x => x.IsRequred).Any(i => i.Qty != 0);
        }
    }
}
