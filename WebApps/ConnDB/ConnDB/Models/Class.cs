using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelToDatabaseAPI.Models
{
    [Table("customer")]
    public class customer
    {
        [Key]
        [Column("customerID")]
        public int customerID { get; set; }
        [Column("customerName")]
        public string? customerName { get; set; }
        [
Column("age")]
        public int age { get; set; }
        [Column("city")]
        public string? city { get; set; }

    };
    [Table("tab")]
    public class tab
    {
        [Key]
        [Column("orderID")]
        public int orderID { get; set; }
        [Column("customerID")]
        public int customerID{ get; set; }
        [Column("product")]
        public string? product { get; set; }
        [Column("order_date")]
        public DateTime order_date { get; set; }
        [Column("price")]
        public decimal price { get; set; }
        [Column("quantity")]
        public int quantity { get; set; }
        public customer? Customer { get; set; }
    }
}
