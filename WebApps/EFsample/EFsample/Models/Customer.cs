using System.ComponentModel.DataAnnotations;

namespace EntityFW_Razor.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = null!;
    }
}
