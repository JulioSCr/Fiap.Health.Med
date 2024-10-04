using Fiap.Health.Med.Cadastros.Application.DTOs;
using Fiap.Health.Med.Cadastros.Application.InputModels;
using Fiap.Health.Med.Cadastros.Domain.Entities;
using Fiap.Health.Med.Cadastros.Domain.Enums;
using Fiap.Health.Med.Cadastros.Domain.Interfaces.Repositories;
using Fiap.Invest.Core.Exceptions;

namespace Fiap.Health.Med.Cadastros.Application.Services;
public class MedicoService : IMedicoService
{
    private readonly IMedicoRepository _repository;
    private readonly IAuthService _authService;

    public MedicoService(IMedicoRepository repository, IAuthService authService)
    {
        _repository = repository;
        _authService = authService;
    }

    public async Task<TokenJwtDTO> AutenticarAsync(AutenticacaoInputModel model)
    {
        return await _authService.AutenticarAsync(model, TipoUsuario.Medico);
    }

    public async Task<TokenJwtDTO> CadastrarAsync(MedicoInputModel model)
    {
        var medico = await _repository.ObterPorCrmAsync(model.Crm, model.CrmEstado);

        if (medico != null)
            throw new FiapInvestApplicationException($"CRM {model.Crm}-{model.CrmEstado} já está cadastrado");

        medico = await _repository.ObterPorCpfAsync(model.Cpf);

        if (medico != null)
            throw new FiapInvestApplicationException($"CPF {model.Cpf} já está cadastrado como médico");

        await _repository.Add(new Medico(model.Crm, model.CrmEstado, model.Cpf, model.Nome, model.Email));

        var result = await _authService.RegistrarAsync(model);

        return result;
    }
}
