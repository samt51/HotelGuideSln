using ContactInformationService.Application.Features.ContactInformation.Dtos;
using HotelGuide.Shared.Bases;
using HotelGuide.Shared.Dtos.ResponseModel;
using HotelGuide.Shared.Interfaces.MappingTo.AutoMapper;
using HotelGuide.Shared.Interfaces.UnitOfWorks;
using HotelService.Application.Feature.Hotels.Queries.GetHotelManagement;
using HotelService.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Application.Feature.Hotels.Queries.GetHotelInfo
{
    public class GetHotelInfoQueryHandler : BaseHandler, IRequestHandler<GetHotelInfoQueryRequest, ResponseDto<GetHotelInfoQueryResponse>>
    {
        public GetHotelInfoQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetHotelInfoQueryResponse>> Handle(GetHotelInfoQueryRequest request, CancellationToken cancellationToken)
        {
            var hotelInfo = await unitOfWork.GetReadRepository<Hotel>().GetAsync(x => x.Id == request.HotelId && !x.IsDeleted, y => y.Include(x => x.ContactInformations));

            var data = mapper.Map<GetHotelInfoQueryResponse, Hotel>(hotelInfo);
            var contactMap = mapper.Map<CreatedContactInformationDto, HotelService.Domain.Entities.ContactInformation>(hotelInfo.ContactInformations);

            data.createdContactInformationDtos = contactMap;

            return new ResponseDto<GetHotelInfoQueryResponse>().Success(data);
        }
    }
}
