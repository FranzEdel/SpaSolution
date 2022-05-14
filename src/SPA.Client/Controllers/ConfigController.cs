using Microsoft.AspNetCore.Mvc;

namespace SPA.Client.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfigController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public ConfigController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public ActionResult Index()
    {
        return Ok(
            new
            {
                ApiUrl = _configuration.GetValue<string>("ApiUrl")
            }
        );
    }

}
