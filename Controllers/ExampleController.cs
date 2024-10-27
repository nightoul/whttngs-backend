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
        var value = _configurationManager.EnvExample;
        return Ok($"Environment variables loaded: {value}");
    }
}