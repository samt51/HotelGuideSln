using HotelGuide.Shared.Bases;
using HotelGuide.Shared.Dtos.ResponseModel;
using HotelGuide.Shared.Interfaces.MappingTo.AutoMapper;
using HotelGuide.Shared.Interfaces.UnitOfWorks;
using HotelService.Application.Feature.ContactInformation.BaseCases;
using MediatR;

namespace HotelService.Application.Feature.ContactInformation.Commands.DeleteContactByHotelId
{
    public class DeleteContactByHotelIdHandler : BaseHandler, IRequestHandler<DeleteContactByHotelIdRequest, ResponseDto<DeleteContactByHotelIdResponse>>
    {
        private readonly ContactInformationBaseCase _contactInformationBaseCase;
        public DeleteContactByHotelIdHandler(ContactInformationBaseCase contactInformationBaseCase, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            this._contactInformationBaseCase = contactInformationBaseCase;
        }

        public async Task<ResponseDto<DeleteContactByHotelIdResponse>> Handle(DeleteContactByHotelIdRequest request, CancellationToken cancellationToken)
        {

            var contact = await unitOfWork.GetReadRepository<HotelService.Domain.Entities.ContactInformation>().GetAllAsync(x => !x.IsDeleted && x.HotelId == request.HotelId);

            await _contactInformationBaseCase.ContactInformationIsNullOrEmpty(contact);

         
            var query = from d1 in contact
                        join d2 in request.deletedContactInformationByHotelIdDtos on d1.Id equals d2.InformationContentValueId
                        select new HotelService.Domain.Entities.ContactInformation
                        {
                            CreatedDate = d1.CreatedDate,
                            HotelId = d1.HotelId,
                            ModifyDate = DateTime.Now,
                            Hotel = d1.Hotel,
                            IsDeleted = true,
                            Id = d1.Id,
                            InformationContentValue = d1.InformationContentValue,
                            InformationType = d1.InformationType,
                        };

            var list = query.ToList();

            unitOfWork.OpenTransaction();

            unitOfWork.GetWriteRepository<HotelService.Domain.Entities.ContactInformation>().UpdateRange(list);

            if (await unitOfWork.SaveAsyncBool())
            {
                await unitOfWork.CommitAsync();

                return new ResponseDto<DeleteContactByHotelIdResponse>().Success();
            }
            return new ResponseDto<DeleteContactByHotelIdResponse>().Fail("", 500);


        }
    }
}
