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
        private readonly IAutenticacaoService _authenticationService;
        private readonly IFabricaResponse _fabricaResponse;
        private readonly IFabricaService _fabricaServices;
        public AutenticacaoController(
            IAutenticacaoService authenticationService,
            IFabricaResponse fabricaResponse, 
            IFabricaService fabricaServices)
        {
            this._authenticationService = authenticationService;
            this._fabricaServices = fabricaServices;
            this._fabricaResponse = fabricaResponse;
        }

        [HttpPost("login-usuario")]
        public  IActionResult LogarUsuario(LogarUsuarioDto loginDto)
        {
            var a =  _fabricaServices.AutenticacaoService;               
            a.LogarUsuario(new CriarUsuarioDto());
            
        //    var tokenResponse = await _authenticationService.LogarUsuario(loginDto);
           // return Ok(_fabricaResponse.Create<TokenResponseDto>(tokenResponse));
           return null;
        }

        [HttpPost("login-empresa")]
        public async Task<IActionResult> LogarEmpresa(LogarUsuarioDto loginDto)
        {
            var tokenResponse = await _authenticationService.LogarUsuario(loginDto);
            return Ok(_fabricaResponse.Create<TokenResponseDto>(tokenResponse));
        }

    }
}