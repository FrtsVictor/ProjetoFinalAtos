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
<<<<<<< HEAD
            var user = await _fabricaService.UsuarioService.CriarUsuario(userDto);
=======
            var user = await _fabricaService.UsuarioService.CriarConta(userDto);
>>>>>>> a4c0c85 (datanotation)
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

<<<<<<< HEAD

=======
        /// <summary>
        /// Listar todas as categorias
        /// </summary>
        /// <returns></returns>
>>>>>>> a4c0c85 (datanotation)
        [HttpGet("categoria")]
        public async Task<IActionResult?> ListarCategorias()
        {
            var categorias = await _fabricaService.UsuarioService.ObterCategorias(ObterIdDoToken());
            return Ok(_fabricaResponse.Criar(categorias));
        }

<<<<<<< HEAD
        [HttpPost("categoria/{idCategoria:int}")]
        public async Task<IActionResult> AdicionarCategoria(int idCategoria)
        {
            var adicionarCategoriaDto = new CategoriaDto() {IdCategoria = idCategoria, IdLigacao = ObterIdDoToken()};
=======
        /// <summary>
        /// Adicionar Categoria
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns></returns>
        [HttpPost("categoria/{idCategoria:int}")]
        public async Task<IActionResult> AdicionarCategoria(int idCategoria)
        {
            var adicionarCategoriaDto = new CategoriaDto() { IdCategoria = idCategoria, IdLigacao = ObterIdDoToken() };
>>>>>>> a4c0c85 (datanotation)
            var categoria = await _fabricaService.UsuarioService.AdicionarCategoria(adicionarCategoriaDto);
            string response = $"Categoria {categoria.ToString()} adicionada com sucesso!";
            return Accepted(_fabricaResponse.Criar(response));
        }

<<<<<<< HEAD
        [HttpDelete("categoria/{idCategoria:int}")]
        public async Task<IActionResult> RemoverCategoria(int idCategoria)
        {
            var categoriaDto = new CategoriaDto() {IdCategoria = idCategoria, IdLigacao = ObterIdDoToken()};
=======
        /// <summary>
        /// Deletar categoria
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns></returns>
        [HttpDelete("categoria/{idCategoria:int}")]
        public async Task<IActionResult> RemoverCategoria(int idCategoria)
        {
            var categoriaDto = new CategoriaDto() { IdCategoria = idCategoria, IdLigacao = ObterIdDoToken() };
>>>>>>> a4c0c85 (datanotation)
            await _fabricaService.UsuarioService.RemoverCategoria(categoriaDto);
            return NoContent();
        }

<<<<<<< HEAD
=======
        /// <summary>
        /// Listar empresa por categoria
        /// </summary>
        /// <returns></returns>
>>>>>>> a4c0c85 (datanotation)
        [HttpGet("empresas")]
        public async Task<IActionResult?> ListarEmpresasPorCategoria()
        {
            var empresas = await _fabricaService.UsuarioService.ObterEmpresasPorCategoriaUsuario(ObterIdDoToken());
            return Ok(_fabricaResponse.Criar(empresas));
        }
    }
}