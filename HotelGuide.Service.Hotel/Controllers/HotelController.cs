using HotelGuide.Shared.Dtos.ResponseModel;
using HotelService.Application.Feature.ContactInformation.Commands.CreateContactByHotelId;
using HotelService.Application.Feature.Hotels.Commands.CreateHotel;
using HotelService.Application.Feature.Hotels.Commands.DeleteHotel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelGuide.Service.Hotel.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IMediator mediator;
        public HotelController(IMediator mediator)
        {
            this.mediator = mediator;
        }
       
        [HttpPost]
        public async Task<ResponseDto<CreateHotelCommandResponse>> Create(CreateHotelCommandRequest request)
        {
            return await mediator.Send(request);
        }
        [HttpPost("{hotelId}")]
        public async Task<ResponseDto<DeleteHotelCommandResponse>> DeleteAsync(Guid hotelId)
        {
            return await mediator.Send(new DeleteHotelCommandRequest(hotelId));
        }
    }
}
