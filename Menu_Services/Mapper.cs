using Menu_Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Services
{
    public static class Mapper
    {
        public static Recipe RecipeMapping(RecipeVM vm)
        {
            Recipe dto = new Recipe();

            dto.Id = vm.Id;

            dto.Name = vm.Name;

            dto.Description = vm.Description;

            dto.Category=(Category)vm.Category;

            dto.Image=vm.Image;

            dto.TimeToCook=vm.TimeToCook;

            dto.Ingredients.AddRange(vm.RequredIngredints.Select(x => IngredientMapping(x)).ToList());

            dto.Ingredients.AddRange(vm.ExtraIngredients.Select(x=> IngredientMapping(x)).ToList());

            return dto;
        }
        public static Ingredient IngredientMapping( IngredientVM vm )
        {
            Ingredient dto = new Ingredient();
            
            dto.Id = vm.Id;

            dto.Name = vm.Name;

            dto.Qty= vm.Qty;

            dto.Coast= vm.Coast;

            dto.IsRequred= vm.IsRequred;

            return dto;
        }
    }
}
