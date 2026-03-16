using AuthExample.Models;

namespace AuthExample.Models
{
   
    public class User
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public string Username { get; set; }=string.Empty;
        public string PasswordHash { get; set; }=string.Empty;
        public string Role { get; set; }=string.Empty;
        //public List<string> Role { get; set;}
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        
    };
    

}

