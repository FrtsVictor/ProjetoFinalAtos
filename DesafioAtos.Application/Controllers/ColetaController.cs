using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service.Coleta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ColetaController : ControllerBase
    {
        private readonly IColetaService _service;

        public ColetaController(IColetaService service)
        {
            _service = service;

        }

        // GET: api/<ColetaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.PegaTodasColeta();
            return Ok(new List<ColetaDto>());
        }

        // GET api/<ColetaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var data = await _service.PegaColetaPorId(id);
            return Ok();
        }

        // POST api/<ColetaController>
        [HttpPost]
        public async Task<IActionResult> Post(CriarColetaDto request)
        {
            await _service.ColetaPost(request);
            return Ok();
        }

        // PUT api/<ColetaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditarColetaDto request)
        {

            await _service.ColetaPut(request);
            return Ok();
        }

        // DELETE api/<ColetaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeletaColeta(id);
            return Ok();
        }
    }
}