using AutoMapper;
using ExcelToDatabaseAPI.Context;
using ExcelToDatabaseAPI.DTO;
using ExcelToDatabaseAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ExcelToDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabController : ControllerBase
    {
        private readonly AppDbContext appDb;
        private readonly IMapper mapper;
        private readonly ITabService tab;

        public TabController(AppDbContext appDb, IMapper mapper, ITabService tab)
        {
            this.appDb = appDb;
            this.mapper = mapper;
            this.tab = tab;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            
            var emp = await tab.GetTabsAsync();
            var nDto = mapper.Map<List<TabDto>>(emp);
            return Ok(nDto);
        }
    }
    
    
}
