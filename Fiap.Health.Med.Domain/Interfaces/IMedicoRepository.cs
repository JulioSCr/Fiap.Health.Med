using Fiap.Health.Med.Domain.Entity;

namespace Fiap.Health.Med.Domain.Interfaces
{
    public interface IMedicoRepository : IRepository<Medico>
    {
        Task<Medico> ObterAgendamentosPorIdMedico(Guid idMedico);
        Task<Medico> ObterEspecialidadesPorIdMedico(Guid idMedico);
        Task<Medico> ObterMedicoPorCPF(string cpf);
        Task<Medico> ObterMedicoPorCRM(string crm);
    }
}
