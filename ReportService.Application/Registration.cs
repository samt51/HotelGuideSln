using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ReportService.Application.Consumers;
using System.Reflection;

namespace ReportService.Application
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
                x.AddConsumer<ReportStatusEventConsumer>();
                // Default Port : 5672
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });
                    cfg.ReceiveEndpoint("get-report-status", e =>
                    {
                        e.ConfigureConsumer<ReportStatusEventConsumer>(context);
                    });
                });
            });

            services.AddMassTransitHostedService();
            return services;
        }
    }
}
