using Microsoft.AspNetCore.Mvc;

namespace Redis.Net8._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SheetController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<SheetController> _logger;

        public SheetController(ILogger<SheetController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSheet")]
        public IEnumerable<Sheet> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Sheet
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
