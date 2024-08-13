using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Server.Domain
{
    public class Recipe : BaseEntity
    {
        public TimeSpan TimeToCook { get; set; }
       

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }
        [Required]
        public Category Category { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new();

        public bool CheckRequred()
        {
             return Ingredients.Where(i=>i.IsRequred.Equals(true)).Any(x=>x.Qty>0);
        }
        
    }
}
