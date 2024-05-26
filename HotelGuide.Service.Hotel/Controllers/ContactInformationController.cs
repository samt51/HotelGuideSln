using HotelGuide.Shared.Dtos.ResponseModel;
using HotelService.Application.Feature.ContactInformation.Commands.CreateContactByHotelId;
using HotelService.Application.Feature.ContactInformation.Commands.DeleteContactByHotelId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelGuide.Service.Hotel.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ContactInformationController : ControllerBase
    {
        private readonly IMediator mediator;
        public ContactInformationController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponseDto<DeleteContactByHotelIdResponse>> DeleteContactByHotelId(DeleteContactByHotelIdRequest request)
        {
            return await mediator.Send(request);
        }
        [HttpPost]
        public async Task<ResponseDto<CreateContactByHotelIdResponse>> CreateContactByHotelId(CreateContactByHotelIdRequest request)
        {
            return await mediator.Send(request);
        }
    }
}
