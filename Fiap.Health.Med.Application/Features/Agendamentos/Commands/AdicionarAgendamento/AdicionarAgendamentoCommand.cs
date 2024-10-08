﻿using MediatR;

namespace Fiap.Health.Med.Application.Features.Agendamentos.Commands.AdicionarAgendamento
{
    public class AdicionarAgendamentoCommand : IRequest<Guid>
    {
        public Guid PacienteId { get; set; }
        public Guid EspecialidadeMedicoId { get; set; }
        public DateTime DataHoraAtendimento { get; set; }
    }
}
