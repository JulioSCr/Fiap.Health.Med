using Fiap.Health.Med.Application.Features.Auth.Commands;
using Fiap.Health.Med.Application.Interfaces.Email;
using Fiap.Health.Med.Application.Models;
using Fiap.Health.Med.Application.ViewModel.Auth;
using Fiap.Health.Med.Domain.Interfaces;
using Fiap.Health.Med.Identity.Usuario;
using Fiap.Health.Med.Infrastructure.Context;
using Fiap.Health.Med.Infrastructure.EmailService;
using Fiap.Health.Med.Infrastructure.Repository;
using MediatR;

namespace Fiap.Health.Med.Api
{
    public static class InfrastructureServiceConfiguration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Autenticação
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Repository
            services.AddScoped<HealthDbContext>();
            services.AddScoped<IEspecialidadeMedicoRepository, EspecialidadeMedicoRepository>();
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IAgendaMedicoRepository, AgendaMedicoRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();


            services.AddScoped<IRequestHandler<GerarJwtTokenCommand, UsuarioRespostaLoginViewModel>, GerarJwtTokenCommandHandler>();           

            //Services
            services.Configure<EmailSettings>(o => configuration.GetSection("EmailSettings").Bind(o));
            services.AddScoped<IEmailSender, EmailSender>();

            return services;
        }
    }
}
