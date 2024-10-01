using Microsoft.AspNetCore.Identity;

namespace Fiap.Health.Med.Cadastros.Domain.Entities;
public class FiapHealthMedPacienteUser : IdentityUser
{
    public string Cpf { get; private set; }

    public FiapHealthMedPacienteUser() { }

    public FiapHealthMedPacienteUser(string nome, string cpf, string email)
    {
        UserName = nome;
        Cpf = cpf;
        Email = email;
    }
}