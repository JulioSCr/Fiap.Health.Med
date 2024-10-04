using Delivery.Core.Data;
using Fiap.Health.Med.Cadastros.Domain.Entities;
using Fiap.Health.Med.Cadastros.Domain.Interfaces.Repositories;
using Fiap.Health.Med.Cadastros.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Health.Med.Cadastros.Infrastructure.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly AuthContext _context;

        public MedicoRepository(AuthContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Task<Medico?> ObterPorCpfAsync(string cpf)
        {
            var consultaMedico = _context.Pessoas.OfType<Medico>().AsQueryable().AsNoTrackingWithIdentityResolution();

            return consultaMedico.FirstOrDefaultAsync(x => x.Cpf.Trim().PadLeft(11, '0') == cpf.Trim().PadLeft(11, '0'));
        }

        public Task<Medico?> ObterPorCrmAsync(string crmNumero, string crmEstado)
        {
            var consultaMedico = _context.Pessoas.OfType<Medico>().AsQueryable().AsNoTrackingWithIdentityResolution();

            return consultaMedico.FirstOrDefaultAsync(x => x.CrmNumero.Trim().PadLeft(6, '0') == crmNumero.Trim().PadLeft(6, '0') && x.CrmEstado.ToUpper() == crmEstado.ToUpper());
        }

        public async Task Add(Medico medico)
        {
            await _context.Pessoas.AddAsync(medico);
        }

        public async Task Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Medico> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Medico Item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
