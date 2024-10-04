using Fiap.Health.Med.Cadastros.Application.DTOs;
using Fiap.Health.Med.Cadastros.Application.InputModels;
using Fiap.Health.Med.Cadastros.Domain.Entities;
using Fiap.Health.Med.Cadastros.Domain.Enums;
using Fiap.Health.Med.Cadastros.Domain.Interfaces.Repositories;
using Fiap.Invest.Core.Exceptions;

namespace Fiap.Health.Med.Cadastros.Application.Services;
public class PacienteService : IPacienteService
{
    private readonly IPacienteRepository _repository;
    private readonly IAuthService _authService;

    public PacienteService(IPacienteRepository repository, IAuthService authService)
    {
        _repository = repository;
        _authService = authService;
    }

    public async Task<TokenJwtDTO> AutenticarAsync(AutenticacaoInputModel model)
    {
        return await _authService.AutenticarAsync(model, TipoUsuario.Paciente);
    }

    public async Task<TokenJwtDTO> CadastrarAsync(PacienteInputModel model)
    {
        var paciente = await _repository.ObterPorCpfAsync(model.Cpf);

        if (paciente != null)
            throw new FiapInvestApplicationException($"CPF {model.Cpf} já está cadastrado como paciente");

        await _repository.Add(new Paciente(model.Cpf, model.Nome, model.Email));

        var result = await _authService.RegistrarAsync(model);

        return result;
    }
}
