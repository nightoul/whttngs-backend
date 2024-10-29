using Microsoft.AspNetCore.Mvc;

namespace whttngs_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{

    [HttpGet]
    [Route("hello")]
    public IActionResult GetExample()
    {
        return Ok("Hello from Posts controller route hello");
    }
}