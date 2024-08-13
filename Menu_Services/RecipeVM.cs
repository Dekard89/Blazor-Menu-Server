using Menu_Server.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Services
{
     public class RecipeVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="REQURED FIELD")]
        [StringLength(maximumLength:50,MinimumLength =1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "REQURED FIELD")]
        public string Description { get; set; }

        [Required(ErrorMessage = "REQURED FIELD")]
        public TimeSpan TimeToCook { get; set; }

        public string Image {  get; set; }

        public bool IsActive { get; set; }= true;

        public CategoryVM Category { get; set; }

        public List<IngredientVM> RequredIngredints { get; set; } = new();

        public List<IngredientVM> ExtraIngredients {  get; set; } = new();

        public RecipeVM()
        {
                
        }
        public RecipeVM(Recipe dto)
        {
            Id = dto.Id;

            Name=dto.Name;

            Description=dto.Description;

            TimeToCook = dto.TimeToCook;

            Image = dto.Image;

            Category=(CategoryVM)dto.Category;

            RequredIngredints.AddRange(dto.Ingredients.Where(x=>x.IsRequred=true).Select(i=>new IngredientVM(i)).ToList());

            ExtraIngredients.AddRange(dto.Ingredients.Where(x=>x.IsRequred=false).Select(i=>new IngredientVM(i)).ToList());
        }
    }
}
