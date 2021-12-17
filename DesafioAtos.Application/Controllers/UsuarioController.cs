using DesafioAtos.Application.Core.ActionFilters;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service.Fabrica.Services;
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

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CriarUsuario(CriarUsuarioDto userDto)
        {
            var user = await _fabricaService.UsuarioService.CriarUsuario(userDto);
            return Created("", _fabricaResponse.Criar(user.Id));
        }

        [HttpPut]
        public async Task<IActionResult> EditarUsuario(EditarUsuarioDto atualizarUsuarioDto)
        {
            await _fabricaService.UsuarioService.Editar(ObterIdDoToken(), atualizarUsuarioDto);
            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> RemoverUsuario()
        {
            await _fabricaService.UsuarioService.Remover(ObterIdDoToken());
            return NoContent();
        }


        [HttpGet("categoria")]
        public async Task<IActionResult?> ListarCategorias()
        {
            var categorias = await _fabricaService.UsuarioService.ObterCategorias(ObterIdDoToken());
            return Ok(_fabricaResponse.Criar(categorias));
        }

        [HttpPost("categoria/{idCategoria:int}")]
        public async Task<IActionResult> AdicionarCategoria(int idCategoria)
        {
            var adicionarCategoriaDto = new CategoriaDto() {IdCategoria = idCategoria, IdLigacao = ObterIdDoToken()};
            var categoria = await _fabricaService.UsuarioService.AdicionarCategoria(adicionarCategoriaDto);
            string response = $"Categoria {categoria.ToString()} adicionada com sucesso!";
            return Accepted(_fabricaResponse.Criar(response));
        }

        [HttpDelete("categoria/{idCategoria:int}")]
        public async Task<IActionResult> RemoverCategoria(int idCategoria)
        {
            var categoriaDto = new CategoriaDto() {IdCategoria = idCategoria, IdLigacao = ObterIdDoToken()};
            await _fabricaService.UsuarioService.RemoverCategoria(categoriaDto);
            return NoContent();
        }

        [HttpGet("empresas")]
        public async Task<IActionResult?> ListarEmpresasPorCategoria()
        {
            var empresas = await _fabricaService.UsuarioService.ObterEmpresasPorCategoriaUsuario(ObterIdDoToken());
            return Ok(_fabricaResponse.Criar(empresas));
        }
    }
}