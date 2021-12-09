using DesafioAtos.Application   .ActionFilters.ValidateModel;
using DesafioAtos.Domain.Dtos.Usuario;
using DesafioAtos.Service.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    [ActionFilterValidacaoModelState]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarUsuario(AtualizarUsuarioDto atualizarUsuarioDto)
        {
            await _usuarioService.Atualizar(atualizarUsuarioDto);
            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> RemoverUsuario()
        {
            await _usuarioService.Remover(1);
            return NoContent();
        }
    }
}