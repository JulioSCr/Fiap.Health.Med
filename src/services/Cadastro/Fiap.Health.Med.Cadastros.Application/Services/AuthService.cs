using Delivery.WebAPI.Core.User;
using Fiap.Health.Med.Cadastros.Api.Application;
using Fiap.Health.Med.Cadastros.Application.DTOs;
using Fiap.Health.Med.Cadastros.Application.InputModels;
using Fiap.Invest.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NetDevPack.Security.Jwt.Core.Interfaces;
using System.Security.Claims;

namespace Fiap.Health.Med.Cadastros.Application.Services;
public class AuthService : IAuthService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IJwtService _jwksService;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IAppTokenSettings _appTokenSettings;
    private readonly IAspNetUser _user;

    public AuthService(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
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

    public async Task<TokenJwtDTO> RegistrarAsync(MedicoInputModel usuario)
    {
        var usuarioBusca = await _userManager.FindByNameAsync(usuario.Cpf);
        if (usuarioBusca != null)
            throw new FiapInvestApplicationException("Usuário já cadastrado");

        var usuarioIdentity = new IdentityUser(usuario.Nome);

        var resultado = await _userManager.CreateAsync(usuarioIdentity, usuario.Senha);

        var claims = new List<Claim>
        {
            new Claim("Usuario", "Comum")
        };
        var claimsResult = await _userManager.AddClaimsAsync(usuarioIdentity, claims);
        if (!claimsResult.Succeeded)
            throw new FiapInvestApplicationException("Falha ao adicionar permissões ao usuário");

        return await CriarTokenJwtAsync(usuario.Cpf);
    }

    public async Task<TokenJwtDTO> CriarTokenJwtAsync(string cpf)
    {
        var usuario = await _userManager.FindByNameAsync(cpf);
        if (usuario == null)
            throw new FiapInvestApplicationException("Usuário não cadastrado");

        var claims = await _userManager.GetClaimsAsync(usuario);

        var identityClaims = AuthExtensions.ObterClaims(
            usuario.Id,
            claims,
            await _userManager.GetRolesAsync(usuario));

        var accessToken = identityClaims.GerarToken(await _jwksService.GetCurrentSigningCredentials(), _contextAccessor);

        return new TokenJwtDTO(accessToken, usuario, claims);
    }

    public async Task<UsuarioDTO> DecryptotokenAsync(Guid refreshToken)
    {
        //var refreshTokenResult = await ObterRedreshTokenAsync(refreshToken);

        //if (refreshTokenResult is null || string.IsNullOrWhiteSpace(refreshTokenResult?.Cpf))
        //    throw new FiapInvestApplicationException("Erro inesperado, token inválido");

        //var usuario = await _userManager.FindByNameAsync(refreshTokenResult.Value.Cpf!);

        //if (usuario == null)
        //    throw new FiapInvestApplicationException("Usuário não identificado");

        //return new UsuarioDTO
        //{
        //    Id = Guid.Parse(usuario.Id),
        //    Cpf = usuario.UserName ?? string.Empty,
        //    Nome = usuario.Nome
        //};

        throw new NotImplementedException();
    }

    public async Task<TokenJwtDTO> AutenticarAsync(AutenticacaoInputModel model)
    {
        var resultado = await _signInManager.PasswordSignInAsync(
            model.Cpf,
            model.Senha,
            false, true);

        if (resultado.Succeeded)
            return await CriarTokenJwtAsync(model.Cpf);

        if (resultado.IsLockedOut)
            throw new FiapInvestApplicationException("Código 01 - Usuário inválido");

        throw new FiapInvestApplicationException("Código 02 - Usuário inválido");
    }
}

