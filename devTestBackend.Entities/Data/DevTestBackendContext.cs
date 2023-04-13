using devTestBackend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace devTestBackend.Entities.Data
{
    public partial class DevTestBackendContext : DbContext
    {
        public DevTestBackendContext()
        { 
        } 

        public DevTestBackendContext(DbContextOptions<DevTestBackendContext> options)
            : base(options)
        {          
        }

        public virtual DbSet<Announcement> Announcements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-EK7QMDK;Initial Catalog=DevTestBackend;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
