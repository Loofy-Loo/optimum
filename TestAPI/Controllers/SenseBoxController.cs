using Microsoft.AspNetCore.Mvc;
using TestAPI.Models.TestAPI.User.Models;
using TestAPI.Objects;
using TestAPI.Services;
using TestAPI.Models;
using TestAPI.Models.TestAPI.SenseBox.Models;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SenseBoxController : ControllerBase
    {
        private readonly SenseBoxService SenseBoxService;
        private readonly ILogger<SenseBoxController> _logger;

        public SenseBoxController(ILogger<SenseBoxController> logger, SenseBoxService SenseBoxService)
        {
            _logger = logger;
            this.SenseBoxService = SenseBoxService;
        }

        [HttpPost]
        [Route("NewSenseBox")]
        public async Task<IActionResult> NewSenseBox([FromBody] SenseBoxRequestModel model)
        {
            try
            {
                var result = await SenseBoxService.NewSenseBox(model);
                return Ok(result);
            }
            catch(Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpGet]
        [Route("GetSenseBox")]
        public async Task<IActionResult> GetSenseBox(string senseBoxId, string? format)
        {
            try
            {
                var result = await SenseBoxService.GetSenseBox(senseBoxId, format);
                return Ok(result);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
    }
}
