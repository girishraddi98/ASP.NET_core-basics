using System.ComponentModel.DataAnnotations;

namespace NewProject.Dtos.StudentDto
{
    public class CreateStuDto
    {

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class StudentTokenDto
    {
        public string Token { get; set; }=string.Empty;
    }
    public class StudentDto
    {
        public Guid StudentId { get; set; }
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Token { get; set; } = null;
        public string password { get; set; }

    }
    public class UpdateStuDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Email { get; set; }
       
        
        //public string Password { get; set; }
    }
    public class StudentLoginDto
    {
        public string Name { get; set; }
        public string Password { get; set; }

    }
}
