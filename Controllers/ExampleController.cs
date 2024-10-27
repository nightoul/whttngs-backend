using Microsoft.AspNetCore.Mvc;

namespace ExampleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    private readonly IConfigurationManager _configurationManager;

    public ExampleController(IConfigurationManager configurationManager)
    {
        _configurationManager = configurationManager;
    }

    [HttpGet]
    public IActionResult GetExample()
    {
        return Ok("Hello from Example API!");
    }
}