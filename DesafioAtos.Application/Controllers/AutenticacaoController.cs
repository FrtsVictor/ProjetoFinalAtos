using System.Threading.Tasks;
using DesafioAtos.Application.ActionFilters.ValidateModel;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Domain.Entidades;
using DesafioAtos.Service;
using DesafioAtos.Service.Fabrica.Services;
using DesafioAtos.Service.Services.Autenticacao;
using DesafioAtos.Service.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ActionFilterValidacaoModelState]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IFabricaResponse _fabricaResponse;
        private readonly IFabricaService _fabricaServices;
        public AutenticacaoController(
            IFabricaResponse fabricaResponse,
            IFabricaService fabricaServices)
        {
            this._fabricaServices = fabricaServices;
            this._fabricaResponse = fabricaResponse;
        }

        [HttpPost("login-usuario")]
        public async Task<IActionResult> LogarUsuario(LogarUsuarioDto loginDto)
        {            
            return Ok(await _fabricaServices.AutenticacaoService.LogarUsuario(loginDto));
        }

        [HttpPost("login-empresa")]
        public async Task<IActionResult> LogarEmpresa(LogarEmpresaDto loginDto)
        {
            var tokenResponse = await _fabricaServices.AutenticacaoService.LogarEmpresa(loginDto);
            return Ok(_fabricaResponse.Create<TokenResponseDto>(tokenResponse));
        }

    }
}