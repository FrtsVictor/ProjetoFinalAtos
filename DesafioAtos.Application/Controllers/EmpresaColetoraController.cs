using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service.Services.EmpresaColetora;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioAtos.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpresaColetoraController : ControllerBase
    {
        private readonly IEmpresaColetoraService _service;

        public EmpresaColetoraController(IEmpresaColetoraService service)
        {
            _service = service;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetTodasEmpresaColetora();
            return Ok(new List<EmpresaColetoraDto>());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var data = await _service.GetEmpresaColetoraPorId(id);
            return Ok();
        }

        
        [HttpPost]
        public async Task<IActionResult> Post(CriarEmpresaColetoraDto request)
        {
            await _service.EmpresaColetoraPost(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditarEmpresaColetoraDto request)
        {

            await _service.EmpresaColetoraPut(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeletaEmpresaColetora(id);
            return Ok();
        }
    }
}
