using HotelGuide.Shared.Dtos.ResponseModel;
using MediatR;

namespace HotelService.Application.Feature.Hotels.Queries.GetHotelInfo
{
    public class GetHotelInfoQueryRequest : IRequest<ResponseDto<GetHotelInfoQueryResponse>>
    {
        public Guid HotelId { get; set; }
        public GetHotelInfoQueryRequest(Guid hotelId)
        {
            this.HotelId = hotelId;
        }
    }
}
