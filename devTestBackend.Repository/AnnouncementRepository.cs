using devTestBackend.Contract.Repository;
using devTestBackend.Entities.Models;

namespace devTestBackend.Repository
{
    public class AnnouncementRepository : GenericRepository<Announcement>, IAnnouncementRepository
    {
    }
}