using System.Threading.Tasks;
using DesafioAtos.Application.ActionFilters.ValidateModel;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ActionFilterValidacaoModelState]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _authenticationService;
        public AutenticacaoController(IAutenticacaoService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LogarUsuarioDto loginDto)
        {
            var user = await _authenticationService.Logar(loginDto);
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