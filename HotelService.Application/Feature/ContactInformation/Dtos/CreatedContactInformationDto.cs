using HotelGuide.Shared.Enums;

namespace ContactInformationService.Application.Features.ContactInformation.Dtos
{
    public class CreatedContactInformationDto
    {
        public Guid Id { get; set; }
        public InformationTypeEnum InformationType { get; set; }
        public string InformationContentValue { get; set; }
    }
}
