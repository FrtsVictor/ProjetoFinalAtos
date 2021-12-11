using System.Security.Claims;
using DesafioAtos.Application.ActionFilters.ValidateModel;
using DesafioAtos.Domain.Dtos;
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
        private readonly IUsuarioService _usuarioService;
        private readonly IFabricaResponse _fabricaResponse;

        public UsuarioController(IUsuarioService usuarioService, IFabricaResponse fabricaResponse)
        {
            this._usuarioService = usuarioService;
            this._fabricaResponse = fabricaResponse;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAccount(CriarUsuarioDto userDto)
        {
            var user = await _usuarioService.CriarConta(userDto);
            return Ok(_fabricaResponse.Create(user.Id));
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarUsuario(AtualizarUsuarioDto atualizarUsuarioDto)
        {
            atualizarUsuarioDto.Id = ObterIdUsuario();
            await _usuarioService.Atualizar(atualizarUsuarioDto);
            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> RemoverUsuario()
        {
            await _usuarioService.Remover(ObterIdUsuario());
            return NoContent();
        }


        private int ObterIdUsuario()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            return Convert.ToInt32(claimsIdentity.FindFirst("id")?.Value);
        }


    }
}