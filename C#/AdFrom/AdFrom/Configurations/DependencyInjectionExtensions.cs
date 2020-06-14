using AdFrom.Services;
using AdFrom.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AdFrom.Configurations
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddAllDependencies(this IServiceCollection service)
        {
            return service
                .AddInfrastructureDependencies()
                .AddApplicationDependencies();
        }

        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection service)
        {
            return service;
        }

        public static IServiceCollection AddApplicationDependencies(this IServiceCollection service)
        {
            return service
                .AddScoped<IResponseService, ResponseService>()
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<IRequestBuilderService, RequestBuilderService>()
                .AddScoped<IDataFormationService, DataFormationService>()
                .AddSingleton<ITimeService,TimeService>()
                .AddScoped<ICalculationService, CalculationService>();
        }
    }
}
