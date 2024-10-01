using Microsoft.AspNetCore.Identity;

namespace Fiap.Health.Med.Cadastros.Domain.Entities;
public class FiapHealthMedMedicoUser : IdentityUser
{
    public string Cpf { get; private set; }
    public string CrmNumero { get; private set; }
    public string CrmEstado { get; private set; }

    public FiapHealthMedMedicoUser() { }

    public FiapHealthMedMedicoUser(string nome, string cpf, string crmNumero, string crmEstado, string email)
    {
        UserName = nome;
        Cpf = cpf;
        CrmNumero = crmNumero;
        CrmEstado = crmEstado;
        Email = email;
    }
}
