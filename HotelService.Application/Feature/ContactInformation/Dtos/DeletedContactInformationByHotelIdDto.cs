namespace HotelService.Application.Feature.ContactInformation.Dtos
{
    public class DeletedContactInformationByHotelIdDto
    {
        public int InformationType { get; set; }
        public Guid  InformationContentValueId { get; set; }
    }
}
