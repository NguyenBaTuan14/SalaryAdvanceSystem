using Microsoft.AspNetCore.Mvc;
using SalaryAdvanceSource.Services;

namespace SalaryAdvanceSource.Controllers

{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] string username, [FromForm] string password)
        {
            var success = await _authService.LoginAsync(username, password, HttpContext);
            if (success)
            {
                return Redirect("/");
            }
            return Redirect("/login?error=1");
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync(HttpContext);
            return Redirect("/login");
        }
    }
}
