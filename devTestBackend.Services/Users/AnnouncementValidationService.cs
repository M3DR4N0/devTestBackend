using devTestBackend.Contract.Repository;
using devTestBackend.Contract.Service;
using devTestBackend.Entities.Requests.Announcements;
using devTestBackend.Entities.Responses.Announcements;

namespace devTestBackend.Service.Users 
{
    public class UserValidationService : IUserService 
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IAnnouncementRepository _announcementRepository; 

        public UserValidationService(IAnnouncementService AnnouncementService, IAnnouncementRepository announcementRepository)
        {
            _announcementService = AnnouncementService;
            _announcementRepository = announcementRepository;
        }

        public async Task<IDeleteAnnouncementResponse> DeleteAnnouncementAsync(int id) 
        {
            var validation = DeleteAnnouncementResponse.ValidationError.Instance;

            var exist = await _announcementRepository.ExistAsync(id).ConfigureAwait(false);

            if (!exist)
            {
                validation.Message = $"Record not found with id ({id})";
                return validation;
            }

            return await _announcementService.DeleteAnnouncementAsync(id).ConfigureAwait(false);
        }

        public async Task<IInsertAnnouncementResponse> GenerateAnnouncementsAsync(IEnumerable<InsertAnnouncementRequest> request)
        {
            var validation = InsertAnnouncementResponse.ValidationError.Instance;

            if (!request.Any())
            {
                validation.Message = "The provider doesn't have any records to insert";
                return validation;
            }

            return await _announcementService.GenerateAnnouncementsAsync(request).ConfigureAwait(false);
        }

        public async Task<IGetAllAnnouncementResponse> GetAllAnnouncementAsync()
        {
            return await _announcementService.GetAllAnnouncementAsync().ConfigureAwait(false);
        }

        public async Task<IGetAnnouncementResponse> GetAnnouncementAsync(int id) 
        {
            var validation = GetAnnouncementResponse.ValidationError.Instance;

            var exist = await _announcementRepository.ExistAsync(id).ConfigureAwait(false);

            if (!exist)
            {
                validation.Message = $"Record not found with id ({id})";
                return validation;
            }

            return await _announcementService.GetAnnouncementAsync(id).ConfigureAwait(false);
        }

        public async Task<IGetAllAnnouncementResponse> GetByDescendingDateOrderAsync() 
        {
            return await _announcementService.GetByDescendingDateOrderAsync().ConfigureAwait(false);
        }

        public async Task<IInsertAnnouncementResponse> InsertAnnouncementAsync(InsertAnnouncementRequest request)
        {
            return await _announcementService.InsertAnnouncementAsync(request).ConfigureAwait(false);
        }

        public async Task<IUpdateAnnouncementResponse> UpdateAnnouncementAsync(int id, UpdateAnnouncementRequest request)
        {
            var validation = UpdateAnnouncementResponse.ValidationError.Instance;

            var exist = await _announcementRepository.ExistAsync(id).ConfigureAwait(false);

            if (!exist)
            {
                validation.Message = $"Record not found with id ({id})";
                return validation;
            }

            return await _announcementService.UpdateAnnouncementAsync(id, request).ConfigureAwait(false);
        }
    }
}
