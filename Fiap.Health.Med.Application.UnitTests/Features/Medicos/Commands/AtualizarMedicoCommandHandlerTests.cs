﻿using Fiap.Health.Med.Application.Features.Medicos.Commands.AtualizarMedico;
using Fiap.Health.Med.Application.MappingProfiles;
using Fiap.Health.Med.Application.UnitTests.Mocks;
using Fiap.Health.Med.Domain.Entity;
using Fiap.Health.Med.Domain.Interfaces;
using AutoMapper;
using Moq;
using Moq.AutoMock;

namespace Fiap.Health.Med.Application.UnitTests.Features.Medicos.Commands
{
    [Collection(nameof(MedicoTestsAutoMockerCollection))]
    public class AtualizarMedicoCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAgendaMedicoRepository> _mockMedicoRepo;
        private readonly AtualizarMedicoCommandHandler _medicoHandler;
        private readonly MedicoTestsAutoMockerFixture _medicofixture;
        private readonly AutoMocker _mocker;

        public AtualizarMedicoCommandHandlerTests(MedicoTestsAutoMockerFixture medicofixture)
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MedicoProfile>();
            });
            _mocker = new AutoMocker();
            _mapper = mapperConfig.CreateMapper();
            _mocker.Use(mapperConfig.CreateMapper());
            _medicoHandler = _mocker.CreateInstance<AtualizarMedicoCommandHandler>();
            _medicofixture = medicofixture;           
        }

        [Fact(DisplayName = "Atualizar medico com Sucesso")]
        [Trait("Categoria", "Medico - Medico Command Handler")]
        public async Task AtualizarMedico_NovoMedico_DeveExecutarComSucesso()
        {          
            // Arrange
            var medicoOriginal = _medicofixture.GerarMedicoValido();
            var medicoUpdate = _medicofixture.AtualizarMedicoCommand();
            var validator = new AtualizarMedicoCommandValidator();
            _mocker.GetMock<IMedicoRepository>().Setup(r => r.Adicionar(It.IsAny<Medico>())).Returns(Task.CompletedTask);
            _mocker.GetMock<IMedicoRepository>().Setup(r => r.UnitOfWork.Commit()).ReturnsAsync(true);
            _mocker.GetMock<IMedicoRepository>().Setup(r => r.ObterPorId(medicoOriginal.Id)).ReturnsAsync(medicoOriginal);

            //Act
            var validationResult = await validator.ValidateAsync(medicoUpdate);
            medicoUpdate.Id = medicoOriginal.Id;
            var result = await _medicoHandler.Handle(medicoUpdate, CancellationToken.None);

            //Assert
            Assert.True(validationResult.IsValid);
            _mocker.GetMock<IMedicoRepository>().Verify(r => r.Atualizar(It.IsAny<Medico>()), Times.Once);
            _mocker.GetMock<IMedicoRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);

        }
    }
}
