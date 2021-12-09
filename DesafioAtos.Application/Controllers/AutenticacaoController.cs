using System.Threading.Tasks;
using DesafioAtos.Application.ActionFilters.ValidateModel;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    [ValidateModelActionFilter]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _authenticationService;
        public AutenticacaoController(IAutenticacaoService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(CriarUsuarioDto userDto)
        {
            var user = await _authenticationService.Logar(userDto);
            return Ok(user);
        }

        [HttpPost("create_account")]
        public async Task<IActionResult> CreateAccount(CriarUsuarioDto userDto)
        {
            var user = await _authenticationService.CriarConta(userDto);
            return Ok(user);
        }
    }
}