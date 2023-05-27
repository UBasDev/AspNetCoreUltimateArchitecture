using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities.RoleEntity;

namespace UserService.Persistence.Seeds
{
    public static class SeedData
    {
        public static async Task InitializeDatabase(this IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            if (context == null) return;
            //context.Database.EnsureCreated(); ->Böylece seed datayı da içeren yeni bir database oluşmasını sağlarız. Eğer zaten database mevcutsa bu method, herhangi bir update yapmaz veya databasee seed data göndermez. Bu metodu relational databaseler için KULLANMAMALIYIZ.
            await context?.Database.MigrateAsync();

            /*
            if(!context.Roles.Any())
            {
                var roles = new List<Role>() {
                new Role()
                {
                    Id= 1,
                    Name="Super User",
                    Value="SuperUser",
                    Code=5,
                    CreatedDate= DateTime.UtcNow,
                    UpdatedDate=null
                },
                    new Role()
                {
                    Id= 2,
                    Name="System Admin",
                    Value="SystemAdmin",
                    Code=10,
                    CreatedDate= DateTime.UtcNow,
                    UpdatedDate=null
                },
                    new Role()
                {
                    Id= 3,
                    Name="CEO",
                    Value="CEO",
                    Code=15,                    
                    CreatedDate= DateTime.UtcNow,
                    UpdatedDate=null
                },
                    new Role()
                {
                    Id= 4,
                    Name="OC",
                    Value="OC",
                    Code=20,
                    CreatedDate= DateTime.UtcNow,
                    UpdatedDate=null
                },
                    new Role()
                {
                    Id= 5,
                    Name="Global Manager",
                    Value="GlobalManager",
                    Code=25,
                    CreatedDate= DateTime.UtcNow,
                    UpdatedDate=null
                },
                new Role()
                {
                    Id= 6,
                    Name="Department Manager",
                    Value="DepartmentManager",
                    Code=30,                    
                    CreatedDate= DateTime.UtcNow,
                    UpdatedDate=null
                },
                new Role()
                {
                    Id= 7,
                    Name="Software Developer",
                    Value="SoftwareDeveloper",
                    Code=35,
                    CreatedDate= DateTime.UtcNow,
                    UpdatedDate=null
                },
                new Role()
                {
                    Id= 8,
                    Name="Business Analyst",
                    Value="BusinessAnalyst",
                    Code=40,
                    CreatedDate= DateTime.UtcNow,
                    UpdatedDate=null
                },
                new Role()
                {
                    Id= 9,
                    Name="Tester",
                    Value="Tester",
                    Code=45,
                    CreatedDate= DateTime.UtcNow,
                    UpdatedDate=null
                }
                };
                await context.Roles.AddRangeAsync(roles);
            }
            */
            
            await context.SaveChangesAsync();
        }
    }
}
