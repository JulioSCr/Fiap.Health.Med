
using Fiap.Health.Med.Identity.Identidade;
using Fiap.Health.Med.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Fiap.Health.Med.Api.Configuration
{
    public static class IdentityServiceConfiguration
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<HealthDbContext>()
                .AddDefaultTokenProviders();


            services.AddJwtConfiguration(configuration);

            return services;
        }

        public static async Task CreateUserDefault(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Verifique se o usuário já existe
            var user = await userManager.FindByNameAsync("postechdotnet@gmail.com");

            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = "postechdotnet@gmail.com",
                    Email = "postechdotnet@gmail.com",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, "Pos@123");

                //Se o usuário foi criado, vai ser adicionado o Nivel de acesso como administrador
                if (result.Succeeded)
                {

                    var claim = new Claim("Administrador", "Cadastrar");

                    await userManager.AddClaimAsync(user, claim);
                }
            }
        }
    }
}
