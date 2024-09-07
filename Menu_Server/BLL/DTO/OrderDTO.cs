namespace Menu_Server.BLL.DTO
{
    public class OrderDTO
    {
        public int TableNumber { get; set; }

        public List<DishDto> DishDtos { get; set; } = new();

        public DishDto GetDish(int id) => DishDtos.FirstOrDefault(x => x.Id == id);
    }
}
