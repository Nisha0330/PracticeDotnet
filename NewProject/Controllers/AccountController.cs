using Microsoft.AspNetCore.Mvc;
using NewProject.Manager;
using NewProject.Model;

namespace NewProject.Controllers
{
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager _auth;
        public AccountController(IAuthManager auth)
        {
            _auth = auth;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            var token = string.Empty;
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Invalid client request");
            }
            if(user.Username == "testuser" && user.Password == "testpassword")
            {
                token = _auth.GenerateJWTToken();
            }
            // Implement login logic here
            return Ok(new {token});
        }

    }
}
