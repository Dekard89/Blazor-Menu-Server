using Menu_Server.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);

        Task<List<T>> GetAll();

        Task AddAsync(T entity);

        Task DeleteAsync(T entity);

        Task UpdateAsync(T entity);

        Task UpdateRangeAsync(List<T> entitys);
    }
}
