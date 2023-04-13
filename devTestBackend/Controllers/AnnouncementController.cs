using devTestBackend.Contract.Service;
using devTestBackend.Entities.Requests.Announcements;
using devTestBackend.Entities.Responses.Announcements;
using devTestBackend.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace devTestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _service;

        public AnnouncementController(IAnnouncementService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnnouncement() 
        {
            var result = await _service.GetAllAnnouncementAsync().ConfigureAwait(false);

            return result switch
            {
                GetAllAnnouncementResponse.Success success => Ok(success),
                GetAllAnnouncementResponse.ValidationError validation => StatusCode(412, validation),
                GetAllAnnouncementResponse.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpGet("GetByDescendingDateOrder")] 
        public async Task<IActionResult> GetByDescendingDateOrder()
        {
            var result = await _service.GetByDescendingDateOrderAsync().ConfigureAwait(false);

            return result switch
            {
                GetAllAnnouncementResponse.Success success => Ok(success),
                GetAllAnnouncementResponse.ValidationError validation => StatusCode(412, validation),
                GetAllAnnouncementResponse.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncement(int id) 
        {
            var result = await _service.GetAnnouncementAsync(id).ConfigureAwait(false);

            return result switch
            {
                GetAnnouncementResponse.Success success => Ok(success),
                GetAnnouncementResponse.ValidationError validation => StatusCode(412, validation),
                GetAnnouncementResponse.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpPost]
        public async Task<IActionResult> InsertAnnouncement([FromBody] InsertAnnouncementRequest request) 
        {
            var result = await _service.InsertAnnouncementAsync(request).ConfigureAwait(false);

            return result switch
            {
                InsertAnnouncementResponse.Success success => Ok(success),
                InsertAnnouncementResponse.ValidationError validation => StatusCode(412, validation),
                InsertAnnouncementResponse.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpPost("GenerateRecords")]
        public async Task<IActionResult> GenerateAnnouncements()  
        {
            var announcements = await AnnouncementProvider.GetAllAsync().ConfigureAwait(false);

            var result = await _service.GenerateAnnouncementsAsync(announcements).ConfigureAwait(false);

            return result switch
            {
                InsertAnnouncementResponse.Success success => Ok(success),
                InsertAnnouncementResponse.ValidationError validation => StatusCode(412, validation),
                InsertAnnouncementResponse.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> UpdateAnnouncement(int id, [FromBody] UpdateAnnouncementRequest request) 
        {
            var result = await _service.UpdateAnnouncementAsync(id, request).ConfigureAwait(false);

            return result switch
            {
                UpdateAnnouncementResponse.Success success => Ok(success),
                UpdateAnnouncementResponse.ValidationError validation => StatusCode(412, validation),
                UpdateAnnouncementResponse.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncement(int id)  
        {
            var result = await _service.DeleteAnnouncementAsync(id).ConfigureAwait(false);

            return result switch
            {
                DeleteAnnouncementResponse.Success success => Ok(success),
                DeleteAnnouncementResponse.ValidationError validation => StatusCode(412, validation),
                DeleteAnnouncementResponse.Failed failed => BadRequest(failed),
                _ => BadRequest(),
            };
        }
    }
}
