using Fiap.Health.Med.Domain.Entity;

namespace Fiap.Health.Med.Domain.Interfaces
{
    public interface IEspecialidadeRepository : IRepository<Especialidade>
    {
        Task<Especialidade> ObterMedicosPorEspecialidadeId(Guid idEspecialidade);
        Task<Especialidade> ObterPorNome(string nome);
    }
}
