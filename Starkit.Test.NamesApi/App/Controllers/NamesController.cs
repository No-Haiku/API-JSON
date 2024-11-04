using App.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NamesController : ControllerBase
    {
        private readonly INameService _nameService;
        private readonly ILogger<NamesController> _logger;

        public NamesController(INameService nameService, ILogger<NamesController> logger)
        {
            _nameService = nameService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetNames([FromQuery] string gender, [FromQuery] string name)
        {
            _logger.LogInformation("Received request with gender: {Gender}, name: {Name}", gender, name);
            var names = _nameService.GetNames(gender, name);
            _logger.LogInformation("Returning {Count} names", names.Count());
            return Ok(names);
        }

    }

}
