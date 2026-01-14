using WebApplication4.Models;
using WebApplication4.DB;
using System.ComponentModel.DataAnnotations;
namespace WebApplication4.Services
{
    public interface IAccountService
    {
        
        public Account GetByID(int id);
         public string GetNames();
        public IEnumerable<Account> GetAccounts();
    }
    
}
