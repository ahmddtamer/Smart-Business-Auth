using IdentityTemplate.APIs.Controllers.Controllers.Base;
using IdentityTemplate.Core.Application.Abstraction.Services;
using IdentityTemplate.Shared.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTemplate.APIs.Controllers.Controllers.Account
{
    public class AccountController(IServiceManager serviceManager) : BaseApiController
    {

        [HttpPost("login")] //Post: /api/account/login
        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {
            var user = await serviceManager.AuthService.LoginAysnc(model);
            return Ok(user);
        }

        [HttpPost("register")] //Post: /api/account/register
        public async Task<ActionResult<UserDto>> Register(RegisterDto model)
        {
            var user = await serviceManager.AuthService.RegisterAsync(model);
            return Ok(user);
        }

        
        [HttpGet] //Get: /api/account
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var result = await serviceManager.AuthService.GetCurrentUser(User);
            return Ok(result);
        }
       
        
        [HttpGet("emailexists")] //Put: /api/account/emailexists?email= ahmed.gmail.com
        public async Task<ActionResult<bool>> CheckEmailExists(string email)
        {
            var result = await serviceManager.AuthService.EmailExists(email);
            return Ok(result);
        }
       


    }
}
