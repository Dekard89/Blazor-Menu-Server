using Menu_Server.BLL.DTO;
using Menu_Server.Domain;

namespace Menu_Server.BLL
{
    public class DishModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public double Price { get; set; }

        public Category Category { get; set; }

        public List<IngredientDTO>? ExtraIngredients { get; set; }

        public TimeSpan TimeToCook { get; set; }

        public bool IsAvailable { get; set; }

        public int AvailableQuantity { get; set; }

        public string AppendName(string str) => Name += $"/n with {0}";
    }
}
