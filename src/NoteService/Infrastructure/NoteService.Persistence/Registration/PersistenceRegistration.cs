using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NoteService.Application.Interfaces.Repositories;
using NoteService.Persistence.Context;
using NoteService.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteService.Persistence.Registration
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
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
