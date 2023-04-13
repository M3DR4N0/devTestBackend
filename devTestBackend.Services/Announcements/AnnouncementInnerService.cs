using devTestBackend.Contract.Repository;
using devTestBackend.Contract.Service;
using devTestBackend.Entities.Models;
using devTestBackend.Entities.Requests.Announcements;
using devTestBackend.Entities.Responses.Announcements;

namespace devTestBackend.Service.Announcements
{
    public class AnnouncementInnerService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _AnnouncementRepository;
        public AnnouncementInnerService(IAnnouncementRepository AnnouncementRepository)
        {
            _AnnouncementRepository = AnnouncementRepository;
        }

        public async Task<IDeleteAnnouncementResponse> DeleteAnnouncementAsync(int id) 
        {
            var success = DeleteAnnouncementResponse.Success.Instance;

            await _AnnouncementRepository.DeleteAsync(id).ConfigureAwait(false);

            success.Message = "Successfully Deleted";

            return success;
        }

        public async Task<IInsertAnnouncementResponse> GenerateAnnouncementsAsync(IEnumerable<InsertAnnouncementRequest> request)
        {
            var success = InsertAnnouncementResponse.Success.Instance;

            var announcementsToInsert = request.Select(announcement => new Announcement
            {
                Link = announcement.Link,
                Title = announcement.Title,
                Content = announcement.Content, 
                Date = announcement.Date
            });

            await _AnnouncementRepository.InsertInRangeAsync(announcementsToInsert).ConfigureAwait(false);

            success.Message = "Successfully Inserted";

            return success;
        }

        public async Task<IGetAllAnnouncementResponse> GetAllAnnouncementAsync()
        {
            var success = GetAllAnnouncementResponse.Success.Instance;

            success.Announcements = await _AnnouncementRepository.GetAllAsync().ConfigureAwait(false);

            return success;
        }

        public async Task<IGetAnnouncementResponse> GetAnnouncementAsync(int id) 
        {
            var success = GetAnnouncementResponse.Success.Instance;

            success.Announcement = await _AnnouncementRepository.GetAsync(id).ConfigureAwait(false);

            return success;
        }

        public async Task<IGetAllAnnouncementResponse> GetByDescendingDateOrderAsync()
        {
            var success = GetAllAnnouncementResponse.Success.Instance;

            success.Announcements = await _AnnouncementRepository.GetByDescendingDateOrderAsync().ConfigureAwait(false);

            return success;
        }

        public async Task<IInsertAnnouncementResponse> InsertAnnouncementAsync(InsertAnnouncementRequest request)
        {
            var success = InsertAnnouncementResponse.Success.Instance;

            var announcementToInsert = new Announcement
            {
                Link = request.Link,
                Title = request.Title,
                Content = request.Content,
                Date= request.Date
            };

            await _AnnouncementRepository.InsertAsync(announcementToInsert).ConfigureAwait(false);

            success.Message = "Successfully Inserted";

            return success;
        }

        public async Task<IUpdateAnnouncementResponse> UpdateAnnouncementAsync(int id, UpdateAnnouncementRequest request)
        {
            var success = UpdateAnnouncementResponse.Success.Instance;

            var announcementToUpdate = new Announcement
            { 
                Id = id,
                Link = request.Link,
                Title = request.Title,
                Content = request.Content,
                Date = request.Date
            };

            await _AnnouncementRepository.UpdateAsync(announcementToUpdate).ConfigureAwait(false);

            success.Message = "Successfully Updated";

            return success;
        }
    }
}
