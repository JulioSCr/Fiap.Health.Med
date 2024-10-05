using Fiap.Health.Med.Application.ViewModel;
using MediatR;

namespace Fiap.Health.Med.Application.Features.EspecialidadesMedicos.Queries
{
    public record ObterEspecialidadeMedicoQuery : IRequest<IEnumerable<EspecialidadeMedicosViewModel>>;
    public record ObterMedicoEspecialidadePorIdQuery(Guid idPaciente) : IRequest<EspecialidadeMedicosViewModel>;

}
