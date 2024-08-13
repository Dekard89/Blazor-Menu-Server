using Menu_Server.Domain;

namespace Menu_Server.BLL
{
    public interface IDishBuilder
    {
        Recipe Recipe { set; }
        IDishBuilder BuildMain();

        IDishBuilder BuildPrice();

        IDishBuilder BuildExtras();

        IDishBuilder SeTAvailable();

        
       DishModel GetDish();


    }
}
