using devTestBackend.Contract.Repository;
using devTestBackend.Entities.Data;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace devTestBackend.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DevTestBackendContext _context;
        private readonly DbSet<T> Entity;
        
        public GenericRepository() 
        {
            _context = new DevTestBackendContext();
            Entity = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entity.ToListAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await Entity.FindAsync(id).ConfigureAwait(false);

            Entity.Remove(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<T> GetAsync(object id)
        {
            return await Entity.FindAsync(id).ConfigureAwait(false);
        }

        public async Task InsertAsync(T entity)
        { 
            await Entity.AddAsync(entity).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task InsertInRangeAsync(IEnumerable<T> entity) 
        {
            await Entity.AddRangeAsync(entity).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(T entity)
        {
            Entity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
