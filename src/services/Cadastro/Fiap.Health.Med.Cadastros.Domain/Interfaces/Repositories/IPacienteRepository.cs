using Delivery.Core.Data;
using Fiap.Health.Med.Cadastros.Domain.Entities;

namespace Fiap.Health.Med.Cadastros.Domain.Interfaces.Repositories;
public interface IPacienteRepository : IRepository<Paciente>
{
    IUnitOfWork UnitOfWork { get; }
    Task<Paciente?> ObterPorCpfAsync(string cpf);
}
