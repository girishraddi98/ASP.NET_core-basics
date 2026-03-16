namespace AuthExample.Models
{
    public class UserDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    public class TokenDto
    {
        public string AccessToken { get; set; } = string.Empty;
        //public string RefreshToken { get; set; } = string.Empty;
    }
    //public class SetRefreshToken
    //{
    //    public string RefreshToken { get; set; } = string.Empty;
    //    public Guid UserId { get; set; }
    //}
}
