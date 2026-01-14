using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.ViewModel;

namespace WebApplication3.Controllers
{
    [ApiController]
    public class AccountsController : Controller
    {
        [HttpGet("accounts/Content")]
        public IActionResult Index()
        {
            var movie = new Movie() { Name = "Inception" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }
        public IActionResult Index2(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex=1;
            }
            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy="name";
            }
            return Content(String.Format($"sortby={1},pageIndex={0}",pageIndex, sortBy));
        }
        public IActionResult Index1(int id) { 
            return Content("id=" +id);
        }
        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Inception" };
            return View();
        }
        
    }
}
