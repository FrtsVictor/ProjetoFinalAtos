using System.Security.Claims;
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
        public async Task<IActionResult> CriarUsuario(CriarUsuarioDto userDto)
        {
            var user = await _fabricaService.UsuarioService.CriarConta(userDto);
            return Ok(_fabricaResponse.Create(user.Id));
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarUsuario(AtualizarUsuarioDto atualizarUsuarioDto)
        {
            atualizarUsuarioDto.Id = ObterIdUsuarioDoToken();
            await _fabricaService.UsuarioService.Atualizar(atualizarUsuarioDto);
            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> RemoverUsuario()
        {
            await _fabricaService.UsuarioService.Remover(ObterIdUsuarioDoToken());
            return NoContent();
        }


        [HttpPost("/categoria/{idCategoria:int}")]
        public async Task<IActionResult> AdicionarCategoria(int idCategoria)
        {
            var adicionarCategoriaDto = new CategoriaDto() { IdCategoria = idCategoria, IdLigacao = ObterIdUsuarioDoToken() };
            var categoria = await _fabricaService.UsuarioService.AdicionarCategoria(adicionarCategoriaDto);
            string response = $"Categoria {categoria.ToString()} adicionada com sucesso!";
            return Ok(_fabricaResponse.Create(response));
        }

        [HttpDelete("/categoria/{idCategoria:int}")]
        public async Task<IActionResult> RemoverCategoria(int idCategoria)
        {
            var categoriaDto = new CategoriaDto() { IdCategoria = idCategoria, IdLigacao = ObterIdUsuarioDoToken() };
            await _fabricaService.UsuarioService.RemoverCategoria(categoriaDto);
            return NoContent();
        }

        [HttpGet("/categoria")]
        public async Task<IActionResult?> ListarCategorias()
        {
            var categorias = await _fabricaService.UsuarioService.ObterCategorias(ObterIdUsuarioDoToken());
            return Ok(_fabricaResponse.Create(categorias));
        }

        [HttpGet("/empresas")]
        public async Task<IActionResult?> ListarEmpresasPorCategoria()
        {
            var empresas = await _fabricaService.UsuarioService.ObterEmpresasPorCategoriaUsuario(ObterIdUsuarioDoToken());
            return Ok(_fabricaResponse.Create(empresas));
        }

        private int ObterIdUsuarioDoToken()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            return Convert.ToInt32(claimsIdentity?.FindFirst("id")?.Value);
        }
    }
}