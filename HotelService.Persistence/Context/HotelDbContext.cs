using HotelService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HotelService.Persistence.Context
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext() { }

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=SAMETBAGLAN;Database=HotelServiceDb;Trusted_Connection=True;TrustServerCertificate=true;Encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #region DbSets

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }
        public DbSet<Maps> Maps { get; set; }
        #endregion
    }
}
