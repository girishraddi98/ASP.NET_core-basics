using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Monoexample.Models
{
    public class Users
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Email { get; set; }= string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
