#nullable disable

namespace devTestBackend.Entities.Responses.Announcements
{
    public interface IUpdateAnnouncementResponse { }

    public class UpdateAnnouncementResponse : IUpdateAnnouncementResponse
    {
        public abstract class Base<T> : UpdateAnnouncementResponse where T : new()
        {
            public static T Instance => new();
        }

        public sealed class Success : Base<Success>
        {
            public string Message { get; set; } 
        }

        public sealed class ValidationError : Base<ValidationError>
        {
            public string Message { get; set; }
        }

        public sealed class Failed : Base<Failed>
        {
            public string Message { get; set; }
        }
    }
}
