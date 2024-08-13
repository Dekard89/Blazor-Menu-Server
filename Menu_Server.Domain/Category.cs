using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Server.Domain
{
    public enum Category
    {
        [Display(Name = "Basic")] Basic,

        [Display(Name = "Salad")] Salad,

        [Display(Name = "Dessert")] Dessert,

        [Display(Name = "Drink")] Drink
    }
}
