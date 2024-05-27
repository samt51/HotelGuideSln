using HotelGuide.Shared.Dtos;
using HotelGuide.Shared.Dtos.ResponseModel;
using HotelGuide.Shared.Interfaces.MappingTo.AutoMapper;
using HotelGuide.Shared.Interfaces.UnitOfWorks;
using HotelGuide.Shared.MessageQuery.Events;
using HotelService.Domain.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Application.Consumers
{
    public class GetHotelInfoReportQueryConsumer : IConsumer<HotelInfoReportEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRequestClient<ReportStatusEvent> _requestClient;

        public GetHotelInfoReportQueryConsumer(IUnitOfWork unitOfWork, IMapper mapper, IRequestClient<ReportStatusEvent> requestClient)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._requestClient = requestClient;
        }

        public async Task Consume(ConsumeContext<HotelInfoReportEvent> context)
        {

            var response = new ResponseDto<ReportType>
            {
                IsSuccess = true,
                Data = new ReportType(),
                StatusCode = 200,
                Errors = new List<string>()
            };
            var reportStatusUpdate = new ReportStatusEvent
            {
                ReportStatus = HotelGuide.Shared.Enums.ReportStatusEnum.Ready,
                DateRequested = DateTime.Now,
                Id = Guid.Empty
            };
            var reportStatusId = Guid.NewGuid();
            try
            {
                var getHotelAndContactInformations = await _unitOfWork.GetReadRepository<Hotel>().GetAllAsync(x => !x.IsDeleted, y => y.Include(c => c.ContactInformations));


                var contactInformationList = getHotelAndContactInformations.SelectMany(h => h.ContactInformations).ToList();

                if (contactInformationList.Count == 0)
                {
                    response.StatusCode = 400;
                    await context.RespondAsync(response);
                }

                var reportStatusEventResponse = await _requestClient.GetResponse<ResponseDto<ReportStatusEventResponse>>(reportStatusUpdate);


                reportStatusId = reportStatusEventResponse.Message.Data.Id;
             

                var groupByMapByMapIdAndHotelId = contactInformationList.Where(x => x.InformationType == HotelGuide.Shared.Enums.InformationTypeEnum.Map)
        .GroupBy(x => new { x.Id, x.HotelId });


                var getHotelInfoQueryResponses = groupByMapByMapIdAndHotelId.Select(item => new GetHotelInfoQueryResponse
                {
                    MapId = item.Key.Id,
                    TotalHotelCount = item.Count(),
                    TotalHotelPhoneNumberCount = contactInformationList
            .Count(x => x.InformationType == HotelGuide.Shared.Enums.InformationTypeEnum.PhoneNumber && x.HotelId == item.Key.HotelId)
                }).ToList();

                var rpt = new ReportType
                {
                    ReportStatusId = reportStatusEventResponse.Message.Data.Id,
                    ReportStatusEnum = HotelGuide.Shared.Enums.ReportStatusEnum.Ready,
                    getHotelInfoQueryResponses = getHotelInfoQueryResponses
                };

                response.Data = rpt;


                await context.RespondAsync(response);
            }
            catch (Exception)
            {
                reportStatusUpdate.ReportStatus = HotelGuide.Shared.Enums.ReportStatusEnum.Error;
                reportStatusUpdate.Id = reportStatusId;
                reportStatusUpdate.DateRequested = DateTime.Now;
                await _requestClient.GetResponse<ResponseDto<ReportStatusEventResponse>>(reportStatusUpdate);

            }

        }
    }
}
