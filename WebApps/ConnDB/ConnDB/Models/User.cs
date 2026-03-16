using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelToDatabaseAPI.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("userID")]
        public int UserID { get; set; }

        [Column("customerName")]
        public string CustomerName { get; set; } = null!;

        [Column("age")]
        public int Age { get; set; }

        [Column("city")]
        public string? City { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("rating")]
        public float? Rating { get; set; }
    }
}
