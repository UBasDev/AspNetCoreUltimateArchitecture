using Demo1.Helper.Exceptions;
using Demo1.Helper.Models;
using Demo1.Helper.Registrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Infrastructure.Registration
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddJwtAuth(configuration);
            var jwtTokenSettings = new JwtSettings();
            configuration.GetSection("JwtTokenSettings").Bind(jwtTokenSettings);
            services.AddSingleton(jwtTokenSettings);
            return services;
        }
    }
}
