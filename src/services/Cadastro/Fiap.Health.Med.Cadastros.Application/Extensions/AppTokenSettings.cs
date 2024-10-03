using System.Diagnostics.CodeAnalysis;

namespace Fiap.Health.Med.Cadastros.Application.Extensions;
[ExcludeFromCodeCoverage]
public class AppTokenSettings : IAppTokenSettings
{
    public int HorasExpiracaoRefreshToken { get; set; }
}