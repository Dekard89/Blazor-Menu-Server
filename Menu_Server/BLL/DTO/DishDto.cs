namespace Menu_Server.BLL.DTO
{
    public class DishDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; } = 1;

        public List<int>? IngredientIds { get; set; } = new();
    }
}
