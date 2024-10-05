using Fiap.Health.Med.Cadastros.Application.InputModels;
using Fiap.Health.Med.Cadastros.Application.Services;
using System.Diagnostics.CodeAnalysis;
using Moq;
using Moq.AutoMock;
using Fiap.Health.Med.Cadastros.Domain.Interfaces.Repositories;
using Fiap.Health.Med.Cadastros.Domain.Enums;
using Fiap.Health.Med.Cadastros.Application.DTOs;
using Fiap.Health.Med.Cadastros.Domain.Entities;
using Fiap.Invest.Core.Exceptions;

namespace Fiap.Health.Med.Cadastros.Tests.Application;
[ExcludeFromCodeCoverage]
public class PacienteServiceTests
{
    private readonly AutoMocker _mocker;
    private readonly PacienteService _pacienteService;
    private readonly PacienteInputModel _pacienteInputModel;

    public PacienteServiceTests()
    {
        _mocker = new AutoMocker();
        var repository = _mocker.GetMock<IPacienteRepository>();
        var authService = _mocker.GetMock<IAuthService>();
        _pacienteService = new PacienteService(repository.Object, authService.Object);

        _pacienteInputModel = new PacienteInputModel()
        {
            Cpf = "00000000191",
            Email = "teste@teste.com",
            Nome = "Teste teste",
            Senha = "Teste@01",
            SenhaConfirmacao = "Teste@01"
        };
    }

    [Fact(DisplayName = "AutenticarAsync Usuário Válido Retorna Token")]
    public async Task AutenticarAsync_UsuarioValido_RetornaToken()
    {
        // Arrange
        var autenticacao = new AutenticacaoInputModel()
        {
            Email = "teste@teste.com",
            Senha = "Teste@01"
        };

        var result = new TokenJwtDTO { AccessToken = "Teste" };

        var authService = _mocker.GetMock<IAuthService>();
        authService
            .Setup(x => x.AutenticarAsync(It.IsAny<AutenticacaoInputModel>(), It.IsAny<TipoUsuario>()))
            .ReturnsAsync(result);

        // Act
        var resposta = await _pacienteService.AutenticarAsync(autenticacao);

        // Assert
        Assert.Equal(result, resposta);
        Assert.IsType<TokenJwtDTO>(resposta);
    }

    [Fact(DisplayName = "CadastrarAsync Usuário Válido Retorna Token")]
    public async Task CadastrarAsync_UsuarioValido_RetornaToken()
    {
        // Arrange
        var result = new TokenJwtDTO { AccessToken = "Teste" };

        var authService = _mocker.GetMock<IAuthService>();
        authService
            .Setup(x => x.RegistrarAsync(It.IsAny<PacienteInputModel>()))
            .ReturnsAsync(result);

        // Act
        var resposta = await _pacienteService.CadastrarAsync(_pacienteInputModel);

        // Assert
        Assert.Equal(result, resposta);
        Assert.IsType<TokenJwtDTO>(resposta);
    }

    [Fact(DisplayName = "CadastrarAsync Usuário Inválido Retorna Exceção")]
    public async Task CadastrarAsync_UsuarioInvalido_RetornaExcecao()
    {
        // Arrange
        var result = new TokenJwtDTO { AccessToken = "Teste" };

        var pacienteEntidade = new Paciente();
        var repository = _mocker.GetMock<IPacienteRepository>();
        repository
            .Setup(x => x.ObterPorCpfAsync(It.IsAny<string>()))
            .ReturnsAsync(pacienteEntidade);

        // Act
        var excecao = await Assert.ThrowsAsync<FiapInvestApplicationException>(async () => await _pacienteService.CadastrarAsync(_pacienteInputModel));

        // Assert
        Assert.Equal($"CPF {_pacienteInputModel.Cpf} já está cadastrado como paciente", excecao.Message);
    }
}
