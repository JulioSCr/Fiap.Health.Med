using Fiap.Health.Med.Application.ViewModel;
using MediatR;

namespace Fiap.Health.Med.Application.Features.Agendamentos.Queries
{
    public record ObterAgendamentoQuery : IRequest<IEnumerable<AgendamentoViewModel>>;
    public record ObterAgendamentoPorIdQuery(Guid idAgendamento) : IRequest<AgendamentoViewModel>;
    public record ObterAgendamentoPorStatusQuery(int status) : IRequest<IEnumerable<AgendamentoViewModel>>;

}
