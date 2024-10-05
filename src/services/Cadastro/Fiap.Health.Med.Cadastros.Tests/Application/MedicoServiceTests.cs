using Fiap.Health.Med.Cadastros.Application.DTOs;
using Fiap.Health.Med.Cadastros.Application.InputModels;
using Fiap.Health.Med.Cadastros.Application.Services;
using Fiap.Health.Med.Cadastros.Domain.Entities;
using Fiap.Health.Med.Cadastros.Domain.Enums;
using Fiap.Health.Med.Cadastros.Domain.Interfaces.Repositories;
using Fiap.Invest.Core.Exceptions;
using Moq;
using Moq.AutoMock;

namespace Fiap.Health.Med.Cadastros.Tests.Application
{
    public class MedicoServiceTests
    {
        private readonly AutoMocker _mocker;
        private readonly MedicoService _medicoService;
        private readonly MedicoInputModel _medicoInputModel;

        public MedicoServiceTests()
        {
            _mocker = new AutoMocker();
            var repository = _mocker.GetMock<IMedicoRepository>();
            var authService = _mocker.GetMock<IAuthService>();
            _medicoService = new MedicoService(repository.Object, authService.Object);

            _medicoInputModel = new MedicoInputModel()
            {
                Cpf = "00000000191",
                Email = "teste@teste.com",
                Nome = "Teste teste",
                Senha = "Teste@01",
                SenhaConfirmacao = "Teste@01",
                Crm = "1",
                CrmEstado = "SP"
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
            var resposta = await _medicoService.AutenticarAsync(autenticacao);

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
                .Setup(x => x.RegistrarAsync(It.IsAny<MedicoInputModel>()))
                .ReturnsAsync(result);

            // Act
            var resposta = await _medicoService.CadastrarAsync(_medicoInputModel);

            // Assert
            Assert.Equal(result, resposta);
            Assert.IsType<TokenJwtDTO>(resposta);
        }

        [Fact(DisplayName = "CadastrarAsync Usuário Crm Já Cadastrado Retorna Exceção")]
        public async Task CadastrarAsync_UsuarioCrmJaCadastrado_RetornaExcecao()
        {
            // Arrange
            var result = new TokenJwtDTO { AccessToken = "Teste" };

            var medicoEntidade = new Medico();
            var repository = _mocker.GetMock<IMedicoRepository>();
            repository
                .Setup(x => x.ObterPorCrmAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(medicoEntidade);

            // Act
            var excecao = await Assert.ThrowsAsync<FiapInvestApplicationException>(async () => await _medicoService.CadastrarAsync(_medicoInputModel));

            // Assert
            Assert.Equal($"CRM {_medicoInputModel.Crm}-{_medicoInputModel.CrmEstado} já está cadastrado", excecao.Message);
        }

        [Fact(DisplayName = "CadastrarAsync Usuário Cpf Já Cadastrado Retorna Exceção")]
        public async Task CadastrarAsync_UsuarioCpfJaCadastrado_RetornaExcecao()
        {
            // Arrange
            var result = new TokenJwtDTO { AccessToken = "Teste" };

            var medicoEntidade = new Medico();
            var repository = _mocker.GetMock<IMedicoRepository>();
            repository
                .Setup(x => x.ObterPorCpfAsync(It.IsAny<string>()))
                .ReturnsAsync(medicoEntidade);

            // Act
            var excecao = await Assert.ThrowsAsync<FiapInvestApplicationException>(async () => await _medicoService.CadastrarAsync(_medicoInputModel));

            // Assert
            Assert.Equal($"CPF {_medicoInputModel.Cpf} já está cadastrado como médico", excecao.Message);
        }
    }
}
