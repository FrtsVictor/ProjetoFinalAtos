using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service.Fabrica.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers;

/// <summary>
/// Controller para CRUD de endereco referente a EmpresaColetora
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
public class EnderecoController : AppControllerBase
{
    /// <inheritdoc />
    public EnderecoController(IFabricaService fabricaService, IFabricaResponse fabricaResponse) : base(fabricaService,
        fabricaResponse)
    {
    }

    /// <summary>
    /// Criar endereco para EmpresaColetora.
    /// </summary>
    /// <param name="criarEnderecoDto"></param>
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
    /// <response code="400">Se o request for nulo ou inválido</response>
    /// <response code="401"> Caso nao possua autenticacao</response>
    /// <response code="403"> Caso nao possua autorizacao</response>
    [Authorize(Roles = "EmpresaColetora")]
    [HttpPost("/endereco-empresa")]
    public async Task<IActionResult> CriarEnderecoEmpresaColetora(CriarEnderecoDto criarEnderecoDto)
    {
        var data = await _fabricaService.EmpresaColetoraService.AdicionarEndereco(criarEnderecoDto,
            ObterIdDoToken());
        return Created("", _fabricaResponse.Criar(data));
    }

    /// <summary>
    /// Criar Empresa.
    /// </summary>
    /// <param name="idEndereco"></param>
    /// <param name="editarEmpresa"></param>
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
    /// <response code="201">Retorna criação ok </response>
    /// <response code="400">Se o request for nulo ou inválido</response>
    /// <response code="401"> Caso nao possua autenticacao</response>
    /// <response code="403"> Caso nao possua autorizacao</response>
    [HttpPatch("/endereco-empresa/{idEndereco:int}")]
    [Authorize(Roles = "EmpresaColetora")]
    public async Task<IActionResult> EditarEnderecoEmpresaColetora(int idEndereco, EditarEnderecoDto editarEmpresa)
    {
        await _fabricaService.EmpresaColetoraService.EditarEndereco(idEndereco, editarEmpresa);
        return NoContent();
    }

    /// <summary>
    /// Deletar Endereço
    /// </summary>
    /// <param name="idEndereco"></param>
    /// <response code="400">Se o request for nulo ou inválido</response>
    /// <response code="401"> Caso nao possua autenticacao</response>
    /// <response code="403"> Caso nao possua autorizacao</response>
    [HttpDelete("/endereco-empresa/{idEndereco:int}")]
    [Authorize(Roles = "EmpresaColetora")]
    public async Task<IActionResult> RemoverEnderecoEmpresaColetora(int idEndereco)
    {
        await _fabricaService.EmpresaColetoraService.RemoverEndereco(idEndereco);
        return NoContent();
    }

    /// <summary>
    /// Obtem todos Enderecos da EmpresaColetora
    /// </summary>
    /// <response code="400">Se o request for nulo ou inválido</response>
    /// <response code="401"> Caso nao possua autenticacao</response>
    /// <response code="403"> Caso nao possua autorizacao</response>
    [HttpGet("/endereco-empresa")]
    [Authorize(Roles = "EmpresaColetora")]
    public async Task<IActionResult> ObterEnderecosEmpresaColetora()
    {
        var data = await _fabricaService.EmpresaColetoraService.ObterEnderecos(ObterIdDoToken());
        return Ok(data);
    }
}