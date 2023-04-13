#nullable disable

namespace devTestBackend.Entities.Requests.Announcements
{
    public class UpdateAnnouncementRequest 
    {
        public string Link { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
