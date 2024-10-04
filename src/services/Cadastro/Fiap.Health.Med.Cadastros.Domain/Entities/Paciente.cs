namespace Fiap.Health.Med.Cadastros.Domain.Entities;
public class Paciente : Pessoa
{
    public Paciente() { }
    public Paciente(string cpf, string nome, string email)
    : base(cpf, nome, email) { }
}
