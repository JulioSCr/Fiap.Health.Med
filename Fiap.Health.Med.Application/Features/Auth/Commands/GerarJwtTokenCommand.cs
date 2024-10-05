using Fiap.Health.Med.Application.ViewModel.Auth;
using MediatR;

namespace Fiap.Health.Med.Application.Features.Auth.Commands
{
    public class GerarJwtTokenCommand : IRequest<UsuarioRespostaLoginViewModel>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
