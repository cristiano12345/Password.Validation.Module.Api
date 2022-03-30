using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Password.Validation.Module.Application.Handlers;
using Password.Validation.Module.Application.Handlers.Interface;
using Password.Validation.Module.Contracts.Command;
using Password.Validation.Module.Contracts.Command.Contract;
using Password.Validation.Module.Service;

namespace Password.Validation.Module.CrossCutting
{
    /// <summary>
    /// Provides dependency injection bootstrap methods
    /// </summary>   
    public static class DependencyInjection
    {
        /// <summary>
        /// Add application service in container
        /// </summary>
        /// <param name="services">Service collection object</param>
        /// <param name="configuration">Configuration collection</param>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {  
            services.AddScoped<IHandler<ValidateCommand>, ValidateHandler>();
            services.AddScoped<IValidatePasswordService, ValidatePasswordService>();
            return services;

        }
    }
}
