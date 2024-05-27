using HotelGuide.Service.Hotel.Controllers;
using HotelGuide.Shared.Dtos.ResponseModel;
using HotelService.Application.Feature.Hotels.Commands.CreateHotel;
using HotelService.Application.Feature.Hotels.Commands.DeleteHotel;
using HotelService.Application.Feature.Hotels.Queries.GetHotelInfo;
using HotelService.Application.Feature.Hotels.Queries.GetHotelManagement;
using MediatR;
using Moq;

namespace HotelGuide.Test.HotelServiceTest
{
    public class HotelControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly HotelController _controller;

        public HotelControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new HotelController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetHotelInfoByHotelId_ShouldReturnHotelInfo()
        {
         
            var hotelId = Guid.NewGuid();
            var expectedResponse = new ResponseDto<GetHotelInfoQueryResponse>
            {
                IsSuccess = true,
                Data = new GetHotelInfoQueryResponse {},
                StatusCode = 200,
                Errors = new List<string>()
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetHotelInfoQueryRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

        
            var result = await _controller.GetHotelInfoByHotelId(hotelId);

      
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.Equal(expectedResponse.Data, result.Data);
        }
        [Fact]
        public async Task Create_ShouldReturnCreateHotelCommandResponse()
        {
           
            var request = new CreateHotelCommandRequest {};
            var expectedResponse = new ResponseDto<CreateHotelCommandResponse>
            {
                IsSuccess = true,
                Data = new CreateHotelCommandResponse { },
                StatusCode = 200,
                Errors = new List<string>()
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateHotelCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

         
            var result = await _controller.Create(request);

           
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.Equal(expectedResponse.Data, result.Data);
        }
        [Fact]
        public async Task DeleteAsync_ShouldReturnDeleteHotelCommandResponse()
        {
          
            var hotelId = Guid.NewGuid();
            var expectedResponse = new ResponseDto<DeleteHotelCommandResponse>
            {
                IsSuccess = true,
                Data = new DeleteHotelCommandResponse { },
                StatusCode = 200,
                Errors = new List<string>()
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<DeleteHotelCommandRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

         
            var result = await _controller.DeleteAsync(hotelId);

      
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.Equal(expectedResponse.Data, result.Data);
        }
        [Fact]
        public async Task GetHotelManagementByHotelId_ShouldReturnHotelManagement()
        {
          
            var hotelId = Guid.NewGuid();
            var expectedResponse = new ResponseDto<GetHotelManagementQueryResponse>
            {
                IsSuccess = true,
                Data = new GetHotelManagementQueryResponse {  },
                StatusCode = 200,
                Errors = new List<string>()
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetHotelManagementQueryRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

           
            var result = await _controller.GetHotelManagementByHotelId(hotelId);

             
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.Equal(expectedResponse.Data, result.Data);
        }
    }
}
