using CsvHelper;
using ExcelToDatabaseAPI.Context;
using ExcelToDatabaseAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Globalization;
using System.Linq.Expressions;

namespace ExcelToDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly MySqlConnection _connection;
        private readonly ILogger _logger;
        
        private readonly AppDbContext _context;
        public DBController(IConfiguration configuration, AppDbContext context, ILogger<DBController> logger)
        {
           this. _configuration = configuration;
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
           this. _connection = new MySqlConnection(connectionString);
           this. _context = context;
            this._logger = logger;
        }
        [HttpGet("user")]
        public async Task<IActionResult> GetUsers()=>Ok(await _context.Users.ToListAsync());

     
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                return Ok(await _context.Users.FirstOrDefaultAsync());
            }
            catch 
            {
                throw;
            }

        }
        
        [HttpPost("addusers")]
        public async Task<IActionResult> CreateUsers([FromBody] List<User> users)
        {
            foreach (var user in users)
            {
                await _context.Database.ExecuteSqlRawAsync("CALL insert_tousers({0},{1},{2},{3},{4},{5})",
                    user.UserID, user.CustomerName, user.Age, user.City, user.Email, user.Rating);
                _logger.LogInformation($"User with ID {user.UserID} created successfully.");
            }
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Users created successfully.", CreatedUsers = users });
        }
        //[HttpPost("adduser")]
        //public IActionResult CreateUser()
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound(new { Message = $"The given id {id} is not present in table" });
        //        _logger.LogWarning($"User with ID {id} not found for update.", id);
        //    }
            

        //}
        

        [HttpPut("user/{id}")]

        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = $"The given id {id} is not present in table" });
                _logger.LogWarning($"User with ID {id} not found for update.", id);
            }
            user.CustomerName = updatedUser.CustomerName;
            user.Age = updatedUser.Age;
            user.City = updatedUser.City;
            user.Email = updatedUser.Email;
            user.Rating = updatedUser.Rating;
            await _context.SaveChangesAsync();
            return Ok(new { Message = "User updated successfully.", UpdatedUser = user });
        }

        [HttpDelete("user/{id}")]
        public async Task<ActionResult> DeleteUsers(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = $"The given id {id} is not present in table" });
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "User deleted successfully.", DeletedUser = user });

        }
        [HttpGet("databsetocsv")]
        public async Task<IActionResult> ExportDatabaseToCsv()
        {
            var users = await _context.Users.ToListAsync();
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "database_export.csv");
            using var writer = new StreamWriter(filepath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(users);
            return Ok(new { Message = "Database exported to CSV successfully.", FilePath = filepath });
        }
        [HttpGet("databasetopdf")]
        public async Task<IActionResult> ExportDbToPdf()
        {
            var users = await _context.Users.ToListAsync();
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "Databaseexport.pdf");
            using (var pdfWriter = new StreamWriter(filepath))
            {
                pdfWriter.WriteLine("Database dump from table ");
                pdfWriter.WriteLine("=================================");
                foreach (var user in users) { pdfWriter.WriteLine($"{"UserID",-10} {"CustomerName",-20} {"Age",-5} {"City",-15} {"Email",-25} {"Rating",-10}"); }
                return Ok(new { Message = "Database exported to PDF successfully.", FilePath = filepath });
            }
        }
    
}
}
