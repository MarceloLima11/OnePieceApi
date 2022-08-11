using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OnePiece.Application.Interfaces;
using OnePiece.Application.Mappings;
using OnePiece.Application.Services;
using OnePiece.Domain.Interfaces;
using OnePiece.Infrastructure.Context;
using OnePiece.Infrastructure.Repositories;
using System.Text;

namespace OnePiece.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("OnePieceConnection"));
            });

            services.AddScoped<IPersonagemRepository, PersonagemRepository>();
            services.AddScoped<IAkumaNoMiRepository, AkumaNoMiRepository>();
            services.AddScoped<IArcoRepository, ArcoRepository>();
            services.AddScoped<IIlhaRepository, IlhaRepository>();

            services.AddScoped<IPersonagemService, PersonagemService>();
            services.AddScoped<IAkumaNoMiService, AkumaNoMiService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IArcoService, ArcoService>();
            services.AddScoped<IIlhaService, IlhaService>();    

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            return services;
        }

        public static IServiceCollection AddTokenConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(
            JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidAudience = configuration["TokenConfiguration:Audience"],
                        ValidIssuer = configuration["TokenConfiguration:Issuer"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                   Encoding.UTF8.GetBytes(configuration["Jwt:key"]))
                    };
                });

            return services;
        }

    }
}
