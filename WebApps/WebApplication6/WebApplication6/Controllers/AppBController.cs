
using App2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using WebApplication6.Services;

namespace WebApplication6.Controllers
{
    [ApiController]
    [Route("api/appb")]
    public class AppBController : ControllerBase
    {
        private readonly AppAService _service;

        public AppBController(AppAService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetDataFromAppA();
            return Ok(data);
        }
        

    }
    [ApiController]
    [Route("test")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Routing works");
        }
    }

}
