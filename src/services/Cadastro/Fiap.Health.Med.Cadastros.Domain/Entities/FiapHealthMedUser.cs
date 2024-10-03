using Fiap.Health.Med.Cadastros.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace Fiap.Health.Med.Cadastros.Domain.Entities;
public class FiapHealthMedUser : IdentityUser
{
    public TipoUsuario TipoUsuario { get; private set; }
    public FiapHealthMedUser() { }

    public FiapHealthMedUser(string email, TipoUsuario tipoUsuario)
    {
        UserName = Guid.NewGuid().ToString();
        TipoUsuario = tipoUsuario;
        Email = email;
        EmailConfirmed = true;
    }
}
