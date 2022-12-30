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
    }

    public async Task<string> Get()
    {
        //Http to Bsckend
        // client.DefaultRequestHeaders.Accept.Clear();
        // client.DefaultRequestHeaders.Accept.Add(
        //     new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        // client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        var json = await client.GetStringAsync("http://weather/WeatherForecast");
        return json;
    }
}
