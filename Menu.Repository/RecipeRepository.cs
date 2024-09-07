using Menu_Server.Domain;
using Microsoft.EntityFrameworkCore;

namespace Menu_Repository
{
    public class RecipeRepository : IRepository<Recipe>
    {
        private readonly AppDBContext _db;

        public RecipeRepository(AppDBContext context)
        {
            _db = context;
        }
        public async Task AddAsync(Recipe entity)
        {
            await _db.Recipes.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Recipe entity)
        {
           _db.Recipes.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Recipe>> GetAll()
        {
            return _db.Recipes.Include(r=>r.Ingredients).ToList();
                
        }

        public async Task<Recipe> GetById(int id)
        {
            Recipe recipe = _db.Recipes.FirstOrDefault(x => x.Id == id);
                

            return recipe;
        }

        public async Task UpdateAsync(Recipe entity)
        {
            _db.Recipes.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(List<Recipe> entitys)
        {
            _db.Recipes.UpdateRange(entitys);
            await _db.SaveChangesAsync();
        }
    }
}
