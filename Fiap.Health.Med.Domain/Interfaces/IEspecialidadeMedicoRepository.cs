using Fiap.Health.Med.Domain.Entity;

namespace Fiap.Health.Med.Domain.Interfaces
{
    public interface IEspecialidadeMedicoRepository : IRepository<EspecialidadeMedico>
    {
        Task<EspecialidadeMedico> ObterPorIdEspecialidadeIDMedico(Guid idMedico, Guid idEspecialidade);
        //Task<Medico> ObterMedicoPorIdEspecialidadeIDMedico(Guid idMedico, Guid idEspecialidade);

        Task<bool> VerificarAgendaLivreMedico(Guid idMedido, DateTime dataAtendimento);
    }
}
