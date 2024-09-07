using Menu_Server.Domain;

namespace Menu_Server.BLL.DTO
{
    public record IngredientDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Qty { get; set; }

        public double Price { get; set; }

        public IngredientDTO(Ingredient ingredient)
        {
                Id = ingredient.Id;

            Name = ingredient.Name;

            Qty = ingredient.Qty;

            Price = ingredient.Price;
        }

       
    }
        
    

    
}
