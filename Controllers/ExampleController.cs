using Microsoft.AspNetCore.Mvc;

namespace ExampleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{

    [HttpGet]
    public IActionResult GetExample()
    {
        return Ok("Hello from Example API!");
    }
}