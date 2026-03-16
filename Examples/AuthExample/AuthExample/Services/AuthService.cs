
using AuthExample.AooDbContext;
using AuthExample.Models;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace AuthExample.Services
{
    public class AuthService(IConfiguration configuration, AppDbcontext appContext) : IAuthService
    {
        private readonly IConfiguration configuration = configuration;
        private readonly AppDbcontext context = appContext;
        public static User user = new User();
        public async Task<User?> RegisterUser(UserDto request)
        {
            try
            {
                var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);
                user.Username = request.Username;
                //user.Role = request.Role;
                user.PasswordHash = hashedPassword;
                context.Users.Add(user);
                await context.SaveChangesAsync();
                return user;

            }
            catch (Exception ex)
            {

                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.Message);
                }
                else
                {
                    throw new Exception(ex.Message);
                }
                throw;
            }
        }

        public async Task<TokenDto?> LoginUser(UserDto request)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user == null)
            {
                return null;
            }
            var verificationResult = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (verificationResult == PasswordVerificationResult.Failed)
            {
                return null;
            }
            var response = new TokenDto()
            {
                AccessToken = createToken(user),
                //RefreshToken = await GenerateAndSaveRefreshToken(user) ?? string.Empty
            };
            return response ;

        }
        //public async Task<TokenDto?> RefreshToken(SetRefreshToken refreshToken)
        //{
        //    var user = await ValidateRefreshTokenAsync(refreshToken);
        //    if (user == null)
        //    {
        //        return null;
        //    }
        //    var response = new TokenDto()
        //    {
        //        AccessToken = createToken(user),
        //        RefreshToken = await GenerateAndSaveRefreshToken(user) ?? string.Empty
        //    };
        //    return response;
        //}
        //private async Task<User?> ValidateRefreshTokenAsync(SetRefreshToken request)
        //{
        //    var user = await context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);
        //    if (user == null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
        //    {
        //        return null;
        //    }
        //    return user;
        //}
        //private string GenerateRefreshToken()
        //{
        //    var randomNumber = new byte[32];
        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(randomNumber);
        //        return Convert.ToBase64String(randomNumber);
        //    }
        //}
        
        //private async Task<string?> GenerateAndSaveRefreshToken(User user)
        //{
        //    var refreshToken = GenerateRefreshToken();
        //    user.RefreshToken = refreshToken;
        //    user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
        //    await context.SaveChangesAsync();
        //    return refreshToken;
        //}

        private string createToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            //foreach(var role in )
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),

                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        
    }
}
