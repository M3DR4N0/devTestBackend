namespace devTestBackend.Contract.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(object id);
        Task InsertAsync(T entity);
        Task InsertInRangeAsync(IEnumerable<T> entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(object id);
    }
}
