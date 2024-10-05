using MediatR;

namespace Fiap.Health.Med.Application.Features.Pacientes.Commands.RemoverPaciente
{
    public class RemoverPacienteCommand : IRequest<Guid>
    {
        public Guid IdPaciente { get; set; }

    }
}
