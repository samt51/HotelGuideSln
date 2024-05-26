using HotelGuide.Shared.Interfaces.MappingTo.AutoMapper;
using HotelGuide.Shared.Interfaces.UnitOfWorks;
using HotelGuide.Shared.MessageQuery.Events;
using HotelService.Application.Feature.Hotels.Queries.GetHotelManagement;
using HotelService.Domain.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Application.Consumers
{
    public class GetHotelInfoReportQueryConsumer : IConsumer<HotelInfoReportEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRequestClient<>
        public GetHotelInfoReportQueryConsumer(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task Consume(ConsumeContext<HotelInfoReportEvent> context)
        {
            var dataIsControll = await _unitOfWork.GetReadRepository<Hotel>().GetAllAsync(x => !x.IsDeleted, x => x.Include(y => y.ContactInformations));

            var mapEntity = _mapper.Map<GetHotelManagementQueryResponse, Hotel>(dataIsControll);


        }
    }
}
