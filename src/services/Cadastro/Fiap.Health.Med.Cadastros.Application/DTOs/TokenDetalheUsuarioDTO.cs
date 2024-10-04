using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace Fiap.Health.Med.Cadastros.Application.DTOs;
[ExcludeFromCodeCoverage]
public record struct TokenDetalheUsuarioDTO
{
    public string Cpf { get; set; }
    public IEnumerable<TokenClaimUsuarioDTO> Claims { get; set; }

    public TokenDetalheUsuarioDTO(IdentityUser usuario, IEnumerable<Claim> claims)
    {
        Cpf = usuario.UserName!;
        Claims = claims.Select(claim => new TokenClaimUsuarioDTO(claim));
    }
};