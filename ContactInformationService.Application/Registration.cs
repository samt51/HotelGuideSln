using ContactInformationService.Application.Consumers;
using HotelGuide.Shared.Interfaces.UnitOfWorks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ContactInformationService.Application
{
    public static class Registration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();



            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));



            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMassTransit(x =>
            {
                x.AddConsumer<HotelCreatedEventConsumer>();
                // Default Port : 5672
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    cfg.ReceiveEndpoint("hotel-created-event-contactinformation-service",e =>
                    {
                        e.ConfigureConsumer<HotelCreatedEventConsumer>(context);
                    });
                });

            });
            services.AddMassTransitHostedService();

            return services;

        }
    }
}
