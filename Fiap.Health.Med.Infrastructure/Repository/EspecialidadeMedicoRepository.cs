using Fiap.Health.Med.Domain.Entity;
using Fiap.Health.Med.Domain.Enums;
using Fiap.Health.Med.Domain.Interfaces;
using Fiap.Health.Med.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Health.Med.Infrastructure.Repository
{
    public class EspecialidadeMedicoRepository : Repository<EspecialidadeMedico>, IEspecialidadeMedicoRepository
    {
        public EspecialidadeMedicoRepository(HealthDbContext context) : base(context) { }

        public async Task<EspecialidadeMedico> ObterPorIdEspecialidadeIDMedico(Guid idMedico, Guid idEspecialidade)
        {
            return await DbSet.FirstOrDefaultAsync(e => e.MedicoId == idMedico && e.EspecialidadeId == idEspecialidade);
        }

        public async Task<bool> VerificarAgendaLivreMedico(Guid idMedido, DateTime dataAtendimento)
        {
            var agenda = await DbSet.FirstOrDefaultAsync(e => e.MedicoId == idMedido && e.Agendamentos.Any(a => a.DataHoraAtendimento.Equals(dataAtendimento) && a.StatusAgendamento == StatusAgendamento.Ativo));

            return agenda == null;
        }
    }
}
