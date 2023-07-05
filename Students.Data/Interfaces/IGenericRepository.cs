using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Data.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
    }
}
