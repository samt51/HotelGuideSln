using HotelGuide.Shared.Bases;
using HotelGuide.Shared.Dtos.ResponseModel;
using HotelGuide.Shared.Interfaces.MappingTo.AutoMapper;
using HotelGuide.Shared.Interfaces.UnitOfWorks;
using HotelService.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Application.Feature.Hotels.Commands.DeleteHotel
{
    public class DeleteHotelCommandHandler : BaseHandler, IRequestHandler<DeleteHotelCommandRequest, ResponseDto<DeleteHotelCommandResponse>>
    {
        public DeleteHotelCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<DeleteHotelCommandResponse>> Handle(DeleteHotelCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<Hotel>().GetAsync(x => x.Id == request.HotelId&&!x.IsDeleted, y => y.Include(x => x.ContactInformations));

            data.IsDeleted = true;
            foreach (var contact in data.ContactInformations)
            {
                contact.IsDeleted = true;
            }
            unitOfWork.OpenTransaction();

             await unitOfWork.GetWriteRepository<Hotel>().UpdateAsync(data);
            unitOfWork.GetWriteRepository<Domain.Entities.ContactInformation>().UpdateRange(data.ContactInformations);

            if (await unitOfWork.SaveAsyncBool())
            {
                await unitOfWork.CommitAsync();
                return new ResponseDto<DeleteHotelCommandResponse>().Success();
            }
            return new ResponseDto<DeleteHotelCommandResponse>().Fail("error", 500);
        }
    }
}
