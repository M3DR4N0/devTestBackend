using devTestBackend.Contract.Repository;
using devTestBackend.Entities.Data;
using devTestBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace devTestBackend.Repository
{
    public class AnnouncementRepository : GenericRepository<Announcement>, IAnnouncementRepository
    {
        private readonly DevTestBackendContext _context; 

        public AnnouncementRepository(DevTestBackendContext context) 
        { 
            _context = context;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Announcements.AnyAsync(announcement => announcement.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Announcement>> GetByDescendingDateOrderAsync()
        {
            return await _context.Announcements.OrderByDescending(announcement => announcement.Date).ToListAsync().ConfigureAwait(false);
        }
    }
}