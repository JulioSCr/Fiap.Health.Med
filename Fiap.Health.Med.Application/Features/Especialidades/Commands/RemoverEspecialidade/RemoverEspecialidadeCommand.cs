using MediatR;

namespace Fiap.Health.Med.Application.Features.Especialidades.Commands.RemoverEspecialidade
{
    public class RemoverEspecialidadeCommand : IRequest<Guid>
    {
        public Guid idEspecialidade { get; set; }

    }
}
