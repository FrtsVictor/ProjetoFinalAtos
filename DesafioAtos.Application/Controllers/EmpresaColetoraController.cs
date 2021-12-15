using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service.Fabrica.Services;
using DesafioAtos.Service.Services.EmpresaColetora;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioAtos.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpresaColetoraController : ControllerBase
    {
        private readonly IFabricaService _fabricaService;

        public EmpresaColetoraController(IFabricaService fabricaService)
        {
            _fabricaService = fabricaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok();
        }

        
        [HttpPost]
        public async Task<IActionResult> Post(CriarEmpresaColetoraDto request)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditarEmpresaColetoraDto request)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok();
        }
    }
}
