using ContactInformationService.Application.Features.ContactInformation.Dtos;

namespace HotelService.Application.Feature.Hotels.Queries.GetHotelInfo
{
    public class GetHotelInfoQueryResponse
    {
        public Guid Id { get; set; }
        public string AuthorizedName { get; set; }
        public string AuthorizedSurName { get; set; }
        public string CompanyName { get; set; }
        public IList<CreatedContactInformationDto> createdContactInformationDtos { get; set; }
    }
}
