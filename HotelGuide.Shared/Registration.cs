using HotelGuide.Shared.Bases;
using HotelGuide.Shared.Middleware.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HotelGuide.Shared
{
    public static class Registration
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

            services.AddTransient<ExceptionMiddleware>();




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
