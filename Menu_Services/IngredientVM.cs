using Menu_Server.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Services
{
    public class IngredientVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="REQURED FIELD")]
        [MaxLength(50)]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [Range(1,10000)]
        public double Coast { get; set; }
        
        public int Qty { get; set; } = 1;

        [Required]
        public bool IsRequred { get; set; }

        public IngredientVM() { }

        public IngredientVM( Ingredient dto)
        {
            Id=dto.Id;

            Name=dto.Name;

            Coast=dto.Coast;

            Qty=dto.Qty;

            IsRequred=dto.IsRequred;
        }
    }
}
