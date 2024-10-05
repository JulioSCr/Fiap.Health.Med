using Fiap.Health.Med.Application.ViewModel;
using MediatR;

namespace Fiap.Health.Med.Application.Features.Pacientes.Queries
{
    public record ObterPacientesQuery : IRequest<IEnumerable<PacienteViewModel>>;
    public record ObterPacientePorIdQuery(Guid idPaciente) : IRequest<PacienteViewModel>;
    public record ObterAgendamentoPacientePorIdQuery(Guid idPaciente) : IRequest<PacienteViewModel>;

}
