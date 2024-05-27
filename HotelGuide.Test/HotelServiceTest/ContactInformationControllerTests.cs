using Moq;
using MediatR;
using HotelGuide.Service.Hotel.Controllers;
using HotelGuide.Shared.Dtos.ResponseModel;
using HotelService.Application.Feature.ContactInformation.Commands.CreateContactByHotelId;
using HotelService.Application.Feature.ContactInformation.Commands.DeleteContactByHotelId;

public class ContactInformationControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly ContactInformationController _controller;

    public ContactInformationControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new ContactInformationController(_mediatorMock.Object);
    }

    [Fact]
    public async Task DeleteContactByHotelId_Should_Return_ResponseDto_With_DeleteContactByHotelIdResponse()
    {


        var request = new DeleteContactByHotelIdRequest();

        var responseDto = new ResponseDto<DeleteContactByHotelIdResponse>();
        _mediatorMock.Setup(m => m.Send(request, CancellationToken.None)).ReturnsAsync(responseDto);
        var controller = new ContactInformationController(_mediatorMock.Object);


        var result = await controller.DeleteContactByHotelId(request);


        Assert.IsType<ResponseDto<DeleteContactByHotelIdResponse>>(result);
        Assert.Equal(responseDto, result);
    }

    [Fact]
    public async Task CreateContactByHotelId_Should_Return_ResponseDto_With_CreateContactByHotelIdResponse()
    {

        var request = new CreateContactByHotelIdRequest();
        var responseDto = new ResponseDto<CreateContactByHotelIdResponse>();
        _mediatorMock.Setup(m => m.Send(request, CancellationToken.None)).ReturnsAsync(responseDto);
        var controller = new ContactInformationController(_mediatorMock.Object);


        var result = await controller.CreateContactByHotelId(request);


        Assert.IsType<ResponseDto<CreateContactByHotelIdResponse>>(result);
        Assert.Equal(responseDto, result);
    }
}
