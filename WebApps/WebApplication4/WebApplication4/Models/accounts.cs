using WebApplication4.Models;
namespace WebApplication4.Models
{
    public enum Gender
    {
        Male,Female
    }
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
    }
}
