using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnePiece.Application.Interfaces;
using OnePiece.Application.Mappings;
using OnePiece.Application.Services;
using OnePiece.Domain.Interfaces;
using OnePiece.Infrastructure.Context;
using OnePiece.Infrastructure.Repositories;

namespace OnePiece.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("OnePieceConnection"));
            });

            services.AddScoped<IPersonagemRepository, PersonagemRepository>();
            services.AddScoped<IAkumaNoMiRepository, AkumaNoMiRepository>();
            services.AddScoped<IPersonagemService, PersonagemService>();
            services.AddScoped<IAkumaNoMiService, AkumaNoMiService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
