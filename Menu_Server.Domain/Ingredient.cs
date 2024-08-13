using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Server.Domain
{
    public class Ingredient : BaseEntity, ICloneable
    {
        [Required(ErrorMessage = "Requred field")]
        [Range(1, 100000, ErrorMessage = "Out of range")]
        public double Coast { get; set; }

        [Required(ErrorMessage = "Requred field")]
        [Range(1, 1000, ErrorMessage = "Out of range")]
        public int Qty { get; set; }
        
        public bool IsRequred { get; set; }

        public List<Recipe> Recipes { get; set; } = new();

        public object Clone()
        {
            return new Ingredient()
            {
                Id = this.Id,
                Name = this.Name,
                Coast = this.Coast,
                Qty = this.Qty,
                IsRequred = this.IsRequred,
                Recipes = this.Recipes
            };
        }
    }
}
