using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Helper.Registrations
{
    public static class SwaggerRegistration
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, string serviceTitle)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = serviceTitle,
                    Description = serviceTitle,
                    Contact = new OpenApiContact
                    {
                        Name = "",
                        Email = string.Empty
                    }
                });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Bearer Authentication",
                    Description = "Enter Bearer Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = "bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "bearer"
                        }
                    },
                    System.Array.Empty<string>()
                }
            });
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.EnableAnnotations();
            });
            return services;
        }
    }
}
