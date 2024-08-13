using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Services
{
    public enum CategoryVM
    {
        [Display(Name ="Basic dish")] Basic,

        [Display(Name ="Salad")] Salad,

        [Display(Name ="Dessert")] Desert,

        [Display(Name ="Drink")] Drink
       
    }
}
