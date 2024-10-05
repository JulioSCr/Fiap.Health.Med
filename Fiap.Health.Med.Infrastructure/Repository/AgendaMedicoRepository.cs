using Fiap.Health.Med.Domain.Entity;
using Fiap.Health.Med.Domain.Interfaces;
using Fiap.Health.Med.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Health.Med.Infrastructure.Repository
{
    public class AgendaMedicoRepository : Repository<AgendaMedico>, IAgendaMedicoRepository
    {
        public AgendaMedicoRepository(HealthDbContext context) : base(context) { }

        public async Task<AgendaMedico> ObterAgendaMedicoPorDia(Guid idMedico, int dia)
        {
            var result = await DbSet.FirstOrDefaultAsync(a => a.MedicoId == idMedico && a.DiaSemana == (DayOfWeek)dia);
            return result;
        }
    }
}
