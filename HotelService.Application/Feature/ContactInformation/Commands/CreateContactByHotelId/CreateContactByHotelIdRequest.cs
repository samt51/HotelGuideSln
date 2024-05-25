using ContactInformationService.Application.Features.ContactInformation.Dtos;
using HotelGuide.Shared.Dtos.ResponseModel;
using MediatR;

namespace HotelService.Application.Feature.ContactInformation.Commands.CreateContactByHotelId
{
    public class CreateContactByHotelIdRequest : IRequest<ResponseDto<CreateContactByHotelIdResponse>>
    {

        public Guid HotelId { get; set; }
        public List<CreatedContactInformationDto> createdContactInformationDtos { get; set; }
    }
}
