using Menu_Server.Domain;

namespace Menu_Server.BLL.Contracts
{
    public record DishRequest(Category Category, string Search);
    
}
