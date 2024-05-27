using HotelService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelService.Persistence.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            var hotel = new Hotel(Guid.Parse("b9f3de51-b8ca-4427-adee-6fd3548d61af"), "Samet", "Bağlan", "Worigo");

            builder.HasData(hotel);
        }
    }
}
