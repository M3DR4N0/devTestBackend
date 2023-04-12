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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
