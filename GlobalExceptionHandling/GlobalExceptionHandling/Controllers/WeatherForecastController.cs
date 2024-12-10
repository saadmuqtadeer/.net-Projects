using Microsoft.AspNetCore.Mvc;

namespace GlobalExceptionHandling.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger _logger;

        public WeatherForecastController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //try
            {
                throw new Exception("Error");
                return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray());
            }
            //catch(Exception ex) {
            //    _logger.LogError($"Something went wrong: {ex}");
            //    return StatusCode(500, "Internal server error");
            //}
        }
    }
}
