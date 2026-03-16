using ExcelToDatabaseAPI.Models;

namespace ExcelToDatabaseAPI.DTO
{
    public class TabDto
    {
        public int orderID { get; set; }
        public User User { get; set; }


        public int customerID { get; set; }
        public customer Customer { get; set; }

        public string? product { get; set; }

        public DateTime order_date { get; set; }

        public decimal price { get; set; }

        public int quantity { get; set; }
    }
}
