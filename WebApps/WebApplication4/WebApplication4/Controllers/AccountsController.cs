using Microsoft.AspNetCore.Mvc;
using WebApplication4.DB;
using WebApplication4.Models;
using WebApplication4.Models.accounts;
using WebApplication4.Services;


namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        public IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        
        
        public ActionResult<Account> GetAccounts()
        {
            
            return Ok(_accountService.GetAccounts());

        }
        [HttpGet("{id:int}")]
        public ActionResult<Account> GetAccountById(int id) { 
          
            return Ok(_accountService.GetByID(id));
            }

        [HttpPost]
        public ActionResult AddAccounts([FromBody] AddAccounts addaccounts)
        {

            var existingAccount = AccountDb.Current.Accounts
                .Any(a => a.Id == addaccounts.Id);

            if (existingAccount)
            {
                return BadRequest("An account with the same ID already exists.");
            }

            var account = new Account
            {
                Id = addaccounts.Id,
                Name = addaccounts.Name,
                Gender = addaccounts.Gender
            };
            try
            {
                AccountDb.Current.Accounts.Add(account);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error occurred while creating record.");
            }

            return CreatedAtRoute(nameof(GetAccounts), new { id = account.Id }, account);

        }
        [HttpPut]
        public ActionResult<Account> UpdateAccounts([FromBody] UpdateAccounts updateaccounts)
        {
            try { 
            var account = AccountDb.Current.Accounts
        .FirstOrDefault(a => a.Id == updateaccounts.Id);
            if (account == null)
            {
                return NotFound("An account with the same ID already exists.");
            }

            account.Id = updateaccounts.Id;
            account.Name = updateaccounts.Name;
            account.Gender = updateaccounts.Gender;
            return Ok(account);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error updating the table");
            }

        }
        [HttpDelete]
        public ActionResult DeleteAccount(int id)
        {
            try
            {
                var account = AccountDb.Current.Accounts.FirstOrDefault(a => a.Id == id);
                if (account == null)
                {
                    return NotFound();
                }
                AccountDb.Current.Accounts.Remove(account);
                return Ok(account);
            }
            catch (Exception ex) { throw; }
        }
        [HttpGet("Name")]
        public ActionResult<Account> GetNames() { 
            var account = _accountService.GetNames();
            return Ok(account);

        }

        [HttpGet("content")]
        public ContentResult GetContentResult()
        {
            
            return Content("<html><body><h1>Hello, World!</h1></body></html>", "text/html");

        }
        [HttpGet("Json")]
        public IActionResult GetJson()
        {
            var data = new
            {
                Message = "Hello, World!",
                Date = DateTime.Now
            };
            return new JsonResult(data);

        }
        [HttpGet("file")]
        public IActionResult GetFile()
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes("This is a sample text file.");

            return File(bytes, "text/plain", "hello.text");


        }
        [HttpGet("redirect")]
        public IActionResult GetRedirect()
        {
            return Redirect("https://www.example.com");

        }
    }
}
