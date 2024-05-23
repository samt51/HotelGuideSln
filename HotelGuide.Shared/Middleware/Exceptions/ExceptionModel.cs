using HotelGuide.Shared.Dtos.ResponseModel;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HotelGuide.Shared.Middleware.Exceptions;
public class ExceptionModel
{
    public Response<ExceptionModel> Response { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
public class LogDetailConsume
{
    private readonly ILogger<ExceptionMiddleware> _logger;
    public LogDetailConsume(ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
    }
}

