using Microsoft.AspNetCore.Mvc;
using Redis.Net8.Models;
using Redis.Net8.Repository;

namespace Redis.Net8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SheetController : ControllerBase
    {
        private readonly ISheetRepository _sheetRepository;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<SheetController> _logger;

        public SheetController(ILogger<SheetController> logger, ISheetRepository sheetRepository)
        {
            _logger = logger;
            _sheetRepository = sheetRepository;
        }

        [HttpGet(Name = "GetSheet")]
        public IEnumerable<Sheet> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Sheet
            {
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{Id}", Name = "GetSheetById")]
        public ActionResult<Sheet> GetSheetById(string Id)
        {
            var sheet = _sheetRepository.GetSheetById(Id);

            if(sheet == null)
            {
                return NotFound();
            }
            return Ok(sheet);
        }

        [HttpPost]
        public ActionResult<Sheet> AddSheet(Sheet sheet)
        {
            _sheetRepository.AddSheet(sheet);
            return CreatedAtRoute(nameof(GetSheetById), new { Id = sheet.Id }, sheet);
        }
    }
}
