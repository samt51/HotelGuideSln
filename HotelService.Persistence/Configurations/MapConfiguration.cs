using HotelService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelService.Persistence.Configurations
{
    public class MapConfiguration : IEntityTypeConfiguration<Maps>
    {
        public void Configure(EntityTypeBuilder<Maps> builder)
        {
            var data1 = new Maps(Guid.Parse("5c6686c0-cd05-47f1-890f-c8b675ef5219"), "dsadsa", Guid.Parse("c8570c8a-03c2-4f48-96dd-8bc43b917143"), Guid.Parse("b3fca7a2-7fb8-4071-a89e-19b064612564"), Guid.Parse("3718bf9a-bd1a-4544-8cd9-eacdab3910ec"));

            builder.HasData(data1);
        }
    }
}
