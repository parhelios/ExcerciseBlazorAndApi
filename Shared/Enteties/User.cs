using MongoDB.Bson.Serialization.Attributes;

namespace Shared.Enteties;

public class User
{
     [BsonId]
     [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
     public string Id { get; set; }
     public string Username { get; set; }

     public User(string id, string username)
     {
          Id = id;
          Username = username;
     }

     public TResult ToDto<TResult>()
     {
          return (TResult)Activator.CreateInstance(typeof(TResult), Id, Username);
     }
}