using HotelGuide.Shared.Bases;
using HotelGuide.Shared.Dtos;
using HotelGuide.Shared.Dtos.ResponseModel;
using HotelGuide.Shared.Interfaces.MappingTo.AutoMapper;
using HotelGuide.Shared.Interfaces.UnitOfWorks;
using HotelGuide.Shared.MessageQuery.Events;
using MassTransit;
using MediatR;
using ReportService.Domain.Entities;
namespace ReportService.Application.Features.HoteInfoReport.Queries
{
    public class GetHotelInfoReportHandler : BaseHandler, IRequestHandler<GetHotelInfoReportRequest, ResponseDto<ReportType>>
    {
        private readonly IRequestClient<HotelInfoReportEvent> _requestClient;
        public GetHotelInfoReportHandler(IRequestClient<HotelInfoReportEvent> requestClient, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            this._requestClient = requestClient;
        }

        public async Task<ResponseDto<ReportType>> Handle(GetHotelInfoReportRequest request, CancellationToken cancellationToken)
        {
            var response = await _requestClient.GetResponse<ResponseDto<ReportType>>(new HotelInfoReportEvent());

            var getreportById = await unitOfWork.GetReadRepository<Report>().GetAsync(x => x.Id == response.Message.Data.ReportStatusId);

            response.Message.Data.ReportStatusEnum = HotelGuide.Shared.Enums.ReportStatusEnum.Completed;

            getreportById.ReportStatus = response.Message.Data.ReportStatusEnum;
            unitOfWork.OpenTransaction();

            await unitOfWork.GetWriteRepository<Report>().UpdateAsync(getreportById);

            if (await unitOfWork.SaveAsyncBool())
            {
                await unitOfWork.CommitAsync();
            }
           
            return response.Message;
        }
    }
}
