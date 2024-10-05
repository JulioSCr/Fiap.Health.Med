using System.Reflection;

namespace Fiap.Health.Med.Api
{
    public static class ApplicationServiceConfiguration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));          
            return services;
        }
    }
}
