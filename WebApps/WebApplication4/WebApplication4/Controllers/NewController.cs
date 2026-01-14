using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("conn/[controller]")]
    public class NewController : Controller
    {
        [HttpGet("getinfo")]
        public IActionResult Index()
        {
            var data = new {Name="Gre",Age=13};
            return Ok(data);
        }
    }
}
