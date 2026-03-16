namespace ExcelToDatabaseAPI.Services
{
    public interface IUserService
    {
        public string GetUsers();
        public string GetuserById(int id);
        public delegate string CreateUser(string name, int age, string city, string email, float rating);
        public delegate string UpdateUser(int id, string name, int age, string city, string email, float rating);
        public delegate string DeleteUser(int id);
    }
}
