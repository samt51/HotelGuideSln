using ContactInformationService.Application.Features.ContactInformation.Dtos;
using HotelGuide.Shared.Bases;
using HotelGuide.Shared.Dtos.ResponseModel;
using HotelGuide.Shared.Interfaces.MappingTo.AutoMapper;
using HotelGuide.Shared.Interfaces.UnitOfWorks;
using HotelService.Domain.Entities;
using MediatR;

namespace HotelService.Application.Feature.Hotels.Commands.CreateHotel
{
    public class CreateHotelCommandHandler : BaseHandler, IRequestHandler<CreateHotelCommandRequest, ResponseDto<CreateHotelCommandResponse>>
    {
        public CreateHotelCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {

        }

        public async Task<ResponseDto<CreateHotelCommandResponse>> Handle(CreateHotelCommandRequest request, CancellationToken cancellationToken)
        {
            var mapToEntity = mapper.Map<Hotel, CreateHotelCommandRequest>(request);

            unitOfWork.OpenTransaction();

            var saveEntity = await unitOfWork.GetWriteRepository<Hotel>().AddAsync(mapToEntity);

            if (await unitOfWork.SaveAsyncBool())
            {
                var mapToCreatedContactInformationDto = mapper.Map<HotelService.Domain.Entities.ContactInformation, CreatedContactInformationDto>(request.createdContactInformationDtos).ToList();
                mapToCreatedContactInformationDto.ForEach(x => x.HotelId = saveEntity.Id);

                await unitOfWork.GetWriteRepository<Domain.Entities.ContactInformation>().AddRangeAsync(mapToCreatedContactInformationDto);
                await unitOfWork.SaveAsyncBool();

                await unitOfWork.CommitAsync();
                return new ResponseDto<CreateHotelCommandResponse>().Success();
            }
            return new ResponseDto<CreateHotelCommandResponse>().Fail("Error", 500);

        }
    }
}
