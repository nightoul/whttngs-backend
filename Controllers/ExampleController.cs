using Microsoft.AspNetCore.Mvc;

namespace whttngs_backend.Controllers;

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