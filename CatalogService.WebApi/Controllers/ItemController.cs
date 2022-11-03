using Microsoft.AspNetCore.Mvc;

namespace net_advanced_course.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ItemController> _logger;

        public ItemController(ILogger<ItemController> logger)
        {
            _logger = logger;
        }
    }
}