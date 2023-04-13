using devTestBackend.Entities.Models;

#nullable disable

namespace devTestBackend.Entities.Responses.Announcements
{
    public interface IDeleteAnnouncementResponse { }

    public class DeleteAnnouncementResponse : IDeleteAnnouncementResponse
    {
        public abstract class Base<T> : DeleteAnnouncementResponse where T : new()
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
