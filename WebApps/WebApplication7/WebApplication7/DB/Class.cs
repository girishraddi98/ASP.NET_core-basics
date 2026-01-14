using System.Reflection;

namespace WebApplication7.DB
{
    public enum Gender
    {
        Male,Female
    }
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
    }
    public class AccountDb
    {
        public List<Account> Accounts = new List<Account>();
        private AccountDb()
        {
            Accounts = new List<Account>()
            {
                new Account(){Id=1,Name="Jw",Gender=Gender.Male },
                new Account(){Id=2,Name="Anna",Gender=Gender.Female },
                new Account(){Id=3,Name="Bob",Gender=Gender.Male },
            };


        }
        public static AccountDb Current = new AccountDb();
    }
}
