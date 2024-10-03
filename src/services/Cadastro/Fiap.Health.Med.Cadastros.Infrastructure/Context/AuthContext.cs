using Delivery.Core.Data;
using Delivery.Core.Messages;
using Fiap.Health.Med.Cadastros.Domain.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Security.Jwt.Core.Model;
using NetDevPack.Security.Jwt.Store.EntityFrameworkCore;

namespace Fiap.Health.Med.Cadastros.Infrastructure.Context;
public sealed class AuthContext : IdentityDbContext, ISecurityKeyContext, IUnitOfWork
{
    public AuthContext(DbContextOptions<AuthContext> options) : base(options) { }
    public DbSet<KeyMaterial> SecurityKeys { get; set; }
    public DbSet<FiapHealthMedUser> FiapHealthMedUser { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Ignore<ValidationResult>();
        builder.Ignore<Event>();

        builder.ApplyConfigurationsFromAssembly(typeof(AuthContext).Assembly);
        base.OnModelCreating(builder);
    }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}
