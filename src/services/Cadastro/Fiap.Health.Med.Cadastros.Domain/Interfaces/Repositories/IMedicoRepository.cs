using Delivery.Core.Data;
using Fiap.Health.Med.Cadastros.Domain.Entities;

namespace Fiap.Health.Med.Cadastros.Domain.Interfaces.Repositories;
public interface IMedicoRepository : IRepository<Medico>
{
    IUnitOfWork UnitOfWork { get; }
    Task<Medico?> ObterPorCrmAsync(string crmNumero, string crmEstado);
    Task<Medico?> ObterPorCpfAsync(string cpf);
}
