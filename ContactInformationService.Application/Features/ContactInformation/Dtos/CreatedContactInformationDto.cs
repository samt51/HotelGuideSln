using HotelGuide.Shared.Enums;

namespace ContactInformationService.Application.Features.ContactInformation.Dtos
{
    public class CreatedContactInformationDto
    {
        public InformationTypeEnum InformationType { get; set; }
        public string InformationContent { get; set; }
        public Guid HotelId { get; set; }
    }
}
