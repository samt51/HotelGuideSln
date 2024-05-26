using HotelGuide.Shared.Bases;
using HotelGuide.Shared.Dtos.ResponseModel;
using HotelGuide.Shared.Interfaces.MappingTo.AutoMapper;
using HotelGuide.Shared.Interfaces.UnitOfWorks;
using HotelService.Domain.Entities;
using MediatR;

namespace HotelService.Application.Feature.Hotels.Queries.GetHotelManagement
{
    public class GetHotelManagementQueryHandler : BaseHandler, IRequestHandler<GetHotelManagementQueryRequest, ResponseDto<GetHotelManagementQueryResponse>>
    {
        public GetHotelManagementQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetHotelManagementQueryResponse>> Handle(GetHotelManagementQueryRequest request, CancellationToken cancellationToken)
        {
            var dataIsControll = await unitOfWork.GetReadRepository<Hotel>().GetAsync(x => x.Id == request.HotelId && !x.IsDeleted);

            var mapEntity = mapper.Map<GetHotelManagementQueryResponse, Hotel>(dataIsControll);

            return new ResponseDto<GetHotelManagementQueryResponse>().Success(mapEntity);
        }
    }
}
