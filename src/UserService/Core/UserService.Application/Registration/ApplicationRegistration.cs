using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.Registration
{
    public static class ApplicationRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            //services.AddMediatR(typeof(ApplicationRegistration));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
