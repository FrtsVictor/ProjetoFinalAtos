using DesafioAtos.Application.Core.ActionFilters;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service.Fabrica.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ActionFilterValidacaoModelState]
    public class AutenticacaoController : AppControllerBase
    {
        public AutenticacaoController(IFabricaService fabricaService, IFabricaResponse fabricaResponse) 
            : base(fabricaService, fabricaResponse)
        {
        }

        [HttpPost("usuario")]
        public async Task<IActionResult> LogarUsuario(LogarUsuarioDto loginDto) =>
            Ok(await _fabricaService.AutenticacaoService.LogarUsuario(loginDto));

        [HttpPost("empresa")]
        public async Task<IActionResult> LogarEmpresa(LogarEmpresaDto loginDto) => 
            Ok(_fabricaResponse.Criar(await _fabricaService.AutenticacaoService.LogarEmpresa(loginDto)));

    }
}