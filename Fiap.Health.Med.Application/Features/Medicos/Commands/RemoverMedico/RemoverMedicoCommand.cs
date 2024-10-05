using MediatR;

namespace Fiap.Health.Med.Application.Features.Medicos.Commands.RemoverMedico
{
    public class RemoverMedicoCommand : IRequest<Guid>
    {
        public Guid IdMedico { get; set; }

    }
}
