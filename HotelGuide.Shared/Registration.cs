using HotelGuide.Shared.Middleware.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace HotelGuide.Shared
{
    public static class Registration
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {

            services.AddTransient<ExceptionMiddleware>();

    
            return services;    
        }
    }
}
