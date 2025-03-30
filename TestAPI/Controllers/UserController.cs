using Microsoft.AspNetCore.Mvc;
using TestAPI.Models.TestAPI.User.Models;
using TestAPI.Objects;
using TestAPI.Services;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService UserService;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, UserService UserService)
        {
            _logger = logger;
            this.UserService = UserService;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestModel model)
        {
            try
            {
                var result = await UserService.RegisterUser(model);
                return Ok(result);
            }
            catch(Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserRequestModel model)
        {
            try
            {
                var result = await UserService.Login(model);
                return Ok(result);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout([FromBody] UserRequestModel model)
        {
            try
            {
                var result = await UserService.Logout(model);
                return Ok(result);
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.Message);
            }
        }
    }
}
