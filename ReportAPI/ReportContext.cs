
using Microsoft.EntityFrameworkCore;
using ReportAPI.Entity;

namespace ReportAPI
{
    public class ReportContext : DbContext
    {
        public ReportContext(DbContextOptions<ReportContext> options) : base(options)
        {
        }

        public DbSet<Report> Report { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        
    }
}
