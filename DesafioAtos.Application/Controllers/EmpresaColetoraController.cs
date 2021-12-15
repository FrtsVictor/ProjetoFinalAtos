using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service.Fabrica.Services;
using DesafioAtos.Service.Services.EmpresaColetora;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpGet("/categoria")]
        public async Task<IActionResult> ObterCategorias()
        {
            var data = await _fabricaService.EmpresaColetoraService.ObterCategorias(ObterIdDoToken());
            return Ok(data);
        }

        [HttpGet("/endereco")]
        public async Task<IActionResult> ObterEnderecos()
        {
            var data = await _fabricaService.EmpresaColetoraService.ObterEnderecos(ObterIdDoToken());
            return Ok(data);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CriarEmpresaColetoraDto criarEmpresaColetoraDto)
        {
            var data = await _fabricaService.EmpresaColetoraService.CriarEmpresaColetora(criarEmpresaColetoraDto);
            return Created("", _fabricaResponse.Criar(data));
        }

        [HttpPost("/endereco")]
        public async Task<IActionResult> AdicionarEndereco(CriarEnderecoDto criarEnderecoDto)
        {
            var data = await _fabricaService.EmpresaColetoraService.AdicionarEndereco(criarEnderecoDto, ObterIdDoToken());
            return Created("", _fabricaResponse.Criar(data));
        }

        [HttpPut("/endereco")]
        public async Task<IActionResult> AtualizarEndereco(CriarEnderecoDto criarEnderecoDto)
        {
            var data = await _fabricaService.EmpresaColetoraService.AdicionarEndereco(criarEnderecoDto, ObterIdDoToken());
            return Created("", _fabricaResponse.Criar(data));
        }

        [HttpPut]
        public async Task<IActionResult> Put(EditarEmpresaColetoraDto request)
        {
            await _fabricaService.EmpresaColetoraService.EditarEditarEmpresaColetora(ObterIdDoToken(), request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
