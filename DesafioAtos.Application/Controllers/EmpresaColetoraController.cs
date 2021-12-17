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

        /// <summary>
        /// Atualizar Empresa.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Atualização da empresa</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /AtualizarEmpresa
        ///     {
        ///        "nome": "string",
        ///         "cnpj": "31.665.065/0001-80",
        ///         "telefone": "112345688",
        ///         "email": "string@string.com",
        ///          "senha": "string"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna atualização ok</response>
        /// <response code="400">Se o request for nulo</response>
        [HttpPut]
        public async Task<IActionResult> AtualizarEmpresa(EditarEmpresaColetoraDto request)
        {
            await _fabricaService.EmpresaColetoraService.EditarEmpresaColetora(ObterIdDoToken(), request);
            return Ok();
        }
        /// <summary>
        /// Remover empresas
        /// </summary>
        /// <returns></returns>
        [HttpDelete()]
        public async Task<IActionResult> RemoverEmpresa()
        {
            await _fabricaService.EmpresaColetoraService.DeletaEmpresaColetora(ObterIdDoToken());
            return Ok();
        }
        /// <summary>
        /// Criar Empresa.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Atualização da empresa</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /CriarEmpresa
        ///     {
        ///        "nome": "string",
        ///         "cnpj": "31.665.065/0001-80",
        ///         "telefone": "112345688",
        ///         "email": "string@string.com",
        ///         "senha": "string"
        ///          
        ///         "enderecos": [
        ///          {
        ///            "numero": "123A",
        ///            "complemento": "Galpão 2",
        ///            "rua": "Rua Trinta",
        ///            "cep": "03235000",
        ///            "cidade": "Cidade",
        ///            "estado": "Estado",
        ///            "bairro": "Bairro"
        ///          }
        ///         ],
        ///         "categorias": [0,3,8]
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna criação ok</response>
        /// <response code="400">Se o request for nulo</response>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CriarEmpresa(CriarEmpresaColetoraDto criarEmpresaColetoraDto)
        {
            var data = await _fabricaService.EmpresaColetoraService.CriarEmpresaColetora(criarEmpresaColetoraDto);
            return Created("", _fabricaResponse.Criar(data));
        }


        /// <summary>
        /// Obter todas as categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet("/categoria")]
        public async Task<IActionResult> ObterCategorias()
        {
            var data = await _fabricaService.EmpresaColetoraService.ObterCategorias(ObterIdDoToken());
            return Ok(data);
        }
        /// <summary>
        /// Deleta a categoria por Id
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <returns></returns>
        [HttpDelete("/categoria/{idCategoria:int}")]
        public async Task<IActionResult> RemoverCategoria(int idCategoria)
        {
            var categoriaDto = new CategoriaDto() { IdCategoria = idCategoria, IdLigacao = ObterIdDoToken() };
            await _fabricaService.EmpresaColetoraService.RemoverCategoria(categoriaDto);
            return NoContent();
        }
        /// <summary>
        /// Adicionar Categoria
        /// </summary>
        /// <param name="request"></param>
        /// 
        /// <response code="201">Retorna criação ok</response>
        /// <response code="400">Se o request for nulo</response>
        [HttpPost("/categoria/{idCategoria:int}")]
        public async Task<IActionResult> AdicionarCategoria(int idCategoria)
        {
            var adicionarCategoriaDto = new CategoriaDto() { IdCategoria = idCategoria, IdLigacao = ObterIdDoToken() };
            var categoria = await _fabricaService.EmpresaColetoraService.AdicionarCategoria(adicionarCategoriaDto);
            string response = $"Categoria {categoria.ToString()} adicionada com sucesso!";
            return Accepted(_fabricaResponse.Criar(response));
        }

        /// <summary>
        /// Obter Enderecos
        /// </summary>

        [HttpGet("/endereco")]
        public async Task<IActionResult> ObterEnderecos()
        {
            var data = await _fabricaService.EmpresaColetoraService.ObterEnderecos(ObterIdDoToken());
            return Ok(data);
        }
        /// <summary>
        /// Adicionar Endereço
        /// </summary>
        /// <param name="request"></param>
        /// <response code="201">Retorna criação ok</response>
        /// <response code="400">Se o request for nulo</response>
        [HttpPost("/endereco")]
        public async Task<IActionResult> AdicionarEndereco(CriarEnderecoDto criarEnderecoDto)
        {
            var data = await _fabricaService.EmpresaColetoraService.AdicionarEndereco(criarEnderecoDto, ObterIdDoToken());
            return Created("", _fabricaResponse.Criar(data));
        }

        /// <summary>
        /// Criar Empresa.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Atualização da empresa</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /CriarEmpresa
        ///     {
        ///       "numero": "123A",
        ///       "complemento": "Galpão 1",
        ///       "rua": "Rua 1",
        ///       "cep": "01234000",
        ///       "cidade": "Cidade",
        ///       "estado": "Estado",
        ///       "bairro": "Bairro"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna criação ok</response>
        /// <response code="400">Se o request for nulo</response>
        /// 
        [HttpPut("/endereco/{idEndereco:int}")]
        public async Task<IActionResult> EditarEndereco(int idEndereco, EditarEnderecoDto editarEmpresa)
        {


            await _fabricaService.EmpresaColetoraService.EditarEndereco(idEndereco, editarEmpresa);
            return NoContent();
        }

        /// <summary>
        /// Deletar Endereço
        /// </summary>
        /// <param name="idEndereco"></param>
        /// <returns></returns>
        [HttpDelete("/endereco/{idEndereco:int}")]
        public async Task<IActionResult> RemoverEndereco(int idEndereco)
        {
            await _fabricaService.EmpresaColetoraService.RemoverEndereco(idEndereco);
            return NoContent();
        }
    }
}