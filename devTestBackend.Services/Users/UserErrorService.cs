using devTestBackend.Contract.Service;
using devTestBackend.Entities.Requests.Announcements;
using devTestBackend.Entities.Responses.Announcements;

namespace devTestBackend.Service.Users
{
    public class UserErrorService : IUserService
    {
        private readonly IAnnouncementService _AnnouncementService;

        public UserErrorService(IAnnouncementService AnnouncementService)
        {
            _AnnouncementService = AnnouncementService;
        }

        public async Task<IDeleteAnnouncementResponse> DeleteAnnouncementAsync(int id)
        {
            try
            {
                return await _AnnouncementService.DeleteAnnouncementAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = DeleteAnnouncementResponse.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IInsertAnnouncementResponse> GenerateAnnouncementsAsync(IEnumerable<InsertAnnouncementRequest> request)
        {
            try
            {
                return await _AnnouncementService.GenerateAnnouncementsAsync(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = InsertAnnouncementResponse.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IGetAllAnnouncementResponse> GetAllAnnouncementAsync()
        {
            try
            {
                return await _AnnouncementService.GetAllAnnouncementAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = GetAllAnnouncementResponse.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IGetAnnouncementResponse> GetAnnouncementAsync(int id)
        {
            try
            {
                return await _AnnouncementService.GetAnnouncementAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = GetAnnouncementResponse.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IGetAllAnnouncementResponse> GetByDescendingDateOrderAsync()
        {
            try
            {
                return await _AnnouncementService.GetByDescendingDateOrderAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = GetAllAnnouncementResponse.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IInsertAnnouncementResponse> InsertAnnouncementAsync(InsertAnnouncementRequest request)
        {
            try
            {
                return await _AnnouncementService.InsertAnnouncementAsync(request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = InsertAnnouncementResponse.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }

        public async Task<IUpdateAnnouncementResponse> UpdateAnnouncementAsync(int id, UpdateAnnouncementRequest request)
        {
            try
            {
                return await _AnnouncementService.UpdateAnnouncementAsync(id, request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var error = UpdateAnnouncementResponse.Failed.Instance;

                error.Message = (ex.InnerException ?? ex)!.Message;

                return error;
            }
        }
    }
}
