using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Services.DishBuilder
{
    public class Dish
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public TimeSpan TimeToCook { get; set; }

        public string Image {  get; set; }

        public double Price { get; set; }

        public DateTime StartToCook { get; set; }

        public List<IngredientVM> Ingredients { get; set; }

        public DateTime ReadyTime 
        {
            get => ReadyTime;

            set => ReadyTime = StartToCook + TimeToCook;
        }
        public string AppendName(string str) => Name += $" with {str}\n";

        public double AppendPrice(double price) => Price += price;

        
    }
}
