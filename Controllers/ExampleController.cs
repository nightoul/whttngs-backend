using Microsoft.AspNetCore.Mvc;

namespace whttngs_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{

    [HttpGet]
    [Route("hello")]
    public IActionResult GetExample()
    {
        return Ok("Hello from Example API route hello");
    }
}