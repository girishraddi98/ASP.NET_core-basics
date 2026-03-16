using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using MongoDB.Bson;
using MongoDB.Driver;
using Monoexample.Models;
using Monoexample.Repository;
using SharpCompress.Common;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Monoexample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IMongoCollection<Vochers> _users;
        private readonly ILogger<UserController> Logger;


        public UserController(IMongoClient client, ILogger<UserController> logger)
        {
            var db = client.GetDatabase("Projectdb");
            var collection = db.GetCollection<Vochers>(nameof(Vochers));
            _users = collection;
            this.Logger = logger;
        }



        //[HttpGet]

        //public async Task<IActionResult> Index() { 
        //   var user= await _repo.GetUsers();
        //    return new JsonResult(user);
        //}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    var user = await _repo.GetUser(ObjectId.Parse(id));

        //    if (user == null)
        //        return NotFound();

        //    return Ok(user);
        //}

        //[HttpPost]
        //public IActionResult createNew(Users users)
        //{
        //    var newId = _repo.CreateUser(users);
        //    return new JsonResult(new { newId });
        //}
        //[HttpPut("get/{id}")]
        //public async Task<ActionResult> Update(string id, Users users)
        //{
        //    var newId = await _repo.UpdateUser(ObjectId.Parse(id), users);
        //    return new JsonResult(new { newId });
        //}
        //[HttpDelete("get/{id}")]
        //public async Task<ActionResult> DeleteUser(string id)
        //{
        //    var newId = await _repo.Delete(ObjectId.Parse(id));
        //    return new JsonResult(new { newId });
        //}
        //[HttpGet("download")]
        //public IActionResult Download()
        //{
        //    var path = "files/example.csv";
        //    var bytes = System.IO.File.ReadAllBytes(path);

        //    return File(bytes, "application/pdf", "example.csv");
        //}
        //[HttpGet]
        //public IActionResult Get([FromQuery] string orderId)
        //{
        //    return Ok(new { received = orderId });
        //}
        [HttpGet("by-order")]
        public async Task<IActionResult> GetByOrder([FromQuery] string? orderId /*[FromQuery]string? filteron(Field Name),[FromQuery]string? filterQuery,[FromQuery]string? sortBy,[FromQuery]bool? isAscending, [FromQuery]int PageNumber=1,[FromQuery] int PageSize=10*/)
        {

            Logger.LogInformation("Get the DOC's by the order id is invoked!");

            var filter = Builders<Vochers>.Filter.Eq("Orders.OrdersId", orderId);

            if (orderId == null)
            {
                throw new ArgumentNullException(nameof(orderId));
            }
            var result = await _users.Aggregate().Match(filter).ToListAsync();
            if (!result.Any())
            {
                throw new KeyNotFoundException($"Invalid Id, {orderId} not present in Collection");
            }
            Logger.LogInformation($"Found {JsonSerializer.Serialize(orderId)}");
            return Ok();



        }
        [HttpGet]
        public async Task< IActionResult> GetList()
        {
            var filter = Builders<Vochers>.Filter.ElemMatch(
            x => x.Payment_Terms,
            o => o.terms == null
            || o.terms == "NULL"
            || o.terms == ""

            );
            var result = await _users.Find(filter).Limit(4).ToListAsync();
           

            if (!result.Any())
            {
                throw new Exception("The are no vouchers in here");
            }
            Logger.LogInformation($"Vochers: {JsonSerializer.Serialize(result)}");
            return Ok(result);
        }
        



        [HttpGet("all")]
        public async Task<IActionResult> GetVochers()
        {

            var result = await _users.Find(_ => true).Limit(1).ToListAsync();


            if (!result.Any()) { 
                throw new KeyNotFoundException("The are no vouchers in here"); }
            Logger.LogInformation($"Vochers: {JsonSerializer.Serialize(result)}");
            return Ok(result);


        }



       
    }
}
