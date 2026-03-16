using System.ComponentModel.DataAnnotations;

namespace NewProject.Dtos
{
    public class InstructorDto
    {
        public Guid InstructorId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Password { get; set; }
        public string Token { get; set; } = string.Empty;
    }
    public class InstructTokenDto
    {
        public string Token { get; set; }= string.Empty;
        
    }
    public class AddInstructDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Password { get; set; }

    }
    public class UpgradeInstructDto {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Email { get; set; }
        //[Required]
        //[StringLength(100, MinimumLength = 2)]
        //public string Password { get; set; }
    }
    public class LoginInstructDto
    {
        [Required]
        public Guid InstructorId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Password { get; set; }
    }
}
