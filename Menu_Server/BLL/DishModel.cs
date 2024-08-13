using Menu_Server.Domain;

namespace Menu_Server.BLL
{
    public class DishModel
    {
        public int Id { get; set; }

        public string Name { get; set; }=String.Empty;

        public string Image { get; set; } = String.Empty;

        public double Price { get; set; }

        public Category Category { get; set; }

        public Ingredient[]? ExtraIngredients { get; set; }

        public TimeSpan TimeToCook { get; set; }

        public bool IsAvailable { get; set; }

        public string AppendName(string str) => Name += $"/n with {0}";
    }
}
