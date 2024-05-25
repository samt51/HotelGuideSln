using ContactInformationService.Application.Features.ContactInformation.Dtos;
using HotelGuide.Shared.Bases;
using HotelGuide.Shared.Common;
using HotelGuide.Shared.Dtos.ResponseModel;
using HotelGuide.Shared.Interfaces.MappingTo.AutoMapper;
using HotelGuide.Shared.Interfaces.UnitOfWorks;
using HotelService.Domain.Entities;
using MediatR;

namespace HotelService.Application.Feature.ContactInformation.Commands.CreateContactByHotelId
{
    public class CreateContactByHotelIdHandler : BaseHandler, IRequestHandler<CreateContactByHotelIdRequest, ResponseDto<CreateContactByHotelIdResponse>>
    {
        public CreateContactByHotelIdHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateContactByHotelIdResponse>> Handle(CreateContactByHotelIdRequest request, CancellationToken cancellationToken)
        {
            await unitOfWork.GetReadRepository<Hotel>().GetAsync(x => x.Id == request.HotelId && !x.IsDeleted);

            var mapToCreatedContactInformationDto = mapper.Map<HotelService.Domain.Entities.ContactInformation, CreatedContactInformationDto>(request.createdContactInformationDtos).ToList();
            mapToCreatedContactInformationDto.ForEach(x => x.HotelId = request.HotelId);

            await unitOfWork.GetWriteRepository<HotelService.Domain.Entities.ContactInformation>().AddRangeAsync(mapToCreatedContactInformationDto);

            unitOfWork.OpenTransaction();

            if (await unitOfWork.SaveAsyncBool())
            {
                await unitOfWork.CommitAsync();
                return new ResponseDto<CreateContactByHotelIdResponse>().Success();
            }
            return new ResponseDto<CreateContactByHotelIdResponse>().Fail("", 400);
        }
    }
}
