using Fiap.Health.Med.Cadastros.Application.DTOs;
using Fiap.Health.Med.Cadastros.Application.InputModels;

namespace Fiap.Health.Med.Cadastros.Application.Services;
public interface IMedicoService
{
    Task<TokenJwtDTO> AutenticarAsync(AutenticacaoInputModel model);
    Task<TokenJwtDTO> CadastrarAsync(MedicoInputModel model);
}
