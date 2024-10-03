using Fiap.Invest.Core.Extensions.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Fiap.Health.Med.Cadastros.Application.InputModels;
[ExcludeFromCodeCoverage]
public record struct AutenticacaoInputModel
{
    [Required(ErrorMessage = "É obrigatório informar um e-mail")]
    [EmailAddress(ErrorMessage = "O e-mail está em um formato inválido")]
    public string Email { get; init; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
    public string Senha { get; init; }
}