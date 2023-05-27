using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Persistence.Context;

namespace UserService.FunctionalTest.Base
{
    internal class AnonymousApplication : WebApplicationFactory<Program>
    {
        public AnonymousApplication()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Testing";
            var configurationBuilder = new ConfigurationBuilder();
            var directory = Path.GetDirectoryName(typeof(AnonymousApplication).Assembly.Location)!;
            configurationBuilder.AddJsonFile(Path.Combine(directory, $"appSettings.{environment}.json"), optional: false).AddEnvironmentVariables();
            //ApplicationConfiguration.SetConfigurationBuilder(configurationBuilder);
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment("Testing");
            return base.CreateHost(builder);
        }
        public static void ConfigureServices(IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            //context.Products
        }
        
    }
}
