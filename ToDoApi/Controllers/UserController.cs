using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Infrastructure.Auth;
using ToDoApi.Services.UserService;
using ToDoApi.Services.UserService.Request;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _serivce;
        private readonly IConfiguration _configuration;

        public UserController(IUserService serivce, IConfiguration configuration)
        {
            _serivce = serivce;
            _configuration = configuration;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            int id = await _serivce.Register(model);
            return Ok(id);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            var user = await _serivce.Login(model);
            return Ok(JwtHealper.CreateToken(user, _configuration));
        }
    }
}
