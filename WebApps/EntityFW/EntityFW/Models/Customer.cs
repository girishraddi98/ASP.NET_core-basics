using EntityFW.Models;
using System.ComponentModel.DataAnnotations;

namespace EntityFW.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}