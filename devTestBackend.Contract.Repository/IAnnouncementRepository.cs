using devTestBackend.Entities.Models;

namespace devTestBackend.Contract.Repository
{
    public interface IAnnouncementRepository : IGenericRepository<Announcement>
    {
        Task<bool> ExistAsync(int id);
        Task<IEnumerable<Announcement>> GetByDescendingDateOrderAsync();   
    } 
}
