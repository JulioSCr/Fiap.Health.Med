using Delivery.WebAPI.Core.Identity;
using Fiap.Health.Med.Cadastros.Domain.Entities;
using Fiap.Health.Med.Cadastros.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using NetDevPack.Security.Jwt.Core.Jwa;
using System.Diagnostics.CodeAnalysis;

namespace Fiap.Health.Med.Cadastros.Api.Configuration;
[ExcludeFromCodeCoverage]
public static class IdentityConfig
{
    public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddJwksManager(jwtOptions =>
            {
                jwtOptions.Jws = Algorithm.Create(AlgorithmType.ECDsa, JwtType.Jws);
            })
            .PersistKeysToDatabaseStore<AuthContext>();

        services.AddDefaultIdentity<FiapHealthMedUser>(option =>
            {
                option.User.RequireUniqueEmail = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AuthContext>()
            .AddDefaultTokenProviders();

        services.AddJwtAsyncKeyConfiguration(configuration);
    }
}