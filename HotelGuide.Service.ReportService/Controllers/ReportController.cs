using HotelGuide.Shared.Dtos;
using HotelGuide.Shared.Dtos.ResponseModel;
 
using MediatR;
 
using Microsoft.AspNetCore.Mvc;
using ReportService.Application.Features.HoteInfoReport.Queries;

namespace HotelGuide.Service.ReportService.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReportController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponseDto<ReportType>> GetHotelInfoReport(GetHotelInfoReportRequest request)
        {
            return await mediator.Send(request);
        }
    }
}
