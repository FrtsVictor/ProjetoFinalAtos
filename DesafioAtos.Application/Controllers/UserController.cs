using Microsoft.AspNetCore.Mvc;

[Route("api/v1/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ICustomerRepository _cutomerRepository;

    public UserController(ICustomerRepository cutomerRepository)
    {
        _cutomerRepository = cutomerRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Customer customer)
    {
        var crated = await _cutomerRepository.Create(customer);
        return Ok(crated);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, Customer customer)
    {
        var userToBeUpdated = await _cutomerRepository.GetById(id);
        userToBeUpdated.Cpf = customer.Cpf;
        userToBeUpdated.Name = customer.Name;
        userToBeUpdated.Password = customer.Password;
        userToBeUpdated.Username = customer.Username;

        await _cutomerRepository.Update(userToBeUpdated);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _cutomerRepository.Remove(id);
        return NoContent();
    }

    [HttpGet("custommer/{id}")]    
    public async Task<IActionResult> GetByid(long id)
    {        
        return Ok(await _cutomerRepository.GetById(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _cutomerRepository.Get());
    }
}