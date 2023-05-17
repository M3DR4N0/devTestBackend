using devTestBackend.Entities.Requests.Announcements;
using devTestBackend.Entities.Responses.Announcements;

namespace devTestBackend.Contract.Service
{ 
    public interface IUserService
    {
        Task<IGetAllAnnouncementResponse> GetAllAnnouncementAsync(); 
        Task<IGetAnnouncementResponse> GetAnnouncementAsync(int id); 
        Task<IInsertAnnouncementResponse> InsertAnnouncementAsync(InsertAnnouncementRequest request);
        Task<IInsertAnnouncementResponse> GenerateAnnouncementsAsync(IEnumerable<InsertAnnouncementRequest> request); 
        Task<IUpdateAnnouncementResponse> UpdateAnnouncementAsync(int id, UpdateAnnouncementRequest request);  
        Task<IDeleteAnnouncementResponse> DeleteAnnouncementAsync(int id);
        Task<IGetAllAnnouncementResponse> GetByDescendingDateOrderAsync(); 
    }
}
