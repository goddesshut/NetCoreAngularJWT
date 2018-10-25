using BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using WebService.Handler;
using Utils;

namespace WebService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseApiController
    {
        protected readonly IAuthenticateServiceBLL AuthenticateService;

        public AuthController(IAuthenticateServiceBLL authenticateService)
        {
            this.AuthenticateService = authenticateService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]AuthenticationViewModel model)
        {
            var token = this.AuthenticateService.Authenticate(model);

            if (string.IsNullOrEmpty(token))
            {
                return this.Unauthorized();
            }

            return this.Ok(new { token = token.ToString() });
        }

        [HttpPost("logout")]
        public void logout()
        {
            // User Log
            this.AuthenticateService.Logout(User.GetClaimValueOfNameIdentifier());
        }
    }
}