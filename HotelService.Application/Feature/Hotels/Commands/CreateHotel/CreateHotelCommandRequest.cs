using ContactInformationService.Application.Features.ContactInformation.Dtos;
using HotelGuide.Shared.Dtos.ResponseModel;
using MediatR;

namespace HotelService.Application.Feature.Hotels.Commands.CreateHotel
{
    public class CreateHotelCommandRequest : IRequest<ResponseDto<CreateHotelCommandResponse>>
    {

        public Guid? Id { get; set; }
        public string AuthorizedName { get; set; }
        public string AuthorizedSurName { get; set; }
        public string CompanyName { get; set; }
        public List<CreatedContactInformationDto> createdContactInformationDtos { get; set; }
    }
}
