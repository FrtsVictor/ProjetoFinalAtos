using DesafioAtos.Application.ActionFilters.ValidateModel;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    [ValidateModelActionFilter]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserAuthenticationService _authenticationService;
        public AuthenticationController(IUserAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(CreateUserDto userDto)
        {
            var user = await _authenticationService.Login(userDto);
            return Ok(user);
        }

        [HttpPost("create_account")]
        public async Task<IActionResult> CreateAccount(CreateUserDto userDto)
        {
            var user = await _authenticationService.CreateAccount(userDto);
            return Ok(user);
        }
    }
}