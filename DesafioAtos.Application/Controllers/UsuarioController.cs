using DesafioAtos.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    [ActionFilterValidacaoModelState]
    [Authorize(Roles = "Usuario")]
    public class UsuarioController : AppControllerBase
    {
        public UsuarioController(IFabricaService fabricaService, IFabricaResponse fabricaResponse)
            : base(fabricaService, fabricaResponse)
        {
        }

        ///<summary>
        /// Criar Usuário.
        /// </summary>        /// 
        /// <param name="userDto"></param>
        /// <returns>Atualização do Usuário</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /CriarUsuario
        ///     {
        ///          "login": "login",
        ///          "senha": "senha",
        ///          "nome": "Nome"
        ///      }
        /// </remarks>
        /// <response code="201">Retorna criação ok</response>
        /// <response code="400">Se o request for nulo</response>

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CriarUsuario(CriarUsuarioDto userDto)
        {
            var user = await _fabricaService.UsuarioService.CriarConta(userDto);
            return Created("", _fabricaResponse.Criar(user.Id));
        }

        ///<summary>
        /// Atualizar Usuário.
        /// </summary>        /// 
        /// <param name="userDto"></param>
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
        /// Listar todas as categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet("categoria")]
        public async Task<IActionResult?> ListarCategorias()
        {
            var categorias = await _fabricaService.UsuarioService.ObterCategorias(ObterIdDoToken());
            return Ok(_fabricaResponse.Criar(categorias));
        }

        /// <summary>
        /// Adicionar Categoria
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns></returns>
        [HttpPost("categoria/{idCategoria:int}")]
        public async Task<IActionResult> AdicionarCategoria(int idCategoria)
        {
            var adicionarCategoriaDto = new CategoriaDto() { IdCategoria = idCategoria, IdLigacao = ObterIdDoToken() };
            var categoria = await _fabricaService.UsuarioService.AdicionarCategoria(adicionarCategoriaDto);
            string response = $"Categoria {categoria.ToString()} adicionada com sucesso!";
            return Accepted(_fabricaResponse.Criar(response));
        }

        /// <summary>
        /// Deletar categoria
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns></returns>
        [HttpDelete("categoria/{idCategoria:int}")]
        public async Task<IActionResult> RemoverCategoria(int idCategoria)
        {
            var categoriaDto = new CategoriaDto() { IdCategoria = idCategoria, IdLigacao = ObterIdDoToken() };
            await _fabricaService.UsuarioService.RemoverCategoria(categoriaDto);
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