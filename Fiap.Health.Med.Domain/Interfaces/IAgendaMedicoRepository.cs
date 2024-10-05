using Fiap.Health.Med.Domain.Entity;

namespace Fiap.Health.Med.Domain.Interfaces
{
    public interface IAgendaMedicoRepository : IRepository<AgendaMedico>
    {
        Task<AgendaMedico> ObterAgendaMedicoPorDia(Guid idMedico, int dia);
      
    }
}
