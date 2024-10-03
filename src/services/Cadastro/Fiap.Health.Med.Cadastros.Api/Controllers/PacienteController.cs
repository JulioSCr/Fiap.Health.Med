using Delivery.Core.DomainObjects;
using Delivery.WebAPI.Core.Controllers;
using Fiap.Health.Med.Cadastros.Application.DTOs;
using Fiap.Health.Med.Cadastros.Application.InputModels;
using Fiap.Health.Med.Cadastros.Application.Services;
using Fiap.Health.Med.Cadastros.Domain.Enums;
using Fiap.Invest.Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Health.Med.Cadastros.Api.Controllers;
[Route("api/[Controller]")]
public class PacienteController : MainController
{
    private readonly IAuthService _service;

    public PacienteController(IAuthService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    [HttpPost("registrar")]
    [ProducesResponseType(typeof(TokenJwtDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegistrarUsuarioAsync(PacienteInputModel model)
    {
        try
        {
            return CustomResponse(await _service.RegistrarAsync(model));
        }
        catch (Exception ex) when (ex is FiapInvestApplicationException || ex is DomainException || ex is DataNotFoundException)
        {
            AddErrorToStack($"{ex.GetType().Name}: {ex.Message}");
            return CustomResponse();
        }
    }

    [AllowAnonymous]
    [HttpPost("autenticar")]
    [ProducesResponseType(typeof(TokenJwtDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegistrarUsuarioAsync(AutenticacaoInputModel model)
    {
        try
        {
            return CustomResponse(await _service.AutenticarAsync(model, TipoUsuario.Paciente));
        }
        catch (Exception ex) when (ex is FiapInvestApplicationException || ex is DomainException || ex is DataNotFoundException)
        {
            AddErrorToStack($"{ex.GetType().Name}: {ex.Message}");
            return CustomResponse();
        }
    }
}
