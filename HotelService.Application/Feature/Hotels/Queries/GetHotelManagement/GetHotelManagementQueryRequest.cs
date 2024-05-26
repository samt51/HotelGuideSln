
using HotelGuide.Shared.Dtos.ResponseModel;
using MediatR;

namespace HotelService.Application.Feature.Hotels.Queries.GetHotelManagement
{
    public class GetHotelManagementQueryRequest : IRequest<ResponseDto<GetHotelManagementQueryResponse>>
    {
        public GetHotelManagementQueryRequest(Guid hotelId)
        {
            this.HotelId = hotelId;
        }
        public Guid HotelId { get; set; }
    }
}
