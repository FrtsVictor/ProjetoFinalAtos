using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service.Fabrica.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "EmpresaColetora")]
    public class EmpresaColetoraController : AppControllerBase
    {
        public EmpresaColetoraController(IFabricaService fabricaService, IFabricaResponse fabricaResponse)
            : base(fabricaService, fabricaResponse)
        {
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarEmpresa(EditarEmpresaColetoraDto request)
        {
            await _fabricaService.EmpresaColetoraService.EditarEditarEmpresaColetora(ObterIdDoToken(), request);
            return Ok();
        }

        [HttpDelete()]
        public async Task<IActionResult> RemoverEmpresa()
        {
            await _fabricaService.EmpresaColetoraService.DeletaEmpresaColetora(ObterIdDoToken());
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CriarEmpresa(CriarEmpresaColetoraDto criarEmpresaColetoraDto)
        {
            var data = await _fabricaService.EmpresaColetoraService.CriarEmpresaColetora(criarEmpresaColetoraDto);
            return Created("", _fabricaResponse.Criar(data));
        }


        [HttpGet("/categoria")]
        public async Task<IActionResult> ObterCategorias()
        {
            var data = await _fabricaService.EmpresaColetoraService.ObterCategorias(ObterIdDoToken());
            return Ok(data);
        }

        [HttpDelete("/categoria/{idCategoria:int}")]
        public async Task<IActionResult> RemoverCategoria(int idCategoria)
        {
            var categoriaDto = new CategoriaDto() {IdCategoria = idCategoria, IdLigacao = ObterIdDoToken()};
            await _fabricaService.EmpresaColetoraService.RemoverCategoria(categoriaDto);
            return NoContent();
        }

        [HttpPost("/categoria/{idCategoria:int}")]
        public async Task<IActionResult> AdicionarCategoria(int idCategoria)
        {
            var adicionarCategoriaDto = new CategoriaDto() {IdCategoria = idCategoria, IdLigacao = ObterIdDoToken()};
            var categoria = await _fabricaService.EmpresaColetoraService.AdicionarCategoria(adicionarCategoriaDto);
            var response = $"Categoria {categoria.ToString()} adicionada com sucesso!";
            return Accepted(_fabricaResponse.Criar(response));
        }


        [HttpGet("/endereco")]
        public async Task<IActionResult> ObterEnderecos()
        {
            var data = await _fabricaService.EmpresaColetoraService.ObterEnderecos(ObterIdDoToken());
            return Ok(data);
        }

        [HttpPost("/endereco")]
        public async Task<IActionResult> AdicionarEndereco(CriarEnderecoDto criarEnderecoDto)
        {
            var data = await _fabricaService.EmpresaColetoraService.AdicionarEndereco(criarEnderecoDto,
                ObterIdDoToken());
            return Created("", _fabricaResponse.Criar(data));
        }

        [HttpPut("/endereco/{idEndereco:int}")]
        public async Task<IActionResult> EditarEndereco([FromRoute] int idEndereco,
            [FromBody] EditarEnderecoDto editarEmpresa)
        {
            await _fabricaService.EmpresaColetoraService.EditarEndereco(idEndereco, editarEmpresa);
            return NoContent();
        }

        [HttpDelete("/endereco/{idEndereco:int}")]
        public async Task<IActionResult> RemoverEndereco(int idEndereco)
        {
            await _fabricaService.EmpresaColetoraService.RemoverEndereco(idEndereco);
            return NoContent();
        }
    }
}