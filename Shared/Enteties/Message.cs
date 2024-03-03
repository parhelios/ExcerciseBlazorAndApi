using MongoDB.Bson.Serialization.Attributes;

namespace Shared.Enteties;

public class Message
{
     [BsonId]
     [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
     public string Id { get; set; }
     public string Text { get; set; }
     public string Author { get; set; }
     public DateTime CreatedAt { get; set; }

     public Message(string id, string text, string author, DateTime createdAt)
     {
          Id = id;
          Text = text;
          Author = author;
          CreatedAt = createdAt;
     }

     public TResult ToDto<TResult>()
     {
          return (TResult)Activator.CreateInstance(typeof(TResult), Id, Text, Author, CreatedAt);
     }
}