using ContactAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options)
        {
        }

        public DbSet<Kisi> Kisi { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        
    }
}
