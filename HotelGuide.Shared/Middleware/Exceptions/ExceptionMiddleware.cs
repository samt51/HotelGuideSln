using FluentValidation;
using HotelGuide.Shared.Dtos.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Errors.Model;

namespace HotelGuide.Shared.Middleware.Exceptions
{
    public class ExceptionMiddleware : LogDetailConsume, IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger) : base(logger)
        {
            _logger = logger;

        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {

                _logger.Log(LogLevel.Error, ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            int statusCode = GetStatusCode(exception);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            if (exception.GetType() == typeof(ValidationException))
                return httpContext.Response.WriteAsync(new ExceptionModel
                {
                    Response = new ResponseDto<ExceptionModel>().Fail(new ExceptionModel(), ((ValidationException)exception).Errors.Select(x => x.ErrorMessage).ToList(), StatusCodes.Status400BadRequest)

                }.ToString());



            return httpContext.Response.WriteAsync(new ExceptionModel
            {
                Response = new ResponseDto<ExceptionModel>().Fail(exception.Message, statusCode)

            }.ToString());

        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status400BadRequest,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };
    }
}
