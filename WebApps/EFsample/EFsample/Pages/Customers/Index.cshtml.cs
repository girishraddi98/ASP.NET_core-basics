using System.Data.SqlClient;
using EntityFW_Razor.Data;

using EntityFW_Razor.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
namespace EntityFW_Razor
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public IList<Customer> Customer { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Customers != null)
            {
                Customer = await _context.Customers.ToListAsync();
            }
        }
    }
}
//namespace EntityFW_Razor
//{
//    public class IndexModel1 : PageModel
//    {
//        using (var sqlConnection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EntityFW_RazorDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
//        {
//            sqlConnection.Open();
//            using (var sqlCommand = new SqlCommand())
//            {
//                sqlCommand.Connection = sqlConnection;
//                sqlCommand.CommandText = "SELECT * FROM Customers";
//                sqlCommand.CommandType = System.Data.CommandType.Text;
//                using (var reader = sqlCommand.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        var customer = new Customer();

//                        try
//                        {
//                            var id = reader["Id"];
//    var name = reader["Name"];
//    var email = reader["Email"];
//    var phone = reader["Phone"];
//}
//                        catch (Exception ex)
//                        {
//                            Console.WriteLine(ex.Message);
//                        }
//                    }
//                }
//                // Perform database operations
//                sqlConnection.Close();
//            }
//        }

//    }
//}
