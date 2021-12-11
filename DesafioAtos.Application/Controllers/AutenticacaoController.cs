using System.Threading.Tasks;
using DesafioAtos.Application.ActionFilters.ValidateModel;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Service;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ActionFilterValidacaoModelState]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _authenticationService;
        private readonly IFabricaResponse _fabricaResponse;
        public AutenticacaoController(IAutenticacaoService authenticationService, IFabricaResponse fabricaResponse)
        {
            this._authenticationService = authenticationService;
            this._fabricaResponse = fabricaResponse;
        }

        [HttpPost("login-usuario")]
        public async Task<IActionResult> LogarUsuario(LogarUsuarioDto loginDto)
        {
            var tokenResponse = await _authenticationService.LogarUsuario(loginDto);
            return Ok(_fabricaResponse.Create<TokenResponseDto>(tokenResponse));
        }

        [HttpPost("login-empresa")]
        public async Task<IActionResult> LogarEmpresa(LogarUsuarioDto loginDto)
        {
            var tokenResponse = await _authenticationService.LogarUsuario(loginDto);
            return Ok(_fabricaResponse.Create<TokenResponseDto>(tokenResponse));
        }

    }
}