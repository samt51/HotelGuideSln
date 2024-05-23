using ContactInformationService.Domain.Entities;
using HotelGuide.Service.ContactInformationService.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ContactInformationService.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #region DbSets

        public DbSet<ContactInformation> ContactInformation { get; set; }
        public DbSet<Maps> Maps { get; set; }
        #endregion
    }
}
