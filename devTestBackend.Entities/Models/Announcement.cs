#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace devTestBackend.Entities.Models
{
    [Table("Announcement")]
    public class Announcement
    {
        [Key]
        public int Id { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; } 
    }
}
