

using MongoDB.Bson;
using MongoDB.Driver;
using Monoexample.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using Microsoft.AspNetCore;

//namespace Monoexample.Features.User
//{
//    public static class GetUsers
//    {
//        public record Query : IRequest<IEnumerable<Responded>>;
//        public record Responded(
//    ObjectId Id,
//    string Name,
//    string Email,
//    string Phone
//               );

//        public class Handler : IRequestHandler<Query, IEnumerable<Responded>>
//        {
//            private readonly IMongoCollection<Users> _users;
//            public Handler(IMongoClient client)
//            {
//                var db = client.GetDatabase("NewDb");
//                var collection = db.GetCollection<Users>(nameof(Users));
//                _users = collection;



//            }
//            public async Task<IEnumerable<Responded>> Handle(Query query, CancellationToken token)
//            {
//                var resonse = await _users.Find(_ => true).ToListAsync(token);
//                if (resonse == null)
//                    return null;
//                return resonse.Select(static v => new Responded(v.Id, v.Name, v.Email, v.Phone));
//            }
//        }
//        public class Endpoint : ICarterModule
//        {
//            public void AddRoutes(IEndpointRouteBuilder endpoint)
//            {
//                var route = endpoint.MapGet("api/users", async (ISender sender) =>
//                {
//                    return await sender.Send(new Query());
//                })

//                .Produces<IEnumerable<Responded>>(StatusCodes.Status200OK) // tells Swagger the response type
//        .WithName("GetUsers")                                     // optional: endpoint name
//        .WithTags("Users");


//            }
//        }
        
//    }


//}
