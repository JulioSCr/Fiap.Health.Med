using System.Diagnostics.CodeAnalysis;

namespace Fiap.Health.Med.Cadastros.Application.DTOs;
[ExcludeFromCodeCoverage]
public record struct UsuarioDTO
{
    public Guid Id { get; init; }
    public string Cpf { get; init; }
    public string Nome { get; init; }
}