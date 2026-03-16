using AuthExample.Models;
using AuthExample.Models;

namespace AuthExample.Services
{
    public interface IAuthService
    {
        public Task<User?> RegisterUser(UserDto userDto);
        public Task<TokenDto?> LoginUser(UserDto userDto);
        //public Task<TokenDto?> RefreshToken(SetRefreshToken refreshToken);

    }
}