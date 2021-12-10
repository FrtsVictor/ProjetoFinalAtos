using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service.EmpresaColetora;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioAtos.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaColetoraController : ControllerBase
    {
        private readonly IEmpresaColetoraService _service;

        public EmpresaColetoraController(IEmpresaColetoraService service)
        {
            _service = service;

        }

        // GET: api/<ColetaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.PegaTodasEmpresaColetora();
            return Ok(new List<EmpresaColetoraDto>());
        }

        // GET api/<ColetaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var data = await _service.PegaEmpresaColetoraPorId(id);
            return Ok();
        }

        
        [HttpPost]
        public async Task<IActionResult> Post(CriarEmpresaColetoraDto request)
        {
            await _service.EmpresaColetoraPost(request);
            return Ok();
        }

        // PUT api/<ColetaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditarEmpresaColetoraDto request)
        {

            await _service.EmpresaColetoraPut(request);
            return Ok();
        }

        // DELETE api/<ColetaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeletaEmpresaColetora(id);
            return Ok();
        }
    }
}
