using Delivery.WebAPI.Core.User;
using Fiap.Health.Med.Cadastros.Application.DTOs;
using Fiap.Health.Med.Cadastros.Application.Extensions;
using Fiap.Health.Med.Cadastros.Application.InputModels;
using Fiap.Health.Med.Cadastros.Domain.Entities;
using Fiap.Health.Med.Cadastros.Domain.Enums;
using Fiap.Invest.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Security.Jwt.Core.Interfaces;
using System.Security.Claims;

namespace Fiap.Health.Med.Cadastros.Application.Services;
public class AuthService : IAuthService
{
    private readonly SignInManager<FiapHealthMedUser> _signInManager;
    private readonly UserManager<FiapHealthMedUser> _userManager;
    private readonly IJwtService _jwksService;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IAppTokenSettings _appTokenSettings;
    private readonly IAspNetUser _user;

    public AuthService(
        SignInManager<FiapHealthMedUser> signInManager,
        UserManager<FiapHealthMedUser> userManager,
        IJwtService jwksService,
        IHttpContextAccessor contextAccessor,
        IAppTokenSettings appTokenSettings,
        IAspNetUser user)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwksService = jwksService;
        _contextAccessor = contextAccessor;
        _appTokenSettings = appTokenSettings;
        _user = user;
    }

    public async Task<TokenJwtDTO> RegistrarAsync(MedicoInputModel model)
    {
        var usuario = new FiapHealthMedUser(model.Email, TipoUsuario.Medico);

        var usuarioBusca = await _userManager.Users.Where(u => u.Email == model.Email).ToListAsync();
        if (usuarioBusca.Any(u => u.TipoUsuario == TipoUsuario.Medico))
            throw new FiapInvestApplicationException("Usuário já cadastrado como médico");

        var resultado = await _userManager.CreateAsync(usuario, model.Senha);

        var claims = new List<Claim>
        {
            new Claim("Usuario", TipoUsuario.Medico.ToString())
        };
        var claimsResult = await _userManager.AddClaimsAsync(usuario, claims);
        if (!claimsResult.Succeeded)
            throw new FiapInvestApplicationException("Falha ao adicionar permissões ao usuário");

        return await CriarTokenJwtAsync(usuario, TipoUsuario.Medico);
    }

    public async Task<TokenJwtDTO> RegistrarAsync(PacienteInputModel model)
    {
        var usuario = new FiapHealthMedUser(model.Email, TipoUsuario.Paciente);

        var usuarioBusca = await _userManager.Users.Where(u => u.Email == model.Email).ToListAsync();
        if (usuarioBusca.Any(u => u.TipoUsuario == TipoUsuario.Paciente))
            throw new FiapInvestApplicationException("Usuário já cadastrado como paciente");

        var resultado = await _userManager.CreateAsync(usuario, model.Senha);

        var claims = new List<Claim>
        {
            new Claim("Usuario", TipoUsuario.Paciente.ToString())
        };
        var claimsResult = await _userManager.AddClaimsAsync(usuario, claims);
        if (!claimsResult.Succeeded)
            throw new FiapInvestApplicationException("Falha ao adicionar permissões ao usuário");

        return await CriarTokenJwtAsync(usuario, TipoUsuario.Paciente);
    }

    public async Task<TokenJwtDTO> CriarTokenJwtAsync(FiapHealthMedUser usuario, TipoUsuario tipoUsuario)
    {
        var usuarioBusca = await _userManager.Users
            .Where(u => u.Email == usuario.Email &&
                        u.TipoUsuario == tipoUsuario)
            .FirstOrDefaultAsync();
        if (usuarioBusca == null)
            throw new FiapInvestApplicationException("Usuário não cadastrado");

        var claims = await _userManager.GetClaimsAsync(usuarioBusca);

        var identityClaims = AuthExtensions.ObterClaims(
            usuarioBusca.Id,
            claims,
            await _userManager.GetRolesAsync(usuarioBusca));

        var accessToken = identityClaims.GerarToken(await _jwksService.GetCurrentSigningCredentials(), _contextAccessor);

        return new TokenJwtDTO(accessToken, usuarioBusca, claims);
    }

    public async Task<TokenJwtDTO> AutenticarAsync(AutenticacaoInputModel model, TipoUsuario tipoUsuario)
    {
        var usuarioBusca = await _userManager.Users
            .Where(u => u.Email == model.Email &&
                        u.TipoUsuario == tipoUsuario)
            .FirstOrDefaultAsync();

        if (usuarioBusca is null)
            throw new FiapInvestApplicationException("Código 01 - Usuário inválido");

        var resultado = await _signInManager.PasswordSignInAsync(usuarioBusca.UserName!, model.Senha, false, true);

        if (resultado.Succeeded)
            return await CriarTokenJwtAsync(usuarioBusca, tipoUsuario);

        if (resultado.IsLockedOut)
            throw new FiapInvestApplicationException("Código 02 - Usuário inválido");

        throw new FiapInvestApplicationException("Código 03 - Usuário inválido");
    }
}
