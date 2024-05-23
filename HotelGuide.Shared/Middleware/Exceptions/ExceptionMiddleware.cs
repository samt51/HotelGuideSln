using FluentValidation;
using HotelGuide.Shared.Dtos.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Errors.Model;
using Serilog.Context;

namespace HotelGuide.Shared.Middleware.Exceptions
{
    public class ExceptionMiddleware : LogDetailConsume, IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IStringLocalizer<ObjectResult> _stringLocalizer;
        public ExceptionMiddleware(IStringLocalizer<ObjectResult> stringLocalizer, ILogger<ExceptionMiddleware> logger) : base(logger)
        {
            _logger = logger;
            _stringLocalizer = stringLocalizer;
        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                var context = httpContext.User?.Identity?.IsAuthenticated != null || true ? httpContext.User.Identities.Select(x => x.FindFirst("Id"))?.FirstOrDefault() : null;
                if (context is not null)
                {
                    LogContext.PushProperty("UserId", context.Value.ToString());
                }
                _logger.Log(LogLevel.Error, ex.Message);
                await HandleExceptionAsync(httpContext, ex, _stringLocalizer);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception, IStringLocalizer _stringLocalizer)
        {
            int statusCode = GetStatusCode(exception);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            if (exception.GetType() == typeof(ValidationException))
                return httpContext.Response.WriteAsync(new ExceptionModel
                {
                    Response = new Response<ExceptionModel>().Fail(new ExceptionModel(), ((ValidationException)exception).Errors.Select(x => x.ErrorMessage).ToList(), StatusCodes.Status400BadRequest)

                }.ToString());






            return httpContext.Response.WriteAsync(new ExceptionModel
            {
                Response = new Response<ExceptionModel>().Fail(new ExceptionModel { Response = new Response<ExceptionModel>() }, exception.Message, statusCode)

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
