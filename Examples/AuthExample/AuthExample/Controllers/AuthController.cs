using AuthExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AuthExample.Services;
using Microsoft.AspNetCore.Authorization;



namespace AuthExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public  AuthController(IConfiguration configuration, IAuthService authService)
        {
            this.configuration = configuration;
            this.authService = authService;
        }
        private readonly IConfiguration configuration ;
        private readonly IAuthService authService;

        [HttpPost("register")]

        public async Task<ActionResult<User>> Register(UserDto request)
        {
            try
            {
                var user = await authService.RegisterUser(request);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> loginAsync(UserDto request)
        {
            try
            {
                var login = await authService.LoginUser(request);
                if (login == null)
                {
                    return BadRequest("Invalid credentials");
                }
                return Ok(login);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message );
            }
        }
        //[HttpPost("refresh-token")]
        //public async Task<ActionResult<TokenDto>> RefreshTokenAsync(SetRefreshToken request)
        //{
        //    try
        //    {
        //        var refreshToken = await authService.RefreshToken(request);
        //        if (refreshToken == null)
        //        {
        //            return BadRequest("Invalid refresh token");
        //        }
        //        return Ok(refreshToken);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [Authorize]
        [HttpGet]
        public IActionResult AuthenticationEndpoint()
        {
            return Ok("Welcome");
        }
        
    }
}
