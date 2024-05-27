using HotelGuide.Shared.Dtos.ResponseModel;
using HotelGuide.Shared.Dtos;
using HotelGuide.Shared.Interfaces.MappingTo.AutoMapper;
using HotelGuide.Shared.Interfaces.UnitOfWorks;
using HotelGuide.Shared.MessageQuery.Events;
using MassTransit;
using ReportService.Domain.Entities;

namespace ReportService.Application.Consumers
{
    public class ReportStatusEventConsumer : IConsumer<ReportStatusEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReportStatusEventConsumer(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task Consume(ConsumeContext<ReportStatusEvent> context)
        {
            var reportModel = new Report();
            var response = new ResponseDto<ReportStatusEventResponse>
            {
                IsSuccess = true,
                Data = new ReportStatusEventResponse(),
                StatusCode = 200,
                Errors = new List<string>()
            };



            _unitOfWork.OpenTransaction();

            if (context.Message.Id == Guid.Empty)
            {
                var entity = _mapper.Map<Report, ReportStatusEvent>(context.Message);
                reportModel = await _unitOfWork.GetWriteRepository<Report>().AddAsync(entity);
            }
            else
            {
                var data = await _unitOfWork.GetReadRepository<Report>().GetAsync(x => x.Id == context.Message.Id && !x.IsDeleted);
                data.ReportStatus = context.Message.ReportStatus;
                data.ModifyDate = DateTime.Now;
                reportModel = await _unitOfWork.GetWriteRepository<Report>().UpdateAsync(data);
            }

            if (await _unitOfWork.SaveAsyncBool())
            {
                var rsp = _mapper.Map<ReportStatusEventResponse, Report>(reportModel);
                await _unitOfWork.CommitAsync();
                response.Data = rsp;
            }
            await context.RespondAsync(response);
        }
    }
}
