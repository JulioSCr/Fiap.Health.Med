using Fiap.Health.Med.Domain.Entity;
using Fiap.Health.Med.Domain.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Health.Med.Infrastructure.Context
{
    public class HealthDbContext : IdentityDbContext, IUnitOfWork
    {
        public HealthDbContext(DbContextOptions<HealthDbContext> options)
        : base(options)
        { }

        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<EspecialidadeMedico> EspecialidadeMedicos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<AgendaMedico> AgendasMedico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HealthDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
               .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
        public async Task<bool> Commit()
        {
            var sucesso = await base.SaveChangesAsync() > 0;
            return sucesso;
        }
    }
}
