using Microsoft.AspNetCore.Mvc;
namespace Micro.Front.Controllers;



[ApiController]
[Route("[controller]")]
public class ProxyController : ControllerBase
{
    HttpClient client = new();
    ILogger<ProxyController> _logger;

    public ProxyController(ILogger<ProxyController> logger)
    {
        _logger = logger;
        _logger.LogInformation($"Starting Controller For {Environment.GetEnvironmentVariable("env")} with descrition {Environment.GetEnvironmentVariable("description")}");

    }

    public async Task<string> Get()
    {
        _logger.LogInformation($"{base.HttpContext.Request.Path} Requested By {HttpContext.Request.Host} Serving From {Environment.MachineName} V4");
        //Http to Bsckend
        // client.DefaultRequestHeaders.Accept.Clear();
        // client.DefaultRequestHeaders.Accept.Add(
        //     new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        // client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        var json = await client.GetStringAsync("http://weather-svc/WeatherForecast");
        return json;
    }
}
