namespace Fiap.Health.Med.Cadastros.Domain.Entities;
public class Medico : Pessoa
{
    public string CrmNumero { get; private set; }
    public string CrmEstado { get; private set; }

    public Medico() { }

    public Medico(string crmNumero, string crmEstado, string cpf, string nome, string email) : base(cpf, nome, email)
    {
        CrmNumero = crmNumero.Trim().PadLeft(6, '0');
        CrmEstado = crmEstado.ToUpper();
    }
}
