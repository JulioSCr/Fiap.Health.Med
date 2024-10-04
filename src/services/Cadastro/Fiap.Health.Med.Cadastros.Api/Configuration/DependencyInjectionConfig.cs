using Delivery.WebAPI.Core.User;
using Fiap.Health.Med.Cadastros.Application.Services;
using Fiap.Health.Med.Cadastros.Domain.Interfaces.Repositories;
using Fiap.Health.Med.Cadastros.Infrastructure.Context;
using Fiap.Health.Med.Cadastros.Infrastructure.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace Fiap.Health.Med.Cadastros.Api.Configuration;
[ExcludeFromCodeCoverage]
public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IPacienteService, PacienteService>()
            .AddScoped<IMedicoService, MedicoService>()
            .AddScoped<IAspNetUser, AspNetUser>()
            .AddScoped<IPacienteRepository, PacienteRepository>()
            .AddScoped<IMedicoRepository, MedicoRepository>()
            .AddScoped<AuthContext>();
    }
}