using Demo1.Helper.Models;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Helper.Registrations
{
    public static class JwtRegistration
    {
        public static IServiceCollection AddJwtAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.GetSection("JwtTokenSettings").Bind(jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
                JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();
                if (o.SecurityTokenValidators.FirstOrDefault() is JwtSecurityTokenHandler jwtSecurityTokenHandler)
                    jwtSecurityTokenHandler.MapInboundClaims = false;
                o.TokenValidationParameters.RoleClaimType = JwtClaimTypes.Role;
                o.TokenValidationParameters.NameClaimType = JwtClaimTypes.PreferredUserName;
                o.TokenValidationParameters.ValidateAudience = jwtSettings.ValidateAudience;
                o.TokenValidationParameters.ValidIssuer = jwtSettings.ValidIssuer;
                o.TokenValidationParameters.ValidAudience = jwtSettings.ValidAudience;
                o.TokenValidationParameters.ValidateIssuer = jwtSettings.ValidateIssuer;
                o.TokenValidationParameters.ValidateLifetime = jwtSettings.ValidateLifetime;
                o.TokenValidationParameters.ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey;
                o.TokenValidationParameters.IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.IssuerSigningKey));
                o.RequireHttpsMetadata = jwtSettings.RequireHttpsMetadata;
                o.SaveToken = jwtSettings.SaveToken;
            });
            services.AddAuthorization();
            return services;
        }
    }
}
