using DesafioAtos.Application.Core.ActionFilters;
using DesafioAtos.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    /// <inheritdoc />
    [Route("api/v1/usuario")]
    [ApiController]
    [ActionFilterValidacaoModelState]
    [Authorize(Roles = "Usuario")]
    public class UsuarioController : AppControllerBase
    {
        /// <inheritdoc />
        public UsuarioController(IFabricaService fabricaService, IFabricaResponse fabricaResponse)
            : base(fabricaService, fabricaResponse)
        {
        }

        /// <summary>
        /// Retorna usuario baseado no ID atrelado ao token.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ObterUsuario()
        {
            return Ok( await _fabricaService.UsuarioService.ObterUsuario(ObterIdDoToken()));
        }

        ///<summary>
        /// Atualizar Usuário.
        /// </summary>        /// 
        /// <param name="atualizarUsuarioDto"></param>
        /// <returns>Atualização do Usuário</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /AlterarUsuario
        ///     {
        ///          "login": "login",
        ///          "senha": "senha",
        ///          "nome": "Nome"
        ///      }
        /// </remarks>
        /// <response code="201">Retorna criação ok</response>
        /// <response code="400">Se o request for nulo</response>
        [HttpPut]
        public async Task<IActionResult> EditarUsuario(EditarUsuarioDto atualizarUsuarioDto)
        {
            await _fabricaService.UsuarioService.Editar(ObterIdDoToken(), atualizarUsuarioDto);
            return NoContent();
        }

        /// <summary>
        /// Deletar Usuário
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> RemoverUsuario()
        {
            await _fabricaService.UsuarioService.Remover(ObterIdDoToken());
            return NoContent();
        }

       
        /// <summary>
        /// Listar empresa por categoria
        /// </summary>
        /// <returns></returns>
        [HttpGet("empresas")]
        public async Task<IActionResult?> ListarEmpresasPorCategoria()
        {
            var empresas = await _fabricaService.UsuarioService.ObterEmpresasPorCategoriaUsuario(ObterIdDoToken());
            return Ok(_fabricaResponse.Criar(empresas));
        }
    }
}