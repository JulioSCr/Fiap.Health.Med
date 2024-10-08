﻿using Fiap.Health.Med.Application.Exceptions;
using Fiap.Health.Med.Domain.Interfaces;
using MediatR;

namespace Fiap.Health.Med.Application.Features.Medicos.Commands.RemoverMedico
{
    public class RemoverMedicoCommandHandler : IRequestHandler<RemoverMedicoCommand, Guid>
    {
        private readonly IMedicoRepository _medicoRepository;
        public RemoverMedicoCommandHandler(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<Guid> Handle(RemoverMedicoCommand request, CancellationToken cancellationToken)
        {
            //Validar os dados inseridos
            var validator = new RemoverMedicoCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Médico inválido", validationResult);

            var medicoExistente = await _medicoRepository.ObterPorId(request.IdMedico);

            if (medicoExistente == null)
            {
                throw new BadRequestException("Medico Não localizado!", validationResult);
            }

            await _medicoRepository.Remover(await _medicoRepository.ObterPorId(request.IdMedico));

            await _medicoRepository.UnitOfWork.Commit();

            return request.IdMedico;
        }       
    }
}
