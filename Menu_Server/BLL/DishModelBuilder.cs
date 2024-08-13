using Menu_Server.Domain;

namespace Menu_Server.BLL
{
    public class DishModelBuilder : IDishBuilder
    {
        public Recipe? Recipe { get; set; }

        private readonly DishModel _dishModel;

        public DishModelBuilder()
        {

            _dishModel = new DishModel();
        }
        public IDishBuilder BuildExtras()
        {
            _dishModel.ExtraIngredients = Recipe.Ingredients.Where(I => I.IsRequred.Equals(false))
                .Where(x => x.Qty > 0).ToArray();

            return this;
        }

        public IDishBuilder BuildMain()
        {
            _dishModel.Id = Recipe.Id;
            _dishModel.Name= Recipe.Name;
            _dishModel.Image= Recipe.Image;
            _dishModel.TimeToCook= Recipe.TimeToCook;

            return this;
        }

        public IDishBuilder BuildPrice()
        {
            _dishModel.Price = Recipe.Ingredients.Where(x=>x.IsRequred.Equals(true))
                .Sum(x => x.Coast) * 1.9;

            return this;
        }

        public IDishBuilder SeTAvailable()
        {
            _dishModel.IsAvailable = ZeroCheckIngredientsCount();

            return this;
        }

        public DishModel GetDish()
        {
            return _dishModel;
        }

        private bool ZeroCheckIngredientsCount()
        {
            var requred = Recipe.Ingredients.Where(x=>x.IsRequred.Equals(true)).ToList();

            return requred.Any(i=>i.Qty==0)? true: false;
        }
    }
}
