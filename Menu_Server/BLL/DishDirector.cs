using Menu_Server.Domain;

namespace Menu_Server.BLL
{
    public class DishDirector
    {
        private readonly IDishBuilder _builder;

        public DishDirector(IDishBuilder dishBuilder)
        {
            _builder=dishBuilder;
        }
        public DishModel BuildWihoutExtras()
        {
            
           _builder.BuildMain().SeTAvailable().BuildPrice();

            return _builder.GetDish();
            
        }
        public DishModel BuildWithExtras()
        {
            _builder.BuildMain().SeTAvailable().BuildPrice().BuildExtras();

            return _builder.GetDish();
        }
        public DishModel BuildNotAvailable()
        {
            _builder.BuildMain().SeTAvailable();

            return _builder.GetDish();
        }
        public void SetRecipe(Recipe recipe)
        {
            _builder.Recipe=recipe;
        }
    }
}
