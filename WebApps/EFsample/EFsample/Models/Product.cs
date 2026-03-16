using System.ComponentModel.DataAnnotations;

namespace EntityFW_Razor.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Range(0.01, 10000)]
        public decimal Price { get; set; }
    }
}
