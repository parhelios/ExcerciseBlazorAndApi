namespace Shared.DTOs;

public class MessageDto
{
     public string Id { get; set; }
     public string Text { get; set; }
     public string Author { get; set; }
     public DateTime CreatedAt { get; set; }

     public MessageDto(string id, string text, string author, DateTime createdAt)
     {
          Id = id;
          Text = text;
          Author = author;
          CreatedAt = createdAt;
     }
     public T ToEntity<T>()
     {
          return (T)Activator.CreateInstance(typeof(T), Id, Text, Author, CreatedAt);
     }
}