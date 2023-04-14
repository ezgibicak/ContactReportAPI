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
        public DbSet<KisiIletisim> KisiIletisim { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<KisiIletisim>().HasNoKey();

            base.OnModelCreating(builder);
        }
        
    }
}
