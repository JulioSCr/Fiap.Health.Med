using Fiap.Health.Med.Domain.Entity;
using Fiap.Health.Med.Domain.Interfaces;
using Fiap.Health.Med.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Health.Med.Infrastructure.Repository
{
    public class EspecialidadeRepository : Repository<Especialidade>, IEspecialidadeRepository
    {
        public EspecialidadeRepository(HealthDbContext context) : base(context) { }

        public async Task<Especialidade> ObterMedicosPorEspecialidadeId(Guid idEspecialidade)
        {
            return await Db.Especialidades.AsNoTracking()
                 .Include(m => m.EspecialidadeMedicos)
                 .ThenInclude(e => e.Medico)
                 .FirstOrDefaultAsync(m => m.Id == idEspecialidade);
        }

        public async Task<Especialidade> ObterPorNome(string nome)
        {
            return await Db.Especialidades.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Nome.Equals(nome));
        }
    }
}

