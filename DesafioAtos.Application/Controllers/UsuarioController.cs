using System.Security.Claims;
using DesafioAtos.Application.ActionFilters.ValidateModel;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service.Fabrica.Services;
using DesafioAtos.Service.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    [ActionFilterValidacaoModelState]
    [Authorize(Roles = "Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IFabricaService _fabricaService;
        private readonly IFabricaResponse _fabricaResponse;

        public UsuarioController(
            IFabricaService fabricaService,
            IFabricaResponse fabricaResponse)
        {
            this._fabricaService = fabricaService;
            this._fabricaResponse = fabricaResponse;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAccount(CriarUsuarioDto userDto)
        {
            var user = await _fabricaService.UsuarioService.CriarConta(userDto);
            return Ok(_fabricaResponse.Create(user.Id));
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarUsuario(AtualizarUsuarioDto atualizarUsuarioDto)
        {
            atualizarUsuarioDto.Id = ObterIdUsuario();
            await _fabricaService.UsuarioService.Atualizar(atualizarUsuarioDto);
            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> RemoverUsuario()
        {
            await _fabricaService.UsuarioService.Remover(ObterIdUsuario());
            return NoContent();
        }


        private int ObterIdUsuario()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            return Convert.ToInt32(claimsIdentity.FindFirst("id")?.Value);
        }


    }
}