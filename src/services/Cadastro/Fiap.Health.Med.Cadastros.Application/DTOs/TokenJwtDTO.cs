using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace Fiap.Health.Med.Cadastros.Application.DTOs;
[ExcludeFromCodeCoverage]
public record struct TokenJwtDTO
{
    public string AccessToken { get; set; }
    public Guid RefreshToken { get; set; }
    public double ExpiraEm { get; set; }
    public TokenDetalheUsuarioDTO UsuarioToken { get; set; }

    public TokenJwtDTO(string accessToken, IdentityUser usuario, IEnumerable<Claim> claims)
    {
        AccessToken = accessToken;
        ExpiraEm = TimeSpan.FromHours(1).TotalSeconds;
        UsuarioToken = new TokenDetalheUsuarioDTO(usuario, claims);
    }
}