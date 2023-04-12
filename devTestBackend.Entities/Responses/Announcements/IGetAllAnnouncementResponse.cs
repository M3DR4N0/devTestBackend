using devTestBackend.Entities.Models;

#nullable disable

namespace devTestBackend.Entities.Responses.Announcements
{
    public interface IGetAllAnnouncementResponse {}

    public class GetAllAnnouncementResponse : IGetAllAnnouncementResponse
    {
        public abstract class Base<T> : GetAllAnnouncementResponse where T : new()
        {
            public static T Instance => new();
        }

        public sealed class Success : Base<Success>
        {
            public IEnumerable<Announcement> Announcements { get; set; } 
        }

        public sealed class Failed : Base<Failed>
        {
            public string Message { get; set; }
        }
    }
}
