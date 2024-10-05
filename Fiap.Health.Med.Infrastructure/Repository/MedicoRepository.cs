using Fiap.Health.Med.Domain.Entity;
using Fiap.Health.Med.Domain.Interfaces;
using Fiap.Health.Med.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Health.Med.Infrastructure.Repository
{
    public class MedicoRepository : Repository<Medico>, IMedicoRepository
    {
        public MedicoRepository(HealthDbContext context) : base(context) { }

        public async Task<Medico> ObterAgendamentosPorIdMedico(Guid idMedico)
        {
            return await Db.Medicos
                 .Include(m => m.EspecialidadesMedicos)
                    .ThenInclude(e => e.Especialidade)
                 .ThenInclude(e => e.EspecialidadeMedicos)
                    .ThenInclude(a => a.Agendamentos)
                        .ThenInclude(p => p.Paciente)
                 .FirstOrDefaultAsync(m => m.Id == idMedico);
        }

        public async Task<Medico> ObterEspecialidadesPorIdMedico(Guid idMedico)
        {
            return await Db.Medicos.AsNoTracking()
                .Include(m => m.EspecialidadesMedicos)
                .ThenInclude(e => e.Especialidade)
                .FirstOrDefaultAsync(m => m.Id == idMedico);
        }

        public async Task<Medico> ObterMedicoPorCPF(string cpf)
        {
            return await DbSet.FirstOrDefaultAsync(p => p.Cpf == cpf);
        }

        public async Task<Medico> ObterMedicoPorCRM(string crm)
        {
            return await DbSet.FirstOrDefaultAsync(p => p.Crm == crm);
        }
    }
}
