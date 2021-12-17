using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service.Fabrica.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers;

/// <summary>
/// Controller para manipular categorias do Usuario e EmpresaColetora
/// </summary>
[Route("api/v1")]
[ApiController]
public class CategoriaController : AppControllerBase
{
    /// <inheritdoc />
    public CategoriaController(IFabricaService fabricaService, IFabricaResponse fabricaResponse) : base(fabricaService,
        fabricaResponse)
    {
    }

    /// <summary>
    /// Obter todas as categorias da EmpresaColetora
    /// </summary>
    /// <returns></returns>
    [HttpGet("/categoria-empresa")]
    [Authorize(Roles = "EmpresaColetora")]
    public async Task<IActionResult> ObterCategoriasEmpresaColetora()
    {
        var data = await _fabricaService.EmpresaColetoraService.ObterCategorias(ObterIdDoToken());
        return Ok(data);
    }

    /// <summary>
    /// Deleta a categoria da EmpresaColetora por Id
    /// </summary>
    /// <param name="idCategoria"></param>
    /// <returns></returns>
    [HttpDelete("/categoria-empresa/{idCategoria:int}")]
    [Authorize(Roles = "EmpresaColetora")]
    public async Task<IActionResult> RemoverCategoriaEmpresaColetora(int idCategoria)
    {
        var categoriaDto = new CategoriaDto() {IdCategoria = idCategoria, IdLigacao = ObterIdDoToken()};
        await _fabricaService.EmpresaColetoraService.RemoverCategoria(categoriaDto);
        return NoContent();
    }

    /// <summary>
    /// Adicionar Categoria para EmpresaColetora
    /// </summary>
    /// <param name="idCategoria"></param>
    /// 
    /// <response code="201">Retorna criação ok</response>
    /// <response code="400">Se o request for nulo</response>
    [HttpPost("/categoria-empresa/{idCategoria:int}")]
    [Authorize(Roles = "EmpresaColetora")]
    public async Task<IActionResult> AdicionarCategoriaEmpresaColetora(int idCategoria)
    {
        var adicionarCategoriaDto = new CategoriaDto() {IdCategoria = idCategoria, IdLigacao = ObterIdDoToken()};
        var categoria = await _fabricaService.EmpresaColetoraService.AdicionarCategoria(adicionarCategoriaDto);
        string response = $"Categoria {categoria.ToString()} adicionada com sucesso!";
        return Accepted(_fabricaResponse.Criar(response));
    }


    /// <summary>
    /// Listar todas as categorias por Usuario
    /// </summary>
    /// <returns></returns>
    [HttpGet("categoria-usuario")]
    [Authorize(Roles = "Usuario")]
    public async Task<IActionResult?> ListarCategoriasUsuario()
    {
        var categorias = await _fabricaService.UsuarioService.ObterCategorias(ObterIdDoToken());
        return Ok(_fabricaResponse.Criar(categorias));
    }

    /// <summary>
    /// Adicionar Categoria para Usuario
    /// </summary>
    /// <param name="idCategoria"></param>
    /// <returns></returns>
    [HttpPost("categoria-usuario/{idCategoria:int}")]
    [Authorize(Roles = "Usuario")]
    public async Task<IActionResult> AdicionarCategoriaUsuario(int idCategoria)
    {
        var adicionarCategoriaDto = new CategoriaDto() {IdCategoria = idCategoria, IdLigacao = ObterIdDoToken()};
        var categoria = await _fabricaService.UsuarioService.AdicionarCategoria(adicionarCategoriaDto);
        var response = $"Categoria {categoria.ToString()} adicionada com sucesso!";
        return Accepted(_fabricaResponse.Criar(response));
    }

    /// <summary>
    /// Deletar categoria por Usuario
    /// </summary>
    /// <param name="idCategoria"></param>
    /// <returns></returns>
    [HttpDelete("categoria-usuario/{idCategoria:int}")]
    [Authorize(Roles = "Usuario")]
    public async Task<IActionResult> RemoverCategoria(int idCategoria)
    {
        var categoriaDto = new CategoriaDto() {IdCategoria = idCategoria, IdLigacao = ObterIdDoToken()};
        await _fabricaService.UsuarioService.RemoverCategoria(categoriaDto);
        return NoContent();
    }
}