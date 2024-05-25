using HotelGuide.Shared.Dtos.ResponseModel;
using MediatR;

namespace HotelService.Application.Feature.Hotels.Commands.DeleteHotel
{
    public class DeleteHotelCommandRequest : IRequest<ResponseDto<DeleteHotelCommandResponse>>
    {
        public DeleteHotelCommandRequest(Guid hotelId)
        {
            this.HotelId = hotelId;
        }
        public Guid HotelId { get; }
    }
}
