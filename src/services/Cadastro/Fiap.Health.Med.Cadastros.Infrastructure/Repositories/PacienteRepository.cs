using Delivery.Core.Data;
using Fiap.Health.Med.Cadastros.Domain.Entities;
using Fiap.Health.Med.Cadastros.Domain.Interfaces.Repositories;
using Fiap.Health.Med.Cadastros.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Health.Med.Cadastros.Infrastructure.Repositories;
public class PacienteRepository : IPacienteRepository
{
    private readonly AuthContext _context;

    public PacienteRepository(AuthContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public Task<Paciente?> ObterPorCpfAsync(string cpf)
    {
        var consultaPaciente = _context.Pessoas.OfType<Paciente>().AsQueryable().AsNoTrackingWithIdentityResolution();

        return consultaPaciente.FirstOrDefaultAsync(x => x.Cpf.Trim().PadLeft(11, '0') == cpf.Trim().PadLeft(11, '0'));
    }

    public async Task Add(Paciente paciente)
    {
        await _context.Pessoas.AddAsync(paciente);
    }

    public Task Delete(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<Paciente> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(Paciente Item)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
