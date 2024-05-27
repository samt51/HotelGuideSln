using Microsoft.EntityFrameworkCore;
using ReportService.Domain.Entities;
using System.Reflection;

namespace ReportService.Persistence.Context
{

    public class ReportDbContext : DbContext
    {
        public ReportDbContext() { }

        public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=SAMETBAGLAN;Database=ReportServiceDb;Trusted_Connection=True;TrustServerCertificate=true;Encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #region DbSets

        public DbSet<Report> Report { get; set; }
        #endregion
    }
}
