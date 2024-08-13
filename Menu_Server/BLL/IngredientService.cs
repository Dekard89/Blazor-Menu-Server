using Menu_Repository;
using Menu_Server.Domain;

namespace Menu_Server.BLL
{
    public class IngredientService
    {
        public List<Ingredient>? Ingredients { get; set; }

        public Ingredient? Ingredient { get; set; }

        private readonly IRepository<Ingredient> _repository;
        public IngredientService(IRepository<Ingredient> repository)
        {
            _repository = repository;
        }

        public async Task LoadFromDB()
        {
            Ingredients = await _repository.GetAll();
        }
        private List<Ingredient> TakeDiffererent()
        {
            var diff = Ingredients.Where(x => x.Id == 0).ToList();

            return diff;
        }
        public void UploadToDB()
        {
            if(TakeDiffererent().Count>0)
            {
                foreach (var item in TakeDiffererent())
                {
                    _repository.AddAsync(item);
                }
            }
            
        }
        public void UpdateAll()
        {
            if (Ingredients.Count > 0)
            {
                foreach (var item in Ingredients)
                {
                    _repository.UpdateAsync(item);
                }
            }
        }
    }
}
