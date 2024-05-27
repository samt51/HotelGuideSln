using HotelService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelService.Persistence.Configurations
{
    public class ContactInformationConfiguration : IEntityTypeConfiguration<ContactInformation>
    {
        public void Configure(EntityTypeBuilder<ContactInformation> builder)
        {
            var data1 = new ContactInformation(Guid.Parse("e66f288b-6044-4def-a62a-384bb3706be3"), HotelGuide.Shared.Enums.InformationTypeEnum.PhoneNumber, "05363956979", Guid.Parse("b9f3de51-b8ca-4427-adee-6fd3548d61af"));
            var data2 = new ContactInformation(Guid.Parse("bdbcaa6a-ed99-4373-ad40-0d3d08c4a712"), HotelGuide.Shared.Enums.InformationTypeEnum.Email, "samt51.m@icloud.com", Guid.Parse("b9f3de51-b8ca-4427-adee-6fd3548d61af"));
            var data3 = new ContactInformation(Guid.Parse("8e091fa3-3ced-4d50-b89d-b890e0a2deb4"), HotelGuide.Shared.Enums.InformationTypeEnum.Map, "5c6686c0-cd05-47f1-890f-c8b675ef5219", Guid.Parse("b9f3de51-b8ca-4427-adee-6fd3548d61af"));

            builder.HasData(data1, data2, data3);
        }
    }
}
