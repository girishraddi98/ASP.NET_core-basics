using WebApplication4.DB;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class AccountService : IAccountService
    {
        public Account GetByID(int id)
        {
            try { return AccountDb.Current.Accounts.First(a => a.Id == id); }
            catch (Exception)
            {
                throw;
            }

        }
        public string GetNames()
        {
            try
            {
                return AccountDb.Current.Accounts.Select(a => a.Name).First();
            } catch (Exception) {
                throw;
                    }
        }
        public IEnumerable<Account> GetAccounts() { 
            return AccountDb.Current.Accounts;
        }
    }
}
