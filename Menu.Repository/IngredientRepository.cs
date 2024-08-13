using Menu_Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Repository
{
    public class IngredientRepository : IRepository<Ingredient>
    {
        private readonly AppDBContext _db;

        public IngredientRepository(AppDBContext context)
        {
            _db=context;
        }
        public async Task AddAsync(Ingredient entity)
        {
            await _db.Ingredients.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Ingredient entity)
        {
            _db.Ingredients.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Ingredient>> GetAll()
        {
            return _db.Ingredients.ToList();
        }

        public async Task<Ingredient> GetById(int id)
        {
            return _db.Ingredients.FirstOrDefault(x=> x.Id == id);
        }

        public async Task UpdateAsync(Ingredient entity)
        {
            _db.Ingredients.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(List<Ingredient> entitys)
        {
            _db.Ingredients.UpdateRange(entitys);
            await _db.SaveChangesAsync();
        }
    }
}
