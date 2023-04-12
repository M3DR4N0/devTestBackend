#nullable disable

namespace devTestBackend.Entities.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; } 
    }
}
