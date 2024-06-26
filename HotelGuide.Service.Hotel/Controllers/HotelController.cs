﻿using HotelGuide.Shared.Dtos.ResponseModel;
using HotelService.Application.Feature.Hotels.Commands.CreateHotel;
using HotelService.Application.Feature.Hotels.Commands.DeleteHotel;
using HotelService.Application.Feature.Hotels.Queries.GetHotelInfo;
using HotelService.Application.Feature.Hotels.Queries.GetHotelManagement;
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
        [HttpGet]
        public async Task<ResponseDto<GetHotelInfoQueryResponse>> GetHotelInfoByHotelId(Guid hotelId)
        {
            return await mediator.Send(new GetHotelInfoQueryRequest(hotelId));
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
        [HttpGet("{hotelId}")]
        public async Task<ResponseDto<GetHotelManagementQueryResponse>> GetHotelManagementByHotelId(Guid hotelId)
        {
            return await mediator.Send(new GetHotelManagementQueryRequest(hotelId));
        }
    }
}
