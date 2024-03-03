using static System.Net.Mime.MediaTypeNames;

namespace Shared.DTOs;

public class UserDto
{
     public string Id { get; set; }
     public string Username { get; set; }

     public UserDto(string id, string username)
     {
          Id = id;
          Username = username;
     }
     public T ToEntity<T>()
     {
          return (T)Activator.CreateInstance(typeof(T), Id, Username);
     }
}