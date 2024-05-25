using ContactInformationService.Domain.Entities;
using HotelGuide.Shared.Interfaces.MappingTo.AutoMapper;
using HotelGuide.Shared.Interfaces.UnitOfWorks;
using HotelGuide.Shared.MessageQuery.Events;
using MassTransit;

namespace ContactInformationService.Application.Consumers
{
    public class HotelCreatedEventConsumer : IConsumer<HotelCreatedEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotelCreatedEventConsumer(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<HotelCreatedEvent> context)
        {
            var maptoEntity = _mapper.Map<ContactInformation, HotelCreatedEvent>(context.Message);

            _unitOfWork.OpenTransaction();

            var saveEntity = await _unitOfWork.GetWriteRepository<ContactInformation>().AddAsync(maptoEntity);
            if (await _unitOfWork.SaveAsync())
            {
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
