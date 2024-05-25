using HotelGuide.Shared.Dtos.ResponseModel;
using HotelService.Application.Feature.ContactInformation.Dtos;
using MediatR;

namespace HotelService.Application.Feature.ContactInformation.Commands.DeleteContactByHotelId
{
    public class DeleteContactByHotelIdRequest : IRequest<ResponseDto<DeleteContactByHotelIdResponse>>
    {
        public Guid HotelId { get; set; }
        public List<DeletedContactInformationByHotelIdDto> deletedContactInformationByHotelIdDtos   { get; set; }
    }
}
