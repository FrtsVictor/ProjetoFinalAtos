using Microsoft.AspNetCore.Mvc;

[Route("api/v1/user")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult Create()
    {
        return Ok("Created");
    }

    [HttpPut]
    public IActionResult Update()
    {
        return NoContent();
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return NoContent();
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Get Method");
    }
}