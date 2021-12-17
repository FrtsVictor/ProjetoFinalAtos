using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service.Fabrica.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    /// <inheritdoc />
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "EmpresaColetora")]
    public class EmpresaColetoraController : AppControllerBase
    {
        /// <inheritdoc />
        public EmpresaColetoraController(IFabricaService fabricaService, IFabricaResponse fabricaResponse)
            : base(fabricaService, fabricaResponse)
        {
        }

        /// <summary>
        /// Retorna Empresa baseado no ID atrelado ao token.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ObterEmpresaColetora()
        {
            return Ok(await _fabricaService.EmpresaColetoraService.ObterEmpresaColetora(ObterIdDoToken()));
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
            await _fabricaService.EmpresaColetoraService.EditarEditarEmpresaColetora(ObterIdDoToken(), request);
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
    }
}