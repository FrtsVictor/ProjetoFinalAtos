using DesafioAtos.Application.Core.ActionFilters;
using DesafioAtos.Domain.Dtos;
<<<<<<< HEAD
=======
using DesafioAtos.Service.Fabrica.Services;
>>>>>>> a4c0c85 (datanotation)
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ActionFilterValidacaoModelState]
    public class AutenticacaoController : AppControllerBase
    {
<<<<<<< HEAD
        public AutenticacaoController(IFabricaService fabricaService, IFabricaResponse fabricaResponse)
=======
        public AutenticacaoController(IFabricaService fabricaService, IFabricaResponse fabricaResponse) 
>>>>>>> a4c0c85 (datanotation)
            : base(fabricaService, fabricaResponse)
        {
        }
        /// <summary>
        /// Login do Usuário
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost("usuario")]
        public async Task<IActionResult> LogarUsuario(LogarUsuarioDto loginDto) =>
            Ok(await _fabricaService.AutenticacaoService.LogarUsuario(loginDto));

        /// <summary>
        /// Login da Empresa
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost("empresa")]
        public async Task<IActionResult> LogarEmpresa(LogarEmpresaDto loginDto) => 
<<<<<<< HEAD
            Ok(_fabricaResponse.Create(await _fabricaServices.AutenticacaoService.LogarEmpresa(loginDto)));       
=======
            Ok(_fabricaResponse.Criar(await _fabricaService.AutenticacaoService.LogarEmpresa(loginDto)));

>>>>>>> a4c0c85 (datanotation)
    }
}