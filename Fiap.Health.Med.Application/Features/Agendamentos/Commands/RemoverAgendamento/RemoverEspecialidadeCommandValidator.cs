using FluentValidation;
using System.Text.RegularExpressions;

namespace Fiap.Health.Med.Application.Features.Agendamentos.Commands.RemoverAgendamento
{
    public class RemoverAgendamentoCommandValidator : AbstractValidator<RemoverAgendamentoCommand>
    {
        public RemoverAgendamentoCommandValidator()
        {
            RuleFor(c => c.IdAgendamento)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

        }
    }
}
