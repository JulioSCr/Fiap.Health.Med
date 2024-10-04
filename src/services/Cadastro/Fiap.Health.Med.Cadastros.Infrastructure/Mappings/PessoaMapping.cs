using Fiap.Health.Med.Cadastros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiap.Health.Med.Cadastros.Infrastructure.Mappings;
public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder
            .HasDiscriminator<string>("TipoPessoa")
            .HasValue<Paciente>("Paciente")
            .HasValue<Medico>("Medico");
    }
}
