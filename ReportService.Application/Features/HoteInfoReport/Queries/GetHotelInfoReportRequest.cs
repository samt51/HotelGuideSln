using HotelGuide.Shared.Dtos;
using HotelGuide.Shared.Dtos.ResponseModel;
using MediatR;

namespace ReportService.Application.Features.HoteInfoReport.Queries
{
    public class GetHotelInfoReportRequest : IRequest<ResponseDto<ReportType>>
    {
       
    }
}
