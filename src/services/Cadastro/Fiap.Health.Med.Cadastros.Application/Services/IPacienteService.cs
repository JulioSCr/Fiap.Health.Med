using Fiap.Health.Med.Cadastros.Application.DTOs;
using Fiap.Health.Med.Cadastros.Application.InputModels;

namespace Fiap.Health.Med.Cadastros.Application.Services;
public interface IPacienteService
{
    Task<TokenJwtDTO> AutenticarAsync(AutenticacaoInputModel model);
    Task<TokenJwtDTO> CadastrarAsync(PacienteInputModel model);
}
