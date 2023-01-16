using System.Runtime.CompilerServices;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace debertz.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Authorize]
    public string GetTest()
    {
        return "good";
    }
    
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        
        
        /*var clientId = "439733814505-engce1ajmsfgc3lv7v7lao4u0p6558sq.apps.googleusercontent.com";
        var clientSecret = "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";

        string[] scopes = { "https://mail.google.com/", "https://www.googleapis.com/auth/userinfo.email" };
        
        var credentials = GoogleWebAuthorizationBroker.AuthorizeAsync(
            new ClientSecrets()
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            },
            scopes, "user", CancellationToken.None).Result;

        if (credentials.Token.IsExpired(SystemClock.Default))
            credentials.RefreshTokenAsync(CancellationToken.None).Wait();

        var service = new GmailService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credentials
        });

        var profile = service.Users.GetProfile("edsilenko@gmail.com").Execute();
        Console.WriteLine(profile.MessagesTotal);*/

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}