using System.Threading.Tasks;
using DesafioAtos.Application.ActionFilters.ValidateModel;
using DesafioAtos.Infra.UnitfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesafioAtos.Application.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    [ValidateModelActionFilter]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IResponseFactory _responseFactory;

        public UserController(ILogger<UserController> logger, IUnitOfWork unitOfWork, IResponseFactory responseFactory)
        {
            _responseFactory = responseFactory;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            var crated = await _unitOfWork.Customers.Create(customer);
            return Ok(crated);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, Customer customer)
        {
            var userToBeUpdated = await _unitOfWork.Customers.GetById(id);
            userToBeUpdated.Cpf = customer.Cpf;
            userToBeUpdated.Name = customer.Name;
            userToBeUpdated.Password = customer.Password;
            userToBeUpdated.Username = customer.Username;

            await _unitOfWork.Customers.Update(userToBeUpdated);
            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _unitOfWork.Customers.Remove(id);
            return NoContent();
        }

        [HttpGet("customer/{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await _unitOfWork.Customers.GetById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _unitOfWork.Customers.Get());
        }
    }
}