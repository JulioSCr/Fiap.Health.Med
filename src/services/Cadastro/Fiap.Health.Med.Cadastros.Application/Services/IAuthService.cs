using Fiap.Health.Med.Cadastros.Application.DTOs;
using Fiap.Health.Med.Cadastros.Application.InputModels;
using Fiap.Health.Med.Cadastros.Domain.Enums;

namespace Fiap.Health.Med.Cadastros.Application.Services
{
    public interface IAuthService
    {
        Task<TokenJwtDTO> RegistrarAsync(MedicoInputModel model);
        Task<TokenJwtDTO> RegistrarAsync(PacienteInputModel model);
        Task<TokenJwtDTO> AutenticarAsync(AutenticacaoInputModel model, TipoUsuario tipoUsuario);
    }
}
