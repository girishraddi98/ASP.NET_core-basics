using MongoDB.Bson;
using Monoexample.Models;

namespace Monoexample.Repository
{
    public interface IUserRepo
    {
       public Task<ObjectId> CreateUser(Users user);
        public  Task<Users> GetUser(ObjectId id);
        Task<IEnumerable<Users>> GetUsers();
        Task<bool> UpdateUser(ObjectId id,Users user);
        Task<bool?> Delete(ObjectId id);
    }
}
