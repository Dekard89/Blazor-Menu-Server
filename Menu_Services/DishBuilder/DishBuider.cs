using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Services.DishBuilder
{
    public class DishBuider : IDishBuilder
    {
        public Dish Dish { get; set; }= new Dish();

        public RecipeVM Recipe { get; set; }

        public IDishBuilder AddExtraIngredient(IngredientVM ingredient)
        {
            throw new NotImplementedException();
        }

        public IDishBuilder BuildMain()
        {
            Dish.Image=Recipe.Image;

            Dish.Name=Recipe.Name;

            Dish.TimeToCook=Recipe.TimeToCook;

            Dish.Id=Recipe.Id;

            Dish.Ingredients = Recipe.ExtraIngredients;

            return this;
        }

        public IDishBuilder BuildPrice()
        {
            throw new NotImplementedException();
        }

        public Dish GetDish()
        {
            throw new NotImplementedException();
        }
    }
}
