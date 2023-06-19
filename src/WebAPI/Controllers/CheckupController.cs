using Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CheckupController : Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        var result = "{" + $"\"AppName\":\"{ConfigurationManagerHelper.getConfig("AppName")}\", \"version\":\"{ConfigurationManagerHelper.getConfig("AppVersion")}\",\"status\",\"OK\"" + "}";
        //var result = "{" + $"\"AppName\":\"\", \"version\":\"\",\"status\",\"OK\"" + "}";
        return Ok(result);
    }
}