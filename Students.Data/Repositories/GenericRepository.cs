using Microsoft.EntityFrameworkCore;
using Students.Data.Interfaces;
using Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await Task.FromResult(_table.AsNoTracking());
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _table.FirstOrDefaultAsync(entity => entity.Id == id);
        }
    }
}
