using Delivery.Core.DomainObjects;

namespace Fiap.Health.Med.Cadastros.Domain.Entities;
public abstract class Pessoa : Entity, IAggregateRoot
{
    public string Cpf { get; protected set; }
    public string Nome { get; protected set; }
    public string Email { get; protected set; }

    protected Pessoa() { }

    protected Pessoa(string cpf, string nome, string email)
    {
        Cpf = cpf.Trim().PadLeft(11, '0');
        Nome = nome;
        Email = email;
    }
}
