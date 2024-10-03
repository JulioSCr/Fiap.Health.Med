using Delivery.WebAPI.Core.User;
using Fiap.Health.Med.Cadastros.Application.Services;
using Fiap.Health.Med.Cadastros.Infrastructure.Context;
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
            .AddScoped<IAspNetUser, AspNetUser>()
            .AddScoped<AuthContext>();
    }
}