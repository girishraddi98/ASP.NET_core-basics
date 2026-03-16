using MongoDB.Bson;
using MongoDB.Driver;
using Monoexample.Models;
using System.ComponentModel.DataAnnotations;

namespace Monoexample.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly IMongoCollection<Users> _users;
        public UserRepo(IMongoClient client)
        {
            var db = client.GetDatabase("NewDb");
            var collection = db.GetCollection<Users>(nameof(Users));
            _users = collection ;



        }
        public async Task<ObjectId> CreateUser(Users user)
        {
            try
            {
                await _users.InsertOneAsync(user);
                
                return user.Id;
            }
            catch  { throw new InvalidOperationException();
            }
        }

        public async Task<bool?> Delete(ObjectId id)
        {
            try
            {
                var user = _users.FindAsync(a => a.Id == id);
                if (user != null) { return null; }
                var result = await _users.DeleteOneAsync(filter => filter.Id == id);
                return result.DeletedCount == 1;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Users> GetUser(ObjectId id)
        {
            try
            {
                var user = await _users.FindAsync(a=>a.Id == id);
                if (user == null) {
                    return null;
                }
                return await user.FirstOrDefaultAsync();
            }
            catch { 
                throw new InvalidOperationException();
                
            }
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            try
            {
               var user= await _users.Find(_ =>true).ToListAsync();
                return user;
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }

        public async Task<bool> UpdateUser(ObjectId id, Users user)
        {
            var filter = Builders<Users>.Filter.Eq(u => u.Id, id);
            if(user==null) {  return false; }


            var update = Builders<Users>.Update
                .Set(u => u.Name, user.Name)
                .Set(u => u.Email, user.Email)
                .Set(u => u.Phone, user.Phone);

            var result = await _users.UpdateOneAsync(filter, update)
            ;

            return result.ModifiedCount == 1;
        }
    }
}
