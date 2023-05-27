using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using UserService.Application.Interfaces.Repositories;
using UserService.Persistence.Repositories;

namespace UserService.Persistence.Registration
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
        public static async Task UsePersistence(this IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices;
            using var serviceScope = serviceProvider.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            await context?.Database.MigrateAsync();
        }
    }
}
