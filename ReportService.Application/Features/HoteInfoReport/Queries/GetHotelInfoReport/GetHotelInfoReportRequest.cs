using HotelGuide.Shared.Dtos.ResponseModel;
using MassTransit.Caching;
using MediatR;

namespace ReportService.Application.Features.HoteInfoReport.Queries.GetHotelInfoReport
{
    public class GetHotelInfoReportRequest : IRequest<ResponseDto<List<GetHotelInfoReportResponse>>>
    {
        public Guid HotelId { get; set; }
    }
}
