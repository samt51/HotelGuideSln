using HotelGuide.Shared.Bases;
using HotelGuide.Shared.Dtos.ResponseModel;
using HotelGuide.Shared.Interfaces.MappingTo.AutoMapper;
using HotelGuide.Shared.Interfaces.UnitOfWorks;
using MassTransit.Testing;
using MediatR;

namespace ReportService.Application.Features.HoteInfoReport.Queries.GetHotelInfoReport
{
    public class GetHotelInfoReportHandler : BaseHandler, IRequestHandler<GetHotelInfoReportRequest, ResponseDto<List<GetHotelInfoReportResponse>>>
    {
        private readonly IPublishedMessage _publishedMessage;
        public GetHotelInfoReportHandler(IPublishedMessage publishedMessage, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            this._publishedMessage = publishedMessage;
        }

        public Task<ResponseDto<List<GetHotelInfoReportResponse>>> Handle(GetHotelInfoReportRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
