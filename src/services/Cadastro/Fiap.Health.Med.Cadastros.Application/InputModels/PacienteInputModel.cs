using Fiap.Invest.Core.Extensions.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Health.Med.Cadastros.Application.InputModels;
public record struct PacienteInputModel
{
    [Required(ErrorMessage = "É obrigatório informar um CPF")]
    [CpfValidator(ErrorMessage = "O campo {0} está em formato inválido")]
    public string Cpf { get; init; }

    [Required(ErrorMessage = "É obrigatório informar um e-mail")]
    [EmailAddress(ErrorMessage = "O e-mail está em um formato inválido")]
    public string Email { get; init; }

    [Required(ErrorMessage = "É obrigatório informar um nome")]
    [NomeValidator()]
    public string Nome { get; init; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
    public string Senha { get; init; }

    [Compare("Senha", ErrorMessage = "As senhas não conferem")]
    public string SenhaConfirmacao { get; init; }
}