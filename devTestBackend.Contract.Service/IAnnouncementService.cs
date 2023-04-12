using devTestBackend.Entities.Requests.Announcements;
using devTestBackend.Entities.Responses.Announcements;

namespace devTestBackend.Contract.Service
{
    public interface IAnnouncementService
    {
        Task<IGetAllAnnouncementResponse> GetAllAnnouncementAsync(GetAllAnnouncementRequest request); 
    }
}
