using Fiap.Health.Med.Cadastros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Fiap.Health.Med.Cadastros.Infrastructure.Mappings;
[ExcludeFromCodeCoverage]
public class MedicoMapping : IEntityTypeConfiguration<Medico>
{
    public void Configure(EntityTypeBuilder<Medico> builder)
    {
        builder.Property(x => x.CrmNumero).IsRequired();
        builder.Property(x => x.CrmEstado).IsRequired();
    }
}
