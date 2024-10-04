using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace Fiap.Health.Med.Cadastros.Application.DTOs;
[ExcludeFromCodeCoverage]
public record struct TokenClaimUsuarioDTO
{
    public string Valor { get; set; }
    public string Tipo { get; set; }

    public TokenClaimUsuarioDTO(Claim claim)
    {
        Valor = claim.Value;
        Tipo = claim.Type;
    }
}