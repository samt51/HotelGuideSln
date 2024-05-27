using HotelGuide.Shared.Bases;
using HotelGuide.Shared.Middleware.Exceptions;
using HotelService.Application.Consumers;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HotelService.Application
{
    public static class Registration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));


    
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

            services.AddTransient<ExceptionMiddleware>();



            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

          
            services.AddMassTransit(x =>
            {
                x.AddConsumer<GetHotelInfoReportQueryConsumer>();
                // Default Port : 5672
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });
                    cfg.ReceiveEndpoint("get-hotel-info-report-", e =>
                    {
                        e.ConfigureConsumer<GetHotelInfoReportQueryConsumer>(context);
                    });
                });
            });

            services.AddMassTransitHostedService();

            return services;

        }
        private static IServiceCollection AddRulesFromAssemblyContaining(
           this IServiceCollection services,
           Assembly assembly,
           Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                services.AddTransient(item);

            return services;
        }
    }
}
