using Application.Checkup.Queries.GetCheckup;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers;

public class CheckupController : ApiControllerBase
{
    [HttpGet]
    public async Task<Checkup> Get()
    {
        return await Mediator.Send(new GetCheckupQuery(ConfigurationManagerHelper.getConfig("AppName"), ConfigurationManagerHelper.getConfig("AppVersion")));
    }
}