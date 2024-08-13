using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Services.DishBuilder
{
    public interface IDishBuilder
    {
        public IDishBuilder BuildMain();

        public IDishBuilder BuildPrice();

        public IDishBuilder AddExtraIngredient(IngredientVM ingredient);

        public Dish GetDish();
    }
}
